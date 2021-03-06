using System;
using UnityEngine;
using manager;
using model;
using MVC.entrance.gate;
using helper;

namespace NetGame
{
	public interface IMessage
	{
		void OnMessage (UInt16 op, byte[] bytesData);
	}

	public class GameMessage : IMessage
	{    		
		public void OnMessage (UInt16 op, byte[] bytesData)
		{
			//Loger.Notice("parser message op={0} length={1}", op, bytesData.Length);
			eG2CType opType = (eG2CType)op;
			switch (opType) {
			case eG2CType.G2C_ErrorMssage: ///错误消息
				NetErrorMessage msg = new NetErrorMessage ();
				msg.ToObject (bytesData);

				switch (msg.errorCode) {
				case -99999845:
				case -99999846:
				case -99999839:
					ViewHelper.DisplayMessageLanguage (msg.errorCode.ToString ());
					return;
				case -99999837:
					ViewHelper.DisplayMessageLanguage (msg.errorCode.ToString ());
					NetBase.GetInstance ().kickOutByServer = true;
					return;
				case -99999834:
					return;
				default:
					break;
				}

				if (msg.protocolId == (int)eC2GType.C2G_CreateRole) { //创角回复
					GCSendCreateRole.createRole ((int)msg.errorCode);
				} else if (msg.protocolId == (int)eC2GType.C2G_Ping) {
					NetBase.GetInstance ().serverDisconnect = true; //服务器断开连接
				} else if ((eC2GType)msg.protocolId == eC2GType.C2G_AskWashEquip) {
					//洗练失败，获得经验值
					if (msg.errorCode > 0) {
						helper.ViewHelper.DisplayMessage (string.Format (LanguageManager.GetText ("refine_failure"), msg.errorCode));
						Gate.instance.sendNotification (MsgConstant.MSG_REFINE_DISPLAY_SELECT_VO, false);
					} else if (msg.errorCode == 0) {
						Gate.instance.sendNotification (MsgConstant.MSG_REFINE_DISPLAY_SELECT_VO, false);
					} else {
						ViewHelper.DisplayMessageLanguage ("refine_failure_exp_full");
					}

				} else if (msg.errorCode == 0) {
					if ((eC2GType)msg.protocolId == eC2GType.C2G_AskRelive) {
						///成功复活
						CharacterPlayer.character_property.setHP (CharacterPlayer.character_property.getHPMax ());
						CharacterPlayer.character_property.SetMP (CharacterPlayer.character_property.getMPMax ());
						if (CharacterPlayer.sPlayerMe) {
							CharacterPlayer.sPlayerMe.OnRevive ();
//                                CharacterPlayer.sPlayerMe.GetAI().SendStateMessage(CharacterAI.CHARACTER_STATE.CS_IDLE);
						}
					} else 
					if ((eC2GType)msg.protocolId == eC2GType.C2G_BoxDropGoods) {
						///宝箱显示完成
						ItemManager.GetInstance ().showAwardItems = true;
					} else 
					///宝石合成成功
					if ((eC2GType)msg.protocolId == eC2GType.C2G_AskCombineGem) {
						ItemEvent.GetInstance ().OnNotifyItemFuncStatus (ePackageFuncType.eComp, msg.errorCode);
						MergeManager.Instance.MergeComplate (true);
						FormulaManager.Instance.MergeComplate (true);
					} else if ((eC2GType)msg.protocolId == eC2GType.C2G_AskGetEMailPrize) {
						EmailManager.Instance.SuccessReceiveItem ();
						FloatMessage.GetInstance ().PlayNewFloatMessage (LanguageManager.GetText ("ReceiveEMailPrizeSuccess"), false, UIManager.Instance.getRootTrans ());
					} else if ((eC2GType)msg.protocolId == eC2GType.C2G_AskBuyShopItem) { //购买商品成功
						Gate.instance.sendNotification (MsgConstant.MSG_FEEB_CLOSE);
						FloatMessage.GetInstance ().PlayNewFloatMessage (LanguageManager.GetText 
("msg_buy_item_success"), false, UIManager.Instance.getRootTrans ());
					} else if ((eC2GType)msg.protocolId == eC2GType.C2G_UseGoods) {
						FloatMessage.GetInstance ().PlayNewFloatMessage (LanguageManager.GetText ("msg_use_goods_success"), false, UIManager.Instance.getRootTrans ());
					} else if ((eC2GType)msg.protocolId == eC2GType.C2G_AskTowerInstanceAward) {
						Gate.instance.sendNotification (MsgConstant.MSG_DEMON_RECEIVE_AWARD);
					} else if ((eC2GType)msg.protocolId == eC2GType.C2G_AskIntensifyEquip) {
						//强化成功
						Gate.instance.sendNotification (MsgConstant.MSG_STRENGTHEN_ASK_CALLBACK_RESULT, true);
						Gate.instance.sendNotification (MsgConstant.MSG_ADVANCED_ASK_CALLBACK_RESULT, true);
					} else if ((eC2GType)msg.protocolId == eC2GType.C2G_AskUseItemInWorldBoss) {
						BattleWorldBoss.GetInstance ().OnRecvPropertyChange ();
						BossManager.Instance.UpdateBuffInfo ();
					}
				} else if (msg.errorCode == 1) {
					if ((eC2GType)msg.protocolId == eC2GType.C2G_AskIntensifyEquip) {
                        
						//强化失败
						Gate.instance.sendNotification (MsgConstant.MSG_STRENGTHEN_ASK_CALLBACK_RESULT, false);
						Gate.instance.sendNotification (MsgConstant.MSG_ADVANCED_ASK_CALLBACK_RESULT, false);
					} else if ((eC2GType)msg.protocolId == eC2GType.C2G_AskCombineGem) {
						//合成道具失败
						MergeManager.Instance.MergeComplate (false);
						FormulaManager.Instance.MergeComplate (false);
					}
                    
				} else {
					ArenaManager.Instance.challengerRank = 0;

					if (msg.errorCode == -1) {
						if ((eC2GType)msg.protocolId == eC2GType.C2G_AskCombineGem) {
							ItemEvent.GetInstance ().OnNotifyItemFuncStatus (ePackageFuncType.eComp, msg.errorCode);
						}
					} else {
						if (SweepManager.Instance.IsSweeping) {
							if (msg.errorCode == -99999928) { //背包已满错误码
								Gate.instance.sendNotification (MsgConstant.MSG_SWEEP_STOP, eStopSweep.eBagFull);
							}
						} else if (msg.errorCode == 99999859) {
							DungeonManager.Instance.ViewDungeonView ();
						} else if (msg.errorCode != -99999992 && msg.errorCode != -99999921 && msg.errorCode != -99999893)
							FloatMessage.GetInstance ().PlayNewFloatMessage (LanguageManager.GetText (msg.errorCode.ToString ()), false, UIManager.Instance.getRootTrans ());
						//UIManager.Instance.ShowDialog(eDialogSureType.eNone, "[" + msg.errorCode.ToString() + "]" + FromNetString(msg.errorMessage));
						//                        UIManager.Instance.ShowDialog(eDialogSureType.eNone, LanguageManager.GetText(msg.errorCode.ToString()));
					}
				}
				break;
			///登入回应
			case eG2CType.G2C_LoginRet:
				RequestLoginRet login = new RequestLoginRet ();
				login.ToObject (bytesData);
				{
					if (login._flag == -99999998) 
                    {
						SelectServer.sSelect.createRole (false);
					} 
                    CacheUserInfo userInfo = CacheManager.GetInstance ().GetCacheInfo ();
					userInfo.GUID = Global.FromNetString (login._userGUID);
					userInfo.UserName = Global.FromNetString (login._userName);
					//userInfo.UserPassword = Global.userInputPassword;
					CacheManager.GetInstance ().SetUserLoginInfo (userInfo);
					CacheManager.GetInstance ().SaveCache ();
				}
				break;
			///角色列表
            case eG2CType.G2C_RoleList:
				GSNotifyRoleBaseInfo roleInfo = new GSNotifyRoleBaseInfo ();
				roleInfo.ToObject (bytesData);
				MessageManager.Instance.my_property.setSeverID ((int)roleInfo.m_un32ObjID);
				MessageManager.Instance.my_property.setNickName (Global.FromNetString (roleInfo.m_n32RoleNickName));
				MessageManager.Instance.my_property.setCareer ((CHARACTER_CAREER)roleInfo.m_n32CareerID);
				MessageManager.Instance.my_property.setSex ((int)roleInfo.m_bGender);
				MessageManager.Instance.my_property.setAttackPower ((int)roleInfo.m_fightProperty.GetValue (eFighintPropertyCate.eFPC_Attack));
				MessageManager.Instance.my_property.setDefence ((int)roleInfo.m_fightProperty.GetValue (eFighintPropertyCate.eFPC_Defense));
				MessageManager.Instance.my_property.setArmor ((int)roleInfo.m_un32CoatTypeID);
				MessageManager.Instance.my_property.setWeapon ((int)roleInfo.m_un32WeaponId);
				MessageManager.Instance.my_property.setLevel ((int)roleInfo.m_un32Level);
				MessageManager.Instance.my_property.setExperience ((int)roleInfo.m_un32Exp);
				MessageManager.Instance.my_property.setHP ((int)roleInfo.m_un32CurHP);
				MessageManager.Instance.my_property.SetMP ((int)roleInfo.m_un32CurMP);
				MessageManager.Instance.my_property.setCurHPVessel (roleInfo.m_un32CurHPVessel);
				MessageManager.Instance.my_property.setCurMPVessel (roleInfo.m_un32CurMPVessel);
				MessageManager.Instance.my_property.setHPMax ((int)roleInfo.m_un32MaxHP);
				MessageManager.Instance.my_property.setMPMax ((int)roleInfo.m_un32MaxMP);
				MessageManager.Instance.my_property.setMaxHPVessel (roleInfo.m_un32MaxHPVessel);
				MessageManager.Instance.my_property.setMaxMPVessel (roleInfo.m_un32MaxMPVessel);
				MessageManager.Instance.my_property.fightProperty = roleInfo.m_fightProperty;
				MessageManager.Instance.my_property.maxPackages = roleInfo.m_un32Max_packages;
				MessageManager.Instance.my_property.maxPackages = roleInfo.m_un32Max_packages;
				WingManager.Instance.setCurrentWing (roleInfo.wingID);
				MainLogic.sMainLogic.enterGame ();
                    ///通知数据
				EventDispatcher.GetInstance ().OnPlayerProperty ();
				EventDispatcher.GetInstance ().OnPlayerLevel ();
				break;
			///进入场景
			case eG2CType.G2C_RoleChangeScene:
				GSNotifyChangeScene changeScene = new GSNotifyChangeScene ();
				changeScene.ToObject (bytesData);
				if (CharacterPlayer.sPlayerMe) 
                {
                    if (CharacterPlayer.character_property.getServerMapID() == (int)(changeScene.m_un32MapID))
                    {
                        return;
                    }

					CharacterPlayer.character_property.setServerSceneID ((int)changeScene.m_un32SceneID);
					CharacterPlayer.character_property.setServerMapID ((int)changeScene.m_un32MapID);
					CharacterPlayer.character_property.setClientMapID ((int)changeScene.m_un32ClientNO);
					MainLogic.sMainLogic.enterScene (changeScene.m_un32MapID);
					if (!NetBase.GetInstance ().clientDisconnect) {
						if (CharacterPlayer.sPlayerMe) {
							// 在创角界面需要把人物偏移
							CharacterPlayer.sPlayerMe.setPositionLikeGod (new Vector3 (Constant.PLAYER_INIT_POSITION_X, Constant.PLAYER_INIT_POSITION_Y, Constant.PLAYER_INIT_POSITION_Z));
						}
						CharacterPlayer.character_property.setEnterCityPos (new Vector3 (changeScene.m_fPosX, 0, changeScene.m_fPosZ));
					} else {
						NetBase.GetInstance ().clientDisconnect = false; //在这里重置标记
					}
				} else {
					Loger.Log ("已经在这个场景中了！");
				}
				break;
			case eG2CType.G2C_RoleAppear:
				GSNotifyRoleAppear roleAppear = new GSNotifyRoleAppear ();
				roleAppear.ToObject (bytesData);
				//判断是不是自己
				if (MessageManager.Instance.my_property.getSeverID () != (int)roleAppear.m_un32ObjID) {
					//判断是否已经存在
					if (!PlayerManager.Instance.getPlayerOther ((int)roleAppear.m_un32ObjID)) {
						// 先存起来
						if (Global.m_bInGame) {
							PlayerManager.Instance.OnPlayerAppear (roleAppear);
						} else
							PlayerManager.Instance.m_kListLoginPlayerOther.Add (roleAppear);
					}	
				}
				break;
			case eG2CType.G2C_ObjectDisappear:
				GSObjectDisappear objDisappear = new GSObjectDisappear ();
				objDisappear.ToObject (bytesData);
				
				for (int i = 0; i < objDisappear.ObjNum; i++) {
					PlayerManager.Instance.destroyPlayerOther ((int)objDisappear.m_un32ObjID [i]);
				}
				break;
			///登入回应包裹列表
			case eG2CType.G2C_BagInfo:
				NetLoginItems item = new NetLoginItems ();
				item.ToObject (bytesData);
				break;
			case eG2CType.G2C_EquipmentInfo:
				NetLoginEquipmentInfo equipInfo = new NetLoginEquipmentInfo ();
				equipInfo.ToObject (bytesData);
				break;
			case eG2CType.G2C_ObjectMove:
				GSObjectMove moveMsg = new GSObjectMove ();
				moveMsg.ToObject (bytesData);
					//判断是不是自己
					//if (CharacterPlayer.character_property.getSeverID() != (int)moveMsg.m_un32ObjID) 
				{
					MessageManager.Instance.receiveMessageObjectMove (moveMsg);
				}
				break;
			case eG2CType.G2C_RoleInfoChange:
				GSNotifyRoleProfileChange roleInfoChangeMsg = new GSNotifyRoleProfileChange ();
				roleInfoChangeMsg.ToObject (bytesData);
					//判断是不是自己
				if (CharacterPlayer.character_property.getSeverID () != (int)roleInfoChangeMsg.m_un32ObjID) {
					MessageManager.Instance.receiveMessageRoleInfoChange (roleInfoChangeMsg);
				}
				break;
			///已经通关的地图信息
			case eG2CType.G2C_NotifyRoleMapScheduleList:  
				GSNotifyRoleMapScheduleList mapInfo = new GSNotifyRoleMapScheduleList ();
				mapInfo.ToObject (bytesData);
				break;
			///角色属性
			case eG2CType.G2C_RoleFightProperty:
				GSNotifyRoleFightProperty roleFight = new GSNotifyRoleFightProperty ();
				roleFight.ToObject (bytesData);
				break;
			///角色资产数据
			case eG2CType.G2C_AssetChange:
				GSNotifyAssetChange roleAsset = new GSNotifyAssetChange ();
				roleAsset.ToObject (bytesData);
				break;
			///角色等级数据
			case eG2CType.G2C_RoleLevelChange:
				GSNotifyLevelChange roleLevel = new GSNotifyLevelChange ();
				roleLevel.ToObject (bytesData);
				break;
			///角色经验数据
			case eG2CType.G2C_RoleExpChange:
				GSNotifyExpChange roleExp = new GSNotifyExpChange ();
				roleExp.ToObject (bytesData);
				break;
			///血量
			case eG2CType.G2C_RoleCurProperty:
				GSNotifyCurProperty rolePro = new GSNotifyCurProperty ();
				rolePro.ToObject (bytesData);
				break;
			///显示奖励面板
			case eG2CType.G2C_NotifyDisplayGateIncome:
				//ItemManager.GetInstance ().canShwoAwardPanel = true;
				Gate.instance.sendNotification (MsgConstant.MSG_FIGHT_STOP_TIME);
				break;
			///技能点变更
			case eG2CType.G2C_NotifySkillPointChange:
				GSNotifySkillPointChange point = new GSNotifySkillPointChange ();
				point.ToObject (bytesData);
				break;
			///技能列表
			case eG2CType.G2C_NotifyCurSkillInfo:
				GSNotifyCurSkillInfo skill = new GSNotifyCurSkillInfo ();
				skill.ToObject (bytesData);
				break;
			///技能卡
			case eG2CType.G2C_NotifyCanActiveSkillCardList:
				GSNotifyCanActiveSkillCardList skillCard = new GSNotifyCanActiveSkillCardList ();
				skillCard.ToObject (bytesData);
				break;
			///其它玩家使用技能
			case eG2CType.G2C_NotifySkillReleased:
				GSNotifySkillReleased skillRelease = new GSNotifySkillReleased ();
				skillRelease.ToObject (bytesData);
				if (skillRelease.m_un32ObjectID != CharacterPlayer.character_property.getSeverID ()) {
					MessageManager.Instance.receiveMessageOtherUseSkill (skillRelease);
				}
				break;
			///多人副本主机刷了怪
			case eG2CType.G2C_NotifyObjectAppear:
				GSNotifyObjectAppear objectAppear = new GSNotifyObjectAppear ();
				objectAppear.ToObject (bytesData);
				MessageManager.Instance.receiveMessageObjectAppear (objectAppear);
				break;
			///多人副本主机怪死亡
			case eG2CType.G2C_NotifyObjectDisappear:
				GSNotifyObjectDisappear objectDisappear = new GSNotifyObjectDisappear ();
				objectDisappear.ToObject (bytesData);
				if (objectDisappear.m_un32ObjID != CharacterPlayer.character_property.getSeverID ()) {
					MessageManager.Instance.receiveMessageObjectDisappear (objectDisappear);
				}
				break;
			//多人副本对象行为 // 自己的不需要接受
			// 世界boss也走这里
			case eG2CType.G2C_NotifyObjectAction:
				GSNotifyObjectAction objectBehavior = new GSNotifyObjectAction ();
				objectBehavior.ToObject (bytesData);
				if ((Global.inMultiFightMap () && !CharacterPlayer.character_property.getHostComputer () //&&
				//CharacterPlayer.character_property.GetInstanceID() != objectBehavior.m_un32ObjID
                        ) ||
					(Global.InWorldBossMap ())) {
					MessageManager.Instance.receiveMessageObjectBehavior (objectBehavior);
				}
				break;
			case eG2CType.G2C_NotifyObjectHurm:
				{
					GSNotifyObjectHurm objectHurt = new GSNotifyObjectHurm ();
					objectHurt.ToObject (bytesData);

					if (Global.inMultiFightMap ()) {
						// 多人副本中某个对象收到伤害 给所有人发
						MessageManager.Instance.receiveMessageObjectHurtInMulti (objectHurt);
					} else if (Global.InWorldBossMap ()) {
						MessageManager.Instance.receiveMessageObjectHurtInWorldBoss (objectHurt);
					}
				}
				break;
			///聊天信息
			case eG2CType.G2C_NotifyChatInfo:
				{
					GCNotifyChatInfo chat = new GCNotifyChatInfo ();
					chat.ToObject (bytesData);                        
				}
				break;
			case eG2CType.G2C_NotifyAchievementChange:
				{
					GCNotifyAchievementChange mission = new GCNotifyAchievementChange ();
					mission.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifyTitleChange:
				{
					GCNotifyTitleChange title = new GCNotifyTitleChange ();
					title.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifyEMailList:
				{
					GSNotifyEMailList pcMsg = new GSNotifyEMailList ();
					pcMsg.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifyItemChange:
				{
					NotifyItemChange itemChange = new NotifyItemChange ();
					itemChange.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifyRankList:
				{
					GSNotifyRankList rankMsg = new GSNotifyRankList ();
					rankMsg.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifyShopTemp:
				{
					NetShopItems shopItems = new NetShopItems ();
					shopItems.ToObject (bytesData);
				}
				;
				break;
			case eG2CType.G2C_NotifyChargeIOS:
				{
					GCNotifyChargeIOS chargeIOS = new GCNotifyChargeIOS ();
					chargeIOS.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_ResponseNotice: //公告的回复
				{
					GSNotifyService notice = new GSNotifyService ();
					notice.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifyGoblinRemainTimes:
				{
					GSNotifyGoblinRemainTimes remainTime = new GSNotifyGoblinRemainTimes ();
					remainTime.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifyTaskInfo: //任务信息
				{
					GSNotifyTaskInfo taskInfo = new GSNotifyTaskInfo ();
					taskInfo.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifySkillBookChange:
				{
					NetSkillBookSkills bookSkillData = new NetSkillBookSkills ();
					bookSkillData.ToObject (bytesData);
				}
				break;
			case eG2CType.G2c_NotifyEquipSkillData:
				{
					NetSkillBookEquip bookEquipData = new NetSkillBookEquip ();
					bookEquipData.ToObject (bytesData);
				}
				break;
			case  eG2CType.G2C_NotifyPowerInfo:
				{
					GSNotifyEngery engery = new GSNotifyEngery ();
					engery.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifyWeaponSkillSchedule:
				{
					NetNotifyWeaponSkillSchedule weaponSkillSchedule = new NetNotifyWeaponSkillSchedule ();
					weaponSkillSchedule.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifyWingInfo: //翅膀
				{
					GSNotifyWingInfo wingInfo = new GSNotifyWingInfo ();
					wingInfo.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifyArenaInfo: //竞技场信息
				{
					GSNotifyArenaInfo arenaInfo = new GSNotifyArenaInfo ();
					arenaInfo.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifyChallengerInfo: //服务器返回挑战列表变化
				{
					GSNotifyChallengerList info = new GSNotifyChallengerList ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifyHeroBankInfo: //通知英雄榜列表
				{
					GSNotifyHeroList info = new GSNotifyHeroList ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifyChallengeResult: //服务器通知战报信息
				{
					GSNotifyArenaResult info = new GSNotifyArenaResult ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifyHonorShop: //通知荣誉商店列表
				{
					GSNotifyShopInfo info = new GSNotifyShopInfo ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_NotifyChallenger: //通知竞技场挑战角色基础信息
				{
					GSNotifyChallegerInfo info = new GSNotifyChallegerInfo ();
					info.ToObject (bytesData);
					BattleArena.GetInstance ().m_kInfo = info;
				}
				break;
			case eG2CType.GSNotifySweepResult: //通知竞技场挑战角色基础信息
				{
					GSNotifySweepResult info = new GSNotifySweepResult ();
					info.ToObject (bytesData);
				}
				break;
			 
			case eG2CType.GSNotifyMultiInfo://通知多人副本信息
				{
					GSNotifyMultiInfo info = new GSNotifyMultiInfo ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyTeamInfo:
				{
					GSNotifyTeamInfo info = new GSNotifyTeamInfo ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyStartCountDown:
				{
					GSNotifyStartCountDown info = new GSNotifyStartCountDown ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyStartCountDownPlayerOffLine:
				{
					GSNotifyStartCountDownPlayerOffLine info = new GSNotifyStartCountDownPlayerOffLine ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyMultiResult:
				{
					GSNotifyMultiResult info = new GSNotifyMultiResult ();
					info.ToObject (bytesData);

					BattleMultiPlay.GetInstance ().OnMultiResult (info);
				}
				break;
			case eG2CType.GSNotifyPlayerRelive:
				{
					GCNotifyPlayerRelive info = new GCNotifyPlayerRelive ();
					info.ToObject (bytesData);

					BattleMultiPlay.GetInstance ().OnPlayerRelive (info);
					BattleWorldBoss.GetInstance ().OnPlayerRelive (info);
				}
				break;
			case eG2CType.GCNotifyTowerInfo:
				{
					GCNotifyTowerInfo info = new GCNotifyTowerInfo ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GCNotifyHistoryRank:
				{
					GCNotifyHistoryRank info = new GCNotifyHistoryRank ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GCNotifyCurRank:
				{
					GCNotifyCurRank info = new GCNotifyCurRank ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.G2C_GemChange:
				{
					NetLoginEquipmentInlay info = new NetLoginEquipmentInlay ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GCNotyfyWorldBossAwardList:
				{
					GSNotifyWorldBossAward info = new GSNotifyWorldBossAward ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GCNotyfyMedalInfo:
				{
					//服务器返回勋章信息
					NotifyMedalInfo info = new NotifyMedalInfo ();
					info.ToObject (bytesData);

				}
				break;
			case eG2CType.GSNotifyWorldBossOpen:
				{
					GSNotifyWorldBossOpen info = new GSNotifyWorldBossOpen ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyActivityClose:
				{
					GSNotifyActivityClose info = new GSNotifyActivityClose ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyAddFriendMessage:
				{
					//73
					NotifyAddFriendMessage info = new NotifyAddFriendMessage ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyFriendList:
				{
					//74
					NotifyFriendInfo friendInfo = new NotifyFriendInfo ();
					friendInfo.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyAddFriendList:
				{
					//75
					NotifyAddFriendList info = new NotifyAddFriendList ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyWorldBossDamageList:
				{
					GSNotifyWorldBossDamageList info = new GSNotifyWorldBossDamageList ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyWorldBossTemplateID:
				{
					GSNotifyWorldBossTemplateID info = new GSNotifyWorldBossTemplateID ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifySelectResult:
				{
					GCNotifySelectPlayerResult info = new GCNotifySelectPlayerResult ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyWorldBossUseItemResult:
				{
					GSNotifyWorldBossUseItemResult info = new GSNotifyWorldBossUseItemResult ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyPetData:
				{
					GSNotifyPetInfo info = new GSNotifyPetInfo ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyZhuiJiCount:
				{
					GSNotifyZhuiJiCount info = new GSNotifyZhuiJiCount ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyFuncOpenParam:
				{
					GSNotifyFuncOpenParam info = new GSNotifyFuncOpenParam ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyChannelCur:
				{
					GSNotifyChannelCur info = new GSNotifyChannelCur ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyChannelList:
				{
					GSNotifyChannelList info = new GSNotifyChannelList ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyGuideList:
				{
					GSNotifyGuideList info = new GSNotifyGuideList ();
					info.ToObject (bytesData);
				}
				break;
			case eG2CType.GSNotifyPandoraInfo:
				{
					GSNotifyPandoraInfo info = new GSNotifyPandoraInfo ();
					info.ToObject (bytesData);
				}
				break;
			default:
				break;
			}
		}
	}
}
  
		 
 