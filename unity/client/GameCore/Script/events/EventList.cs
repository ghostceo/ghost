using UnityEngine;
using System.Collections;

public class EventList
{

	public static string TEST_EVENT_CENTER = "TEST_EVENT_CENTER";
	public static string GAME_HEART_BEAT = "GAME_HEART_BEAT";//游戏心跳,发往事件中心
	/**
		* 创角相关 
		*/		
	public static string CREATE_ROLE = "CREATE_ROLE";
	public static string CREATE_ROLE_FAIL = "CREATE_ROLE_FAIL";
		
	/**
		* 角色及配置文件加载完成 
		*/		
	public static string ROLE_BODY_LOAD_COMPLETE = "ROLE_BODY_LOAD_COMPLETE";
		
	/**
		*	场景相关
		* */
	public static string SCENE_CONFIG_LOADED = "SCENE_CONFIG_LOADED";
	/**
		* 请求在场景里增加显示对象
		*/		
	public static string ADD_SCENE_ELEMENT = "ADD_SCENE_ELEMENT";
		
	/**
		* 舞台相关
		* */
	public static string STAGE_RESIZE_EVENT = "STAGE_RESIZE_EVENT";
	/**
		* 舞台焦点事件 
		*/		
	public static string STAGE_FOCUS_EVENT = "STAGE_FOCUS_EVENT";
		
	/**
		* 主角接触到传送点
		*/		
	public static string ROLE_TOUCH_TRANS = "ROLE_TOUCH_TRANS";
		
	/**
		* 播放音效 
		*/
	public static string PLAY_SOUND_EFFECT = "PLAY_SOUND_EFFECT";
	/**
		* 游戏设置
		*/		
	public static string SOUND_BT_CHANGE = "SOUND_BT_CHANGE";
	public static string CLOSE_SOUND = "CLOSE_SOUND";
	public static string OPEN_SOUND = "OPEN_SOUND";
	public static string SHOW_BLOOD = "SHOW_BLOOD";
		
	public static string SHOW_OTHER_PLAYER = "SHOW_OTHER_PLAYER";
		
	public static string HIDE_OTHER_PLAYER = "HIDE_OTHER_PLAYER";
		
		
	public static string LAIRD_TOWER_REQUEST = "LAIRD_TOWER_REQUEST";//领主之塔刷新
	/**
		*技能相关 
		*/		
	public static string SKILL_GROUP_CD = "SKILL_GROUP_CD";
		
	/** 佣兵加载完成*/
	public static string SOLDIER_LOAD_COMPLETE = "SOLDIER_LOAD_COMPLETE";
		
	/** 佣兵技能cd*/
	public static string SKILL_SOLDIER_GROUP_CD = "SKILL_SOLDIER_GROUP_CD";
	/** 技能列表*/
	public static string SKILL_LIST = "SKILL_LIST";
	/** 技能快捷列表*/
	public static string SKILL_SHORTCUT_LIST = "SKILL_SHORTCUT_LIST";
		
	public static string SKILL_CLEAR_SOLDIER_USE_COUNT = "SKILL_CLEAR_SOLDIER_USE_COUNT";
		
	public static string SKILL_CLOSE_SHORTCUT_PANEL = "SKILL_CLOSE_SHORTCUT_PANEL";
		
	public static string SKILL_OPEN_SHORTCUT_PANEL = "SKILL_OPEN_SHORTCUT_PANEL";
		
	public static string SKILL_SHORTCUT_UPDATE = "SKILL_SHORTCUT_UPDATE";
		
	public static string SKILL_OPEN_SKILL_PANEL = "SKILL_OPEN_SKILL_PANEL";
		
	public static string SKILL_PLAY_SKILL_CD_EFFECT = "SKILL_PLAY_SKILL_CD_EFFECT";
		
	public static string SKILL_CLOSE_SKILL_PANEL = "SKILL_CLOSE_SKILL_PANEL";
		
	/** 显示升级的tip*/
	public static string SKILL_SHOW_SHENGJI_TIP = "SKILL_SHOW_SHENGJI_TIP";
		
	/** 显示升阶的tip*/
	public static string SKILL_SHOW_SHENGJIE_TIP = "SKILL_SHOW_SHENGJIE_TIP";
	/** 技能面板 隐藏升级、升阶tip*/
	public static string SKILL_HIDE_TIP = "SKILL_HIDE_TIP";
		
	/** 升级技能*/
	public static string SKILL_SHENGJI = "SKILL_SHENGJI";
		
	/** 升阶技能*/
	public static string SKILL_SHENGJIE = "SKILL_SHENGJIE";
		
	/** 添加佣兵*/
	public static string SOLDIER_ADD = "SOLDIER_ADD";
	/** 佣兵扣血*/
	public static string SOLDIER_DEDUCT_BLOOD = "SOLDIER_DEDUCT_BLOOD";
		
	/** 佣兵 主角释放技能飘字*/
	public static string SKILL_SOLDIER_FLOAT_MSG = "SKILL_SOLDIER_FLOAT_MSG";
		
	/** 自动装备技能*/
	public static string SKILL_AUTO_EQUIT_SKILL = "SKILL_AUTO_EQUIT_SKILL";
	/**
		* 动作配置加载完之后 
		*/		
	public static string ACTION_CONFIG_LOADED = "ACTION_CONFIG_LOADED";
	/**
		* 技能配置加载完之后 
		*/
	public static string SKILL_CONFIG_LOADED = "SKILL_CONFIG_LOADED";
	/**
		* 使用技能 ,技能公共CD也可以用这个,私有CD也可以用这个
		*/		
	public static string USE_SKILL = "USE_SKILL";
	/**
		* 其它人使用技能,包括除主角外的人和怪物 
		*/		
	public static string OTHER_USE_SKILL = "OTHER_USE_SKILL";
	/**
		* NPC被点击事件 
		*/		
	public static string NPC_CLICK = "NPC_CLICK_MSG";
	/**
		* 怪物被点击 
		*/		
	public static string MONSTER_CLICK = "MONSTER_CLICK_MSG";
	/**
		* 人物被点击 
		*/		
	public static string ROLE_CLICK = "ROLE_CLICK_MSG";
	/**
		* 城镇怪物被点击 
		*/		
	public static string CITY_MONSTER_CLICK = "CITY_MONSTER_CLICK_MSG";
	/**
		*键盘按下消息 
		*/		
	public static string KEYBOARD_SMIUL_DOWN = "KEYBOARD_SIMUL_DOWN";
	/**
		* 模拟玩家按下键盘消息 
		*/		
	public static string KEYBOARD_SIMUL = "KEYBOARD_SIMUL";
	/**
		* 模拟玩家按上键盘消息 
		*/		
	public static string KEYBOARD_SIMUL_UP = "KEYBOARD_SIMUL_UP";
	/**
		* 玩家移动消息
		*/		
	public static string ROLE_MOVE_INFO = "ROLE_MOVE_INFO";
	/**
		* 玩家状态同步消息
		*/		
	public static string SYN_ROLE_STATUS = "SYN_ROLE_STATUS";
	/**
		* 怪物移动消息 
		*/		
	public static string SIMUL_MONSTER_MOVE = "SIMUL_MONSTER_MOVE";
	/**
		* 怪物使用技能消息
		*/		
	public static string SIMUL_MONSTER_USESKILL = "SIMUL_MONSTER_USESKILL";
	/**
		* 场景物件使用技能消息
		*/		
	public static string ARTICLE_USESKILL = "ARTICLE_USESKILL";
	/**
		* 人物被攻击或者击中一个怪物 
		*/		
	public static string ATTACK_ROLE_OR_MON = "ATTACK_MON";
	/**
		* 人物或者怪物死掉 
		* 在SkillMan里单机打怪的时候会派发
		*/		
	public static string ROLE_MON_DIE = "ROLE_MON_DIE";
	/**
		* 角色在死亡时会派发 
		*/		
	public static string ROLE_DIE = "ROLE_DIE_MSG";
	/**
		* 角色被析构时会派发 
		*/		
	public static string ROLE_DISPOSE = "ROLE_DISPOSE_MSG";
	/**
		* 怪物dispose的时候才会执行
		*/		
	public static string MONSTER_DISPOSE = "MONSTER_DISPOSE";
	/**
		* 怪物死亡,被杀或者其它方式被干掉,暂时用于任务杀怪监听
		*/		
	public static string MONSTER_DIE = "MONSTER_DIE";
	/**
		* 佣兵死亡,被杀或者其它方式被干掉,暂时用于任务杀怪监听
		*/		
	public static string SOLDIER_DISPOSE = "SOLDIER_DISPOSE";
	/**
		* 显示或隐藏自动寻路 
		*/		
	public static string SHOW_HIDE_AUTO_FINDPATH = "SHOW_HIDE_AUTO_FINDPATH";
	/**
		* 显示伤害数字
		*/		
	public static string SHOW_HARM_NUMBER = "SHOW_HARM_NUMBER";
	/**
		* 显示连击数 
		*/		
	public static string SHOW_COMBO_NUMBER = "SHOW_COMBO_NUMBER";
	/**
		* 游戏是否在焦点状态 
		*/		
	public static string GAME_ACTIVATE = "GAME_ACTIVATE";
	/**
		* 游戏是否在焦点状态 
		*/	
	public static string GAME_DEACTIVATE = "GAME_DEACTIVATE";
		
	/**
		*	组队相关
		**/
	/**点击加入队伍*/
	public static string TEAM_JOIN_CLICK = "TEAM_JOIN_CLICK";
	/**进入队伍房间*/
	public static string TEAM_ENTER_ROOM = "TEAM_ENTER_ROOM";
	/**更新队伍列表*/
	public static string TEAM_UPDATE_TEAMLIST = "TEAM_UPDATE_TEAMLIST";
	/**更新队长玩家*/
	public static string TEAM_CHANGE_LEADER = "TEAM_CHANGE_LEADER";
	/**离开队伍*/
	public static string TEAM_LEAVE = "TEAM_LEAVE";
	/**创建队伍*/
	public static string TEAM_CREATE = "TEAM_CREATE";
	/**解散队伍*/
	public static string TEAM_BREAK = "TEAM_BREAK";
	/**其他玩家离开队伍*/
	public static string TEAM_NOTIFY_LEAVE = "TEAM_NOTIFY_LEAVE";
	/**其他玩家进入队伍*/
	public static string TEAM_NOTIFY_JOIN = "TEAM_NOTIFY_JOIN";
	/**
		*队伍成员刷新 
		*/		
	public static string TEAM_MEMBER_REFRESH = "TEAM_MEMBER_REFRESH";
		
	/**被通知队伍解散*/
	public static string TEAM_NOTIFY_BREAK = "TEAM_NOTIFY_BREAK";
	/**被踢出队伍*/
	public static string TEAM_NOTIFY_KICKOUT = "TEAM_NOTIFY_KICKOUT";
	/**通知队伍密码被修改*/
	public static string TEAM_NOTIFY_MODIFY_PWD = "TEAM_NOTIFY_MODIFY_PWD";
	/**队伍成员状态变更*/
	public static string TEAM_MEMBER_STATUS_CHANGE = "TEAM_MEMBER_STATUS_CHANGE";
	/**收到组队邀请*/
	public static string TEAM_INQUIRY_INVITE_MEMBER = "TEAM_INQUIRY_INVITE_MEMBER";
	/**接受组队邀请，进入队伍*/
	public static string TEAM_ACCEPT_INVITE = "TEAM_ACCEPT_INVITE";
	/**收到队员成为队长的申请*/
	public static string TEAM_INQUIRY_BECOME_LEADER = "TEAM_INQUIRY_BECOME_LEADER";
	/**更新邀请面板列表信息*/
	public static string TEAM_UPDATE_INVITE_LIST = "TEAM_UPDATE_INVITE_LIST";
	/**重新进入自动组队队列*/
	public static string TEAM_ENTER_QUEUE_AGAIN = "TEAM_ENTER_QUEUE_AGAIN";
	/**提升队长通知*/
	public static string TEAM_PROMOTE_LEADER = "TEAM_PROMOTE_LEADER";
	/**再次匹配打开面板*/
	public static string TEAM_START_AGAIN_MACTH = "TEAM_START_AGAIN_MACTH";
	/**自动匹配等待人数*/
	public static string TEAM_WAIT_PEOPLE = "TEAM_WAIT_PEOPLE";
	/**再次匹配使用数据*/
	public static string TEAM_MATCH_AGAIN = "TEAM_MATCH_AGAIN";
	/**隐藏自动匹配面板*/
	public static string TEAM_HIDE_MACTH = "TEAM_HIDE_MACTH";
	/**自动匹配失败，不愿意再次匹配*/
	public static string TEAM_NOT_MACTH = "TEAM_OPEN_MACTH";
	/**清空组队主面板信息*/
	public static string TEAM_DISPOSE_MAIN_PANEL = "TEAM_DISPOSE_MAIN_PANEL";
		
		
	/**更新其他队员血量信息*/
	public static string TEAM_UPDATE_OHTHERS_BLOOD = "TEAM_UPDATE_OHTHERS_BLOOD";
	/**更新其他队员输出信息*/
	public static string TEAM_UPDATE_OHTHERS_HURT = "TEAM_UPDATE_OHTHERS_HURT";
	/**更新玩家自己的输出信息*/
	public static string TEAM_UPDATE_MYSELF_HURT = "TEAM_UPDATE_MYSELF_HURT";
		
		
	/** 自动战斗*/
	public static string AUTO_FIGHT = "AUTO_FIGHT";
	/**
		*副本相关
		**/
	/**副本离开成功*/
	public static string LEAVE_DUNGEON_SUCCESS = "LEAVE_DUNGEON_SUCCESS";
	public static string ENTER_DUNGEON_SUCCESS = "ENTER_DUNGEON_SUCCESS";
	/**
		*副本杀怪获取掉落物的事件 
		*/		
	public static string PICK_UP_LOOT_ITEM = "pickUpLootItem";
		
	/**
		*	背包相关
		* */
	public static string BAG_REFRESH_ITEM_LIST = "BAG_REFRESH_ITEM_LIST";
	public static string BAG_ITEM_TO_STORAGE = "BAG_ITEM_TO_STORAGE";
	public static string BAG_ITEM_TO_HERO = "BAG_ITEM_TO_HERO";
	public static string BAG_STATE_CHANGE = "BAG_STATE_CHANGE";
	public static string BAG_REFRESH_BODY_EQUIP = "BAG_REFRESH_BODY_EQUIP";
	public static string FRESH_REBUY_LIST = "FRESH_REBUYLIST";
	/** 格子倒计时结束 */
	public static string BAG_GRID_TIME_OVER = "BAG_GRID_TIME_OVER";
	public static string BAG_RECOVER_GRAY = "BAG_RECOVER_GRAY";
		
	public static string BAG_REFRESH_GAME_MONEY = "BAG_REFRESH_GAME_MONEY";
		
	public static string BAG_FULL = "BAG_FULL";
		
	/**
		*	个人仓库相关
		* */
	public static string PERSONAL_STORAGE_GET_ITEM_LIST = "PERSONAL_STORAGE_GET_ITEM_LIST";
		
	public static string PERSONAL_STORAGE_RECOVER_NORMAL_STATE = "PERSONAL_STORAGE_RECOVER_NORMAL_STATE";
		
	/**
		*	回购相关
		* */
	public static string REDEMPTION_REFRESH_TAB = "REDEMPTION_REFRESH_TAB";
	public static string REDEMPTION_REFRESH_DATA = "REDEMPTION_REFRESH_DATA";
	public static string REDEMPTION_REPURCHASE_SHOP_ITEM  = "REDEMPTION_REPURCHASE_SHOP_ITEM";
	public static string REDEMPTION_BUY_SHOP_ITEM = "REDEMPTION_BUY_SHOP_ITEM";
		
	/**
		*	道具合成相关
		* */
	public static string PROPS_COMPOSE_EQUIP_CHOOSE = "PROPS_COMPOSE_EQUIP_CHOOSE";
	public static string PROPS_COMPOSE_REFRESH_ITEM = "PROPS_COMPOSE_REFRESH_ITEM";
		
	public static string TASK_SPACE_KEY_TRIGGER = "taskSpaceKeyTrigger";
		
	/**
		*	邮件相关
		* */
	public static string MAIL_GET_NEW_NUMBER_REQUEST = "MAIL_GET_NEW_NUMBER_REQUEST";
	public static string MAIL_GET_LIST = "MAIL_GET_LIST";
	public static string MAIL_READ_ITEM = "MAIL_READ_ITEM";
	public static string MAIL_NEW_MAIL = "MAIL_NEW_MAIL";
	public static string MAIL_HIDE_OPEN_MAIL_BTN = "MAIL_HIDE_OPEN_MAIL_BTN";
		
	/**
		*	防沉迷相关
		* */
	public static string ANTIADDICTION_ICON_CONTAINER = "ANTIADDICTION_ICON_CONTAINER";
	/**
		*  我要变强面板相关 
		*/		
	public static string SHOW_STRENGTH_PANEL = "SHOW_STRENGTH_PANEL";
	public static string HIDE_STRENGTHENPANEL = "HIDE_STRENGTHENPANEL";
	/** 
		*  物品展示相关
		*/
	public static string PUBLIC_ITEM_EXHIBIT = "PUBLIC_ITEM_EXHIBIT";
	public static string PRIVATE_ITEM_EXHIBIT = "PRIVATE_ITEM_EXHIBIT";
		
	/**
		*商城相关 
		*/		
	public static string REQUEST_SHOP_LIMITGOODS = "REQUEST_SHOP_LIMITGOODS";
		
	/**
		*龙魂相关。 
		*/
		
	public static string DRAGON_SOUL_SHIFT_VIEW = "DRAGON_SOUL_SHIFT_VIEW";//切换界面
	public static string DRAGON_SOUL_GENERATE_LIST = "DRAGON_SOUL_GENERATE_LIST";//生成栏列表
		
		
	public static string DRAGON_SOUL_USE_LIST = "DRAGON_SOUL_USE_LIST";//装备栏列表
	public static string DRAGON_SOUL_CLASSIFY_LIST = "DRAGON_SOUL_CLASSIFY_LIST";//分类栏列表
	public static string DRAGON_SOUL_STORE_LIST = "DRAGON_SOUL_STORE_LIST";//储存栏列表
	public static string DRAGON_SOUL_RUBBISH_LIST = "DRAGON_SOUL_RUBBISH_LIST";//垃圾栏列表
		
	public static string DRAGON_SOUL_USE_UPDATE = "DRAGON_SOUL_USE_LIST";//装备栏
	public static string DRAGON_SOUL_CLASSIFY_COUNT_CHANGE = "DRAGON_SOUL_CLASSIFY_COUNT_CHANGE";//分类栏数量改变
		
	public static string DRAGON_BUTTON_SOUL_STATE_CHANGE = "DRAGON_BUTTON_SOUL_STATE_CHANGE";//按钮激活状态的改变
		
	public static string DRAGON_SCRAP_CHANGE = "DRAGON_SCRAP_CHANGE"; //魂素改变
	/** 
		*  好友面板相关
		*/
	public static string GOODFRIEND_LIST = "GOODFRIEND_LIST";
	public static string BLACKFRIEND_LIST = "BLACKFRIEND_LIST";
	public static string GUILDFRIEND_LIST = "GUILDFRIEND_LIST";
	public static string TEMPORARYFRIEND_LIST = "TEMPORARYFRIEND_LIST";
		
	public static string SEARCH_INFO = "SEARCH_INFO";
	/** 黑名单列表更新 （上线 下线  移除 添加）*/
	public static string BLACKFRIEND_UPDATA = "BLACKFRIEND_UPDATA";
	/** 好友列表更新 （上线 下线  移除 添加）*/
	public static string GOODRIEND_UPDATA = "GOODRIEND_UPDATA";
		
	public static string TEMPORARYFRIEND_UPDATA = "TEMPORARYFRIEND_UPDATA";
	/**
		* 给好友发送消息
		*/		
	public static string FRIEND_ADD_MESSAGE = "FRIEND_ADD_MESSAGE";
	/**
		*关闭私聊面板 
		*/		
	public static string CLOSE_PRIVATE_PANEL = "CLOSE_PRIVATE_PANEL";
	/**
		* 好友发来新的消息
		*/		
	public static string RECEIVE_NEW_PRIVATE = "RECEIVE_NEW_PRIVATE";
	/**
		* 接收好友添加请求
		*/
	public static string RECEIVE_ADD_FRIEND = "RECEIVE_ADD_FRIEND";
		
	public static string REMOVE_ONE_PRIVATE_TAB_NAME = "REMOVE_ONE_PRIVATE_TAB_NAME";
		
	public static string REMOVE_ALL_PRIVATE_TAB_NAME = "REMOVE_ALL_PRIVATE_TAB_NAME";
		
	public static string ADD_ONE_PRIVATE_TAB_NAME = "ADD_ONE_PRIVATE_TAB_NAME";
	/** 选择聊天选项卡*/
	public static string SELECT_TAB_NAME = "SELECT_TAB_NAME";
	/** 提示来信息，闪亮一下*/
	public static string FLUSH_TAB_NAME = "FLUSH_TAB_NAME";
	/**好友动态列表 */
	public static string FRIEND_DYNAMIC_LIST = "FRIEND_DYNAMIC_LIST";
	/**好友动态更新*/
	public static string FRIEND_DYNAMIC_UPDATE = "FRIEND_DYNAMIC_UPDATE";
	/**好友动态推送*/
	public static string FRIEND_TRENDS_ARRIVE = "FRIEND_TRENDS_ARRIVE";
	/**好友动态历史记录列表*/
	public static string FRIEND_DYNAMIC_HISTROY_LIST = "FRIEND_DYNAMIC_HISTROY_LIST";
	/**选择要送花的好友名字*/
	public static string CHOOSE_GIVE_FLOWER_FRIEND_NAME = "CHOOSE_GIVE_FLOWER_FRIEND_NAME";
	/**处理关闭好友通知面板后忽略所有的消息*/
	public static string FRIEND_ADD_HANDLER = "FRIEND_ADD_HANDLER";
	/**私聊提示*/
	public static string FRIEND_PRIVATE_TIP = "FRIEND_PRIVATE_TIP";
		
	/**
		*庄园相关 
		*/		
	/**我的庄园列表*/
	public static string MYMANOR_LIST = "MYMANOR_LIST";
	/**好友的庄园列表*/
	public static string FRIENDMANOR_LIST = "FRIENDMANOR_LIST";
	/**土地更新*/
	public static string MANOR_LAND_UPDATE = "MANOR_LAND_UPDATE";
	/**庄园神像更新*/
	public static string MANOR_GODDESS_UPDATE = "MANOR_GODDESS_UPDATE";
	/**庄园信息更新*/
	public static string MANOR_INFO_UPDATE = "MANOR_INFO_UPDATE";
	/**庄园土地升级*/
	public static string MANOR_LAND_UPGRADE = "MANOR_LAND_UPGRADE";
	/**种菜鼠标点击通知*/
	public static string MANOR_PLANT_SEED = "MANOR_PLANT_SEED";
	/**庄园面板要关掉了，通知庄园里的其他已打开的面板关闭*/
	public static string MANOR_PANEL_CLOSE = "MANOR_PANEL_CLOSE";
	/**庄园日志列表*/
	public static string MANOR_LOG_LIST = "MANOR_LOG_LIST";
	/**显示鼠标图标*/
	public static string MANOR_SHOW_MOUSE_ICON = "MANOR_SHOW_MOUSE_ICON";
		
	/**
		*在线礼包通知 
		*/		
	public static string ONLINE_GIFT_NOTICE = "ONLINE_GIFT_NOTICE";
	/**
		*在线礼包活动再次开启
		*/
	public static string ONLINE_GIFT_OPEN = "ONLINE_GIFT_OPEN";
		
		
	/**
		* 在线巡逻通知 
		*/		
	public static string ONLINE_PATROL_NOTICE = "ONLINE_PATROL_NOTICE";
	public static string ONLINE_PATROL_REFRESH_EXP = "ONLINE_PATROL_REFRESH_EXP";
		
		
	/**
		* vip相关 
		*/		
	/**VIP可以获取礼包，用于通知MyRoleHeadPanel发光*/
	public static string VIP_CAN_GET_AWARD = "VIP_CAN_GET_AWARD";
	public static string VIP_AWARD_STATE = "VIP_AWARD_STATE";
		
	/**
		*我要变强系统相关 
		*/		
	/**我要资源界面右边数据的更新*/
	public static string WANT_RESOURCE_UPDATE = "WANT_RESOURCE_UPDATE";
		
	public static string WANT_STRONG_INFO_LIST = "WANT_STRONG_INFO_LIST";
	public static string WANT_STRONG_ITEM_LIST = "WANT_STRONG_ITEM_LIST";
		
		
	/**
		*怪物攻城 
		*/		
	/**怪物攻城猎杀点数更新*/
	public static string BANDIT_POINT_UPDATE = "BANDIT_POINT_UPDATE";
	/**怪物攻城猎杀已领取的宝箱*/
	public static string BANDIT_GIFT_LIST = "BANDIT_GIFT_LIST";
		
		
	/**
		* 创世神器 
		*/		
	/**创世神器Info列表*/
	public static string CREATION_ARTIFACT_INFO_LIST = "CREATION_ARTIFACT_INFO_LIST";
		
		
		
		
	/** 怪物血条*/
	public static string BLOOD_ANIMATION_PLAY_COMPLETE = "BLOOD_ANIMATION_PLAY_COMPLETE";
		
	public static string BLOOD_GRADIENT_ANIMATION_PLAY_COMPLETE = "BLOOD_GRADIENT_ANIMATION_PLAY_COMPLETE";
	public static string BLOOD_DEDUCT_ANIMATION_PLAY_COMPLETE = "BLOOD_DEDUCT_ANIMATION_PLAY_COMPLETE";
	public static string MONSTER_BLOOD_PANEL = "MONSTER_BLOOD_PANEL";
		
	public static string MONSTER_BLOOD_DIE = "MONSTER_BLOOD_DIE";
		
	/**
		*系统右下角操作提示
		*/
	public static string SYS_OPERATE_NOTI = "SYS_OPERATE_NOTI";
	public static string SYS_OPERATE_NOTI_CLOSE = "SYS_OPERATE_NOTI_CLOSE";
		
		
	/**
		*   活动图标相关
		*/
	public static string ICON_SHOW_NOCITICATION = "ICON_SHOW_NOTIFICATION";
	public static string ICON_HIDE_NOTIFICATION = "ICON_HIDE_NOTIFICATION";
	/**
		*   答题相关
		*/
	public static string SHOW_NEW_QUESTION_ANSWER = "SHOW_NEW_QUESTION_ANSWER";
	public static string RIGHT_RESULT_AWARD = "RIGHT_RESULT_AWARD";
		
	/**
		*  福利面板相关— 收到昨日资源挽回
		*/
	public static string SHOW_BEFORE_RESOURCE = "SHOW_BEFORE_RESOURCE";
	public static string SHOW_NONE_RESOURCE = "SHOW_NONE_RESOURCE";
	/**
		*   副本小地图相关
		*/
	public static string UPDATE_DUNGEON_MAP = "UPDATE_DUNGEON_MAP";
		
	/** 序章开始*/
	public static string PROLOGO_START = "PROLOGO_START";
	/** 序章结束*/
	public static string PROLOGO_END = "PROLOGO_END";
	/** 播放序章*/
	public static string PROLOGO_STEP = "PROLOGO_STEP";
		
	/** 龙灵镶嵌*/
	public static string DRAGON_SPIRIT_INLAIDGEM = "DRAGON_SPIRIT_INLAIDGEM";
		
	//////////公会相关////////////
		
	/** 公会主页信息*/
	public static string GUILD_HOME_INFO = "GUILD_HOME_INFO";
	/** 公会财富变更*/
	public static string GUILD_WEALTH = "GUILD_WEALTH";
		
	/**
		* 黄字提示 
		*/		
	public static string FLOAT_BROAD_CAST_CONTENT = "FLOAT_BROAD_CAST_CONTENT";
	/**
		* 能量不足,1为使用技能量的能量不足 
		*/		
	public static string LACK_OF_ENERGY = "LACK_OF_ENERGY";
		
	/**
		* 宝石合成 ,转换 
		*/		
	public static string SMITH_SHOP_GEM_TREE_LIST_CLICK = "SMITH_SHOP_GEM_TREE_LIST_CLICK";
	public static string SMITH_SHOP_TREE_LIST_REFRESH = "SMITH_SHOP_TREE_LIST_REFRESH";
	/**
		* 进入副本 关闭任务面板
		*/		
	public static string HIDE_TASK_PANEL = "HIDE_TASK_PANEL";
	/**
		*首次登陆，显示城镇
		*/		
	public static string SHOW_CITY_FIRST = "SHOW_CITY_FIRST";
		
	public static string HIDE_BLOOD_PANEL = "HIDE_BLOOD_PANEL";
		
	public static string WORLDBOSS_UPDATE_RANKLIST = "UPDATE_RANKLIST";
	public static string WORLDBOSS_SHOWREVIVEPANEL = "WORLDBOSS_SHOWREVIVEPANEL";
	public static string WORLDBOSS_START = "WORLDBOSS_START";
	public static string WORLDBOSS_STOP = "WORLDBOSS_STOP";
	public static string WORLDBOSS_UPDATE_CRIT = "WORLDBOSS_UPDATE_CRIT";
	public static string WORLDBOSS_CRIT_TO_MAX = "WORLDBOSS_CRIT_TO_MAX";
	public static string WORLDBOSS_SHOW_GOD_PANEL = "WORLDBOSS_SHOW_GOD_PANEL";
	public static string WORLDBOSS_HIDE_GOD_PANEL = "WORLDBOSS_HIDE_GOD_PANEL";
	public static string WORLDBOSS_ENTER = "WORLDBOSS_ENTER";
	public static string WORLDBOSS_LEAVE = "WORLDBOSS_LEAVE";
		
	public static string GAME_LOAD_PROGRESS = "GameLoadProgress";
	public static string GAME_LOAD_COMPLETE = "GameLoadComplete";
		
	public static string TOWN_MAP_LOAD = "townMapLoad";
	public static string TOWN_MAP_LOAD_COMPLETE = "townMapLoadComplete";
	public static string FIGHT_MAP_LOAD = "fightMapLoad";
	public static string FIGHT_MAP_LOAD_COMPLETE = "fightMapLoadComplete";
		
	public static string TWEEN_HEROPANEL_TO_BAGPANEL = "TWEEN_HEROPANEL_TO_BAGPANEL";
	public static string TWEEN_BAGPANEL_TO_HEROPANEL = "TWEEN_BAGPANEL_TO_HEROPANEL";
		
	public static string MONSTER_BATCH_CHANGE = "MonsterBatchChange";
		
	public static string WORLDMAP_CLOSE_MAP = "WORLDMAP_CLOSE_MAP";
	public static string WORLDMAP_SHOW_AREA = "WORLDMAP_SHOW_AREA";
	/** 请求进入城镇 */
	public static string WORLDMAP_ENTER_SCENE = "WORLDMAP_ENTER_SCENE";
	public static string WORLDMAP_RESET_ROLE = "WORLDMAP_RESET_ROLE";
		
		
	public static string BILL_BOARD_SELF_RANK = "BILL_BOARD_SELF_RANK";
	public static string BILL_BOARD_WHO_BE_PRAISE = "BILL_BOARD_WHO_BE_PRAISE";
		
	public static string AUCTION_REFRESH_LIST = "AUCTION_REFRESH_LIST";
	public static string AUCTION_BAG_TO_SHOP = "AUCTION_BAG_TO_SHOP";
	public static string AUCTION_SHOP_TO_BAG = "AUCTION_SHOP_TO_BAG";
	public static string AUCTION_MANU_LIST_REFRESH = "AUCTION_MANU_LIST_REFRESH";
		
	public static string AUCTION_BAG_PANEL = "AUCTION_BAG_PANEL";
		
	public static string MY_ROLE_LOAD_PROGRESS = "MyRoleLoadProgress";
		
		
	public static string PLOT_FACE_HIDE = "PLOT_FACE_HIDE";
	public static string PLOT_FACE_SHOW = "PLOT_FACE_SHOW";
		
	public static string PET_TRANSFORM = "PetTransform";
	public static string PET_CANCLE_TRANSFORM = "PetCancleTransform";
		
		
	/**
		* 接收主面板闪烁的消息
		*/		
	public static string MAIN_UP_DOWN = "MAIN_UP_DOWN";
	/**
		*新系统开启 
		*/		
	public static string NEW_SYSTEM_OPEN = "newSystemOpen";
	/**
		*新系统图标往哪里飞行的信息 
		*/		
	public static string SYSTEM_ICON_FLY_INFO = "systemIconFlyInfo";
		
	/**
		* 主面板对应按钮停止弹跳
		*/		
	public static string MAIN_STOP_DOWN = "MAIN_STOP_DOWN";
	public static string MAIN_STOP_DOWN_BTN = "MAIN_STOP_DOWN_BTN";
		
	/**
		* 技能提示槽打开面板按钮
		*/	
	public static string SHOW_SLOT_BTN = "SHOW_SLOT_BTN";
	public static string HIDE_SLOT_BTN = "HIDE_SLOT_BTN";
		
	public static string HIDE_SLOT_BY_BTN_NAME = "HIDE_SLOT_BY_BTN_NAME";
		
		
	/**
		* 登录奖励
		*/	
	public static string LOGIN_AWARD_LIST = "LOGIN_AWARD_LIST";
	public static string DARGON_AWARD_LIST = "DARGON_AWARD_LIST";
	public static string RESOUCEBACK_AWARD_LIST = "RESOUCEBACK_AWARD_LIST";
		
	/**
		* 聊天
		*/
	public static string CHAT_ADD_MESSAGE = "CHAT_ADD_MESSAGE";
	public static string CHAT_ADD_SYSMESSAGE = "CHAT_ADD_SYSMESSAGE";
	public static string CHAT_CHANGE_VIEW = "CHAT_CHANGE_VIEW";
		
	/**
		* 航海
		*/
		
	/** 添加一只船 */
	public static string SAIL_ADD_PLAYER = "SAIL_ADD_PLAYER";
	/** 删除一只船 */
	public static string SAIL_REMOVE_PLAYER = "SAIL_REMOVE_PLAYER";
	/** 获取所有船的列表*/
	public static string SAIL_BOAT_LIST = "SAIL_BOAT_LIST";
	/** 某只船航海完成 */
	public static string SAIL_FINISH = "SAIL_FINISH";
	public static string SAIL_REFRESH_LOG = "SAIL_REFRESH_LOG";
	public static string SAIL_HAS_NEW_LOG = "SAIL_HAS_NEW_LOG";
	/** 我的商船模块的数据信息 */
	public static string SAIL_REFRESH_SHIP = "SAIL_REFRESH_SHIP";
	/** 市场交易刷新 */
	public static string SAIL_REFRESH_MARKET_LIST = "SAIL_REFRESH_MARKET_LIST";
	public static string SAIL_CHANGE_SALISTATE = "SAIL_CHANGE_SALISTATE";
	public static string SAIL_CHANGE_SALITIME = "SAIL_CHANGE_SALITIME";
	public static string SAIL_CHANGE_ATTACKCDTIME = "SAIL_CHANGE_ATTACKCDTIME";
	/** 护航申请面板 */
	public static string SAIL_INVITE_REFRESH = "SAIL_INVITE_REFRESH";
	public static string INVITE_ITEM_FRESH = "INVITE_ITEM_FRESH";
	public static string SAIL_CHANGE_LEFT_SAILCHANCE = "SAIL_CHANGE_LEFT_SAILCHANCE";
	public static string SAIL_CHANGE_LEFT_ATTACKCHANCE = "SAIL_CHANGE_LEFT_ATTACKCHANCE";
	public static string SAIL_CHANGE_LEFT_CONVOYCHANCE = "SAIL_CHANGE_LEFT_CONVOYCHANCE";
	public static string SAIL_BUYGOODS_SUCCESS = "SAIL_BUYGOODS_SUCCESS";
	public static string SAIL_CHOOSE_PART = "SAIL_CHOOSE_PART";
	public static string SAIL_UPDATE_INVITE_INFO = "SAIL_UPDATE_INVITE_INFO";
	/** 航海贸易流行商品 */
	public static string SAIL_POPULAR_GOODS_ID_CHANGE = "SAIL_POPULAR_GOODS_ID_CHANGE";
	/** 收到护航申请 */
	public static string SAIL_RECEIVE_PROTECT = "SAIL_RECEIVE_PROTECT";
	public static string SAIL_UPGRADE_PART = "SAIL_UPGRADE_PART";
	public static string SAIL_HAVE_GOODS = "SAIL_HAVE_GOODS";
	/** 航海结果 */
	public static string SAIL_SHIP_END_OVER = "SAIL_SHIP_END_OVER";
	/** 开始航海 */
	public static string SAIL_START_SAILING = "SAIL_START_SAILING";
		
		
	public static string GUILD_BOSS_OPEN = "GUILD_BOSS_OPEN";
		
	public static string GUILD_BOSS_END = "GUILD_BOSS_END";
		
	public static string CHALLENGE_BOSS_END = "CHALLENGE_BOSS_END";
		
		
	//////////////连击数
		
	/** 连击数属性改变*/
	public static string COMBO_CHANGE_PROPERTY = "GUILD_CHANGE_PROPERTY";
		
	/** 连击数改变（不包括连接数自动扣除））*/
	public static string COMBO_CHANGE_NUMBER = "COMBO_CHANGE_NUMBER";
		
	/** 连击数扣除*/
	public static string COMBO_AUTOCONSUME = "COMBO_AUTOCONSUME";
		
	/** 连击数阶段改变*/
	public static string COMBO_LV_CHANGE = "COMBO_LV_CHANGE";
		
	/** 连击结束*/
	public static string COMBO_END = "COMBO_END";
		
	/** 连击暂停*/
	public static string COMBO_PAUSE = "COMBO_PAUSE";
		
	/**
		* 竞技场（实力  公平）
		*/
	public static string  KING_CONTEST_END = "KING_CONTEST_END";//王者争霸结束
	public static string  ARENA_RANK_LIST = "ARENA_RANK_LIST";
	public static string  ARENA_MATCH_RESULT = "ARENA_MATCH_RESULT";
	public static string  POWER_ARENA_OPEN_RETURN = "POWER_ARENA_OPEN_RETURN";
	public static string  FAIR_ARENA_OPEN_RETURN = "FAIR_ARENA_OPEN_RETURN";
	public static string  AWARD_HAS_GET = "AWARD_HAS_GET";
	public static string  ARENA_NO_ONE_MATCH = "AWARD_NO_ONE_MATCH";
	public static string  ARENA_CAN_START_MATCH = "ARENA_CAN_START_MATCH";
	public static string  ARENA_COUNT_DOWN_TIME = "ARENA_COUNT_DOWN_TIME";
	public static string  ARENA_AWARD_TIME = "ARENA_AWARD_TIME";
	/**
		*系统菜单操作提示,如人物等级提升了，菜单按钮付出金叹号，上下浮动 
		*/
	public static string SYS_MENU_OPERATE_PROMPT = "sysMenuOperatePrompt";
		
	public static string DUNGEON_FINISH_EFFECT_END = "DungeonFinishEffect";
		
	/** 佣兵 信息*/
	public static string SOLDIER_LIST_INFO = "SOLDIER_LIST_INFO";
	/** 佣兵出战或者休息*/
	public static string SOLDIER_BATTLE_REST = "SOLDIER_BATTLE_REST";
	/** 佣兵升级*/
	public static string SOLDIER_LEVEL_UP = "SOLDIER_LEVEL_UP";
	/** 佣兵技能升级*/
	public static string SOLDIER_SKILL_LEVEL_UP = "SOLDIER_SKILL_LEVEL_UP";
		
	public static string SCENE_MOUSE_CLICK = "SCENE_MOUSE_CLICK";
	public static string UI_RIGHT_SHOW_BTN_GLINT = "SHOW_UI_RIGHT_BTN";
	public static string UI_RIGHT_CLEAR_BTN_GLINT = "HIDE_UI_RIGHT_BTN";
		
	public static string VIEW_PLAYER_INFORMATION = "VIEW_PLAYER_INFORMATION";
	/**
		*资源获取通知事件 
		*/		
	public static string RES_GAIN_NOTICE = "ResGainNotice";
		
	public static string ENTER_GAME = "EnterGame";
		
	/** 打开背包开启格子面板*/
	public static string OPEN_BAG_GRID_PANEL = "OpenBagGridPanel";
	/** 背包开始格子成功,开始播放特效 */
	public static string BAG_OPEN_GRID_SUC_EFFSTART = "BAG_OPEN_GRID_SUC_EFFSTART";
	/** 背包开始格子成功，特效播放结束 */
	public static string BAG_OPEN_GRID_SUC_EFFEND = "BAG_OPEN_GRID_SUC_EFFEND";
	/** 背包开启格子花费面板即时刷新 */
	public static string BAG_OPEN_GRID_COST_UPDATE = "BAG_OPEN_GRID_COST_UPDATE";
	/** 背包仓库格子花费面板即时刷新 */
	public static string BAG_STORAGE_COST_UPDATE = "BAG_STORAGE_COST_UPDATE";
		
	/** 系统剩余数目*/
	public static string SYSTEM_REST_TIMES_UPDATE = "SYSTEM_REST_TIMES_UPDATE";
		
		
	//BUFF相关
	/**
		* 主角添加了BUFF,通知其它地方,包括左上角buff栏
		*/		
	public static string MYROLE_ADD_BUFF = "MYROLE_ADD_BUFF";
	/**
		* 技能主动请求增加BUFF 
		*/		
	public static string SKILL_ADD_BUFF = "SKILL_ADD_BUFF";
	/** 航海市场交易购买成功 */
	public static string SAIL_TRADE_BUY_SUCCESS_EFF_ENDED = "SAIL_TRADE_BUY_SUCCESS_EFF_ENDED";
	/**
		*引导步骤变更派发事件 
		*/		
	public static string LEAD_STEP_CHANGE = "LeadStepChange";
	/** 翻版弹出面板被关闭 */
	public static string CLOSE_DUNGEON_ALERT_PANEL = "CLOSE_DUNGEON_ALERT_PANEL";
	/** 是否可以领取首充奖励 */
	public static string FIRST_CHARGE_INFO = "FIRST_CHARGE_INFO";
	/** 领取首充结果 */
	public static string FIRST_CHARGE_AWARD_RESULT = "FIRST_CHARGE_AWARD_RESULT";
		
	/** 刷新积分 */
	public static string EXCHANGE_SCORE_ITEM = "EXCHANGE_SCORE_ITEM";
	/** 刷新转盘仓库 */
	public static string TURNTABLE_STORE_TOTAL = "TURNTABLE_STORE_TOTAL";
	public static string TURNTABLE_START = "TURNTABLE_START";
		
	public static string TURNTABLE_STORE_GRID_DATA = "TURNTABLE_STORE_GRID_DATA";
    public EventList()
    {
    }
}
