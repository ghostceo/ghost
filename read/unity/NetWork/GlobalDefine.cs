using System;

namespace NetGame
{
    /// <summary>
    /// 客户端<->服务端
    /// </summary>
    public enum eC2GType
    {
        C2G_Ping = 1,
        C2G_Login = 2,
        C2G_CreateRole = 3,
        C2G_SelectRole = 4,
        C2G_EnterScene = 5,
		C2G_AskMove = 6,
        C2G_Logout = 7,
        C2G_BuyGoods = 8,
        C2G_UseGoods = 9,
        C2G_PassGate = 10,
        C2G_EquipGoods  = 11,
        C2G_SaleGoods = 12,
		C2G_BoxDropGoods = 13,
        C2G_AskMoveGoods = 14,
        C2G_AskIntensifyEquip = 15,
        C2G_AskTransmitEquip = 16,
        C2G_AskRelive = 17,
        C2G_AskActiveSkillCard = 18,
        C2G_AskRefreshActiveSkillCard = 19,
        C2G_AskBuySkillPoint = 20,
		C2G_ReportExp = 21,
		C2G_ReportUseSkill = 22,
		C2G_ReportOBjectAppear = 23,
		C2G_ReportOBjectDisappear = 24,
		C2G_ReportObjectAction = 25,
		C2G_ReportObjectHurm = 26,
        C2G_AskCombineGem = 27,             ///宝石合成
        //C2G_AskUseGem = 28,
        C2G_AskWashEquip = 29,                   ///洗炼
        C2G_AskInlayGem    = 30,
        C2G_AskChapterAward = 31,
        C2G_AskUpgradeEquip = 32,
        C2G_AskDecomposeEquip = 33,
        C2G_AskGMSendAnnounce = 34, //请求发送公告
        C2G_AskChat = 35,		
		C2G_AskRankList = 36,
		C2G_AskEMailList = 37,
		C2G_AskReadEMail = 38,
		C2G_AskGetEMailPrize = 39, 
		C2G_AskRemoveEMail = 40,
        C2G_AskAchievementList = 41,
        C2G_AskAchievementPrize = 42,
        C2G_AskUseTitle = 43,
        C2G_ReportAchievementSchedule = 44,
		C2G_AskEnterTowerInstance = 45,
		C2G_ReportTowerInstanceScore = 46,
		C2G_AskTowerInstanceRank = 47,
		C2G_AskTowerInstanceAward = 48,
        C2G_AskBuyHPVessel = 49,
        C2G_AskBuyMPVessel = 50,
		C2G_AskShopTemp = 51,
		C2G_AskBuyShopItem = 52,
        C2G_AskChargeIOS = 53,
        C2G_AskAddGoods = 54,
        C2G_ReportHPVessel = 55,
        C2G_ReportMPVessel = 56,
        C2G_AskGMPassGate = 57,
        C2G_AskGMChangeLevel = 58,
        C2G_AskSystemNotice = 59, //请求系统公告
        C2G_ReportBug = 60,   //bug，建议，投诉反馈
        C2G_AskEnterGoblin = 61,
        C2G_AskGoblinTimes = 62,
        C2G_AskGoblinMultiBenefit = 63,
        C2G_AskBuyGoblinTimes = 64,
        C2G_ReportProduce = 65, //请求制作装备
        C2G_AcceptTask = 66, //接受任务
        C2G_SubmitTask = 67, //提交任务
        C2G_GMAcceptTask = 68, //GM接受任务
        C2G_GMSendAnnouncement = 69, //汇报任务进度
		C2G_AskWepon = 70,	//请求激活武器技能（升级）
		C2G_AskEquipWeaponSkill = 71,	//请求装备技能
        C2G_AskVipAward = 72,			//请求获取技能书数据
		C2G_AskBuyPower = 73,			//请求购买体力
		C2G_ReportScenario = 74,			//汇报剧情的进度
        C2G_ReportHurt = 75,			//汇报伤害
        C2G_AskCheckSkill = 76,		//请求检查技能CD
		C2G_AskCultureWing = 77,		//请求翅膀培养
		C2G_AskEvolutionWing = 78,		//翅膀进行升阶
		C2G_AskArenaInfo = 79,		//请求竞技场信息
		C2G_AskHeroList = 80,		//请求英雄榜列表
		C2G_AskChallenge = 81,		//请求挑战竞技场
		C2G_ReportChallengeResult = 82,		//汇报竞技场战斗结果
		C2G_AskBuyChallengeNum = 83,		//请求购买竞技场挑战次数
		C2G_AskHonorShopInfo = 84,		//请求荣誉商店信息
		C2G_AskBuyHonorItem = 85,		//请求购买荣誉商店物品
		C2G_AskWingInfo = 86,		//请求获得翅膀数据
		C2G_AskClearChallengeCD = 87, //请求清除竞技场挑战CD
		C2G_AskSyncPVPInfo = 88, //请求同步PVP信息
		C2G_AskUnsyncPVPInfo = 89, //请求取消PVP信息同步
		C2G_AskJoinPVPBattle = 90, //请求参加PVP战斗
		C2G_AskEncouragePVPBattle = 91, //请求鼓舞PVP战斗
		C2G_AskReceiveHeroRankAward = 92, //求领取英雄榜排名奖
		C2G_AskBeginSweep = 93, //请求开始扫荡
		C2G_AskStopSweep = 94, //请求停止扫荡
		C2G_AskAccelerateSweep = 95, //请求加速扫荡
        C2G_AskUseItem = 96, // 请求使用物品
		C2G_AskCreateTeam = 97,//请求创建队伍
		C2G_PreviewMulti = 98,//请求预览多人副本关卡
		C2G_AskAddTeam = 99,  //请求加入多人副本组
		C2G_QuickAddTeam = 100,//请求快速加入副本
		C2G_AskBeginFightMulti = 101, //请求开始多人副本战斗
		C2G_SendFormTeamMsg = 102,	//请求发送多人组队消息
		C2G_AskLeaveTeam = 103,	    //请求离开多人副本队伍
        C2G_ReportMultiPlayerDie = 104, //多人副本汇报角色死亡
		C2G_AskJoinActivity =105,		//请求加入活动
        C2G_AskMedalLevel=106,          // 请求勋章数据
        C2G_AskMedalLevelUp=107,        //请求升级勋章
        C2G_AskAddFriend = 108,       //请求添加好友
        C2G_VipFriend = 109,          //好友VIP功能
        C2G_AskFriendRecord = 110,      //请求好友列表
        C2G_AskUseItemInWorldBoss = 111,    //世界boss使用物品
        C2G_AskSelectPlayer=112,
		C2G_ReportAttackedTarget = 113, // 汇报打中某个对象
		C2G_AskPetData=114,			//请求宠物信息
		C2G_AskPetLevelUp=115,		//请求宠物进化
		C2G_AskZhuiJi =116,			//请求追缉
		C2G_AskCurZhuiJiCount=117,	//取得当前追缉次数 
        C2G_AskReceiveArenaAward=118,//请求获取竞技场奖励
		C2G_SelectPet=124,			//选中的宠物ID
        C2G_AskChannelList=125,         //请求游戏线路列表
        C2G_AskChannelChangel=126,      //请求改变游戏线路
        C2G_AskGuideComplate=127,       //发送新手引导完成
		C2G_ChallengePandora=129,	//请求挑战潘多拉
		C2G_ResetPandoraNum=130,	//重置潘多拉挑战次数
		C2G_ChallengeAllPandora=131,	//全部挑战
		C2G_OpenPandora=132,			//开启潘多拉宝盒
		C2G_AskEquipPet=133,		//请求装备宠物装备
    };

    
    /// <summary>
    /// 服务端<->客户端
    /// </summary>
    public enum eG2CType
    {
        G2C_LoginRet = 1,
        G2C_RoleList = 2,
        G2C_RoleCreateRet = 3,
        G2C_SelectRoleRet = 4,
        G2C_EnterSeceneRet = 5,
        G2C_BagInfo = 6,
        G2C_EquipmentInfo = 7,      ///delete
        G2C_GemChange = 8,      ////delete
        G2C_RoleFightProperty = 9,
        G2C_AssetChange = 10,
        G2C_RoleLevelChange = 11,
        G2C_RoleExpChange = 12,
        G2C_RoleCurProperty = 13,
        G2C_RoleChangeScene = 14,
        G2C_ErrorMssage = 15,
		G2C_RoleAppear = 16,
		G2C_ObjectDisappear = 17,
		G2C_ObjectMove = 18,
		G2C_ObjectStopAction = 19,
		G2C_RoleInfoChange = 20,
        G2C_NotifyRoleMapScheduleList = 21,
        G2C_NotifyDisplayGateIncome = 22,
        G2C_NotifySkillPointChange = 23,
        G2C_NotifyCurSkillInfo = 24,
        G2C_NotifyCanActiveSkillCardList = 25,
		G2C_NotifySkillReleased = 26,
		G2C_NotifyObjectAppear = 27,
		G2C_NotifyObjectDisappear = 28,
		G2C_NotifyTimedCounter = 29,
		G2C_NotifyObjectAction = 30,
		G2C_NotifyObjectHurm = 31,
        G2C_NotifyChatInfo = 32,
		G2C_NotifyRankList = 33,
		G2C_NotifyEMailList = 34,
		G2C_NotifyPetEquip = 35,
        G2C_NotifyAchievementChange = 36,
        G2C_NotifyTitleChange = 37,
		G2C_NotifyItemChange = 38,
		G2C_NotifyShopTemp = 39,
		G2C_NotifyChargeIOS = 40,
		G2C_ResponseNotice = 41, //系统公告、运维公告，客服信息的回复
        G2C_NotifyGoblinRemainTimes = 42,
        G2C_NotifyTaskInfo = 43,  //GS通知任务信息
        G2C_NotifySkillBookChange = 44,
		G2c_NotifyEquipSkillData = 45,
		G2C_NotifyPowerInfo = 46,  //通知体力信息
		G2C_NotifyWeaponSkillSchedule = 47,
		G2C_NotifyWingInfo = 48,  //通知客户端翅膀数据
		G2C_NotifyArenaInfo = 49,  //通知竞技场信息
		G2C_NotifyHeroBankInfo = 50,  //通知英雄榜列表
		G2C_NotifyChallengerInfo = 51,  //通知可挑战对象变化
		G2C_NotifyChallengeResult = 52,  //通知战报信息
		G2C_NotifyHonorShop = 53,   //通知荣誉商店列表
		G2C_NotifyChallenger = 54,   //通知挑战对象变化
		GSNotifyPVPRank = 55,   //通知PVP排行榜
		GSNotifyPVPLog = 56,   //通知PVP战报
		GSNotifyAddPVPParticipator = 57,   //通知增加PVP参与者
		GSNotifyRemovePVPParticipator = 58,   //通知移除PVP参与者
		GSNotifySweepResult = 59,   //通知扫荡结果
		GSNotifyMultiInfo = 60,		//通知多人副本信息
		GSNotifyTeamInfo = 61,		//通知当前副本的队伍信息
        GSNotifyStartCountDown = 62,    // 通知多人副本开始倒计时
        GSNotifyStartCountDownPlayerOffLine = 63,    // 通知多人副本开始倒计时有玩家掉线
        GSNotifyMultiResult = 64,    // 通知多人副本开始倒计时
        GSNotifyPlayerRelive = 65,    // 通知多人副本有玩家复活了
        GCNotifyTowerInfo=66,           //通知恶魔洞窟挑战信息
        GCNotifyHistoryRank=67,
        GCNotifyCurRank=68,
		GCNotyfyWorldBossAwardList = 69,	//通知世界BOSS获奖名单
        GCNotyfyMedalInfo=70,               //通知勋章数据ID
		GSNotifyWorldBossOpen = 71,		//通知世界boss开始了
		GSNotifyActivityClose = 72,		//通知活动结束了
        GSNotifyAddFriendMessage = 73,   //好友操作返回结果
        GSNotifyFriendList = 74 ,        //返回好友列表
        GSNotifyAddFriendList=75,      //通知好友操作的另一方
		GSNotifyWorldBossDamageList=76, //通知世界BOSS伤害名单
		GSNotifyWorldBossTemplateID=77,	//通知世界BOSS模板ID
        GSNotifySelectResult=78,        //查询玩家结果
		GSNotifyWorldBossUseItemResult=79,//得到玩家在世界boss中buff的次数
       	GSNotifyPetData =80,				//通知客户端当前宠物数据
		GSNotifyZhuiJiCount = 81,		//通知客户端当前追缉次数
		GSNotifyFuncOpenParam = 85,		//通知客户端功能开启参数信息
        GSNotifyChannelCur=87,          //返回当前游戏线路
        GSNotifyChannelList=88,         //返回频道列表
        GSNotifyGuideList=89,           //返回新手引导列表
		GSNotifyPandoraInfo=90,			//潘多拉相关信息
    };

    class GlobalDefine
    {
        /// <summary>
        /// 包头大小
        /// </summary>
        public const int _NetHeadLength = 8;
    }
	
	public class GlobalData
	{
		public int m_n32EnterSceneTimes = 0;
		
		static GlobalData s_pInstance = null;
		
		public static GlobalData GetInstance()
		{
			if (null == s_pInstance)
			{
				s_pInstance = new GlobalData();
			}
			return s_pInstance;
		}
	}
}
