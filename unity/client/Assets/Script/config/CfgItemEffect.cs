using System.Collections.Generic;
public class CfgItemEffect
{
	//功能ID
	public int typeid;
	//module
	public string module;
	//作用
	public string effect;
	//备注
	public string dese;

	public CfgItemEffect(){}
	private static Dictionary<int, CfgItemEffect> _dataDic;
	public static Dictionary<int, CfgItemEffect> dataDic
	{
		get {
			if (_dataDic == null)
			{
				getData();
			}
			return _dataDic;
		}
	}
	public static CfgItemEffect getValue(int typeid)
	{
		return dataDic[typeid];
	}
	private static void getData()
	{
		_dataDic = new Dictionary<int, CfgItemEffect>
		{
			{1, new CfgItemEffect{typeid=1,module="mod_item_effect",effect="add_hp",dese="%%加血"}},
			{2, new CfgItemEffect{typeid=2,module="mod_item_effect",effect="add_mp",dese="%%加法力"}},
			{3, new CfgItemEffect{typeid=3,module="mod_item_effect",effect="random_transform",dese="%%随机移动"}},
			{4, new CfgItemEffect{typeid=4,module="mod_item_effect",effect="return_home",dese="%%回城"}},
			{5, new CfgItemEffect{typeid=5,module="mod_item_effect",effect="random_move",dese="%%随机传送"}},
			{6, new CfgItemEffect{typeid=6,module="mod_item_effect",effect="add_exp_multiple_buff",dese="%%多倍经验"}},
			{7, new CfgItemEffect{typeid=7,module="mod_item_effect",effect="incre_max_endruance",dese="%%修理"}},
			{8, new CfgItemEffect{typeid=8,module="mod_item_effect",effect="location_move",dese="%%定位"}},
			{9, new CfgItemEffect{typeid=9,module="mod_item_effect",effect="give_state",dese="%%赋予状态"}},
			{10, new CfgItemEffect{typeid=10,module="mod_item_effect",effect="add_exp",dese="%%加经验"}},
			{11, new CfgItemEffect{typeid=11,module="mod_item_effect",effect="add_attr_points",dese="%%加属性点"}},
			{12, new CfgItemEffect{typeid=12,module="mod_item_effect",effect="add_skill_points",dese="%%加技能点"}},
			{13, new CfgItemEffect{typeid=13,module="mod_item_effect",effect="used_extend_bag",dese="%%使用扩展背包"}},
			{14, new CfgItemEffect{typeid=14,module="mod_item_effect",effect="used_gift_bag",dese="%%使用礼包"}},
			{15, new CfgItemEffect{typeid=15,module="mod_item_effect",effect="add_big_hp",dese="%%大红"}},
			{16, new CfgItemEffect{typeid=16,module="mod_item_effect",effect="change_ybc_color",dese="%%换车令"}},
			{17, new CfgItemEffect{typeid=17,module="mod_item_effect",effect="add_big_mp",dese="%%大蓝"}},
			{18, new CfgItemEffect{typeid=18,module="mod_item_effect",effect="reduce_pkpoint",dese="%%减少pk点"}},
			{19, new CfgItemEffect{typeid=19,module="mod_item_effect",effect="reset_role_skill",dese="%%洗技能点"}},
			{20, new CfgItemEffect{typeid=20,module="mod_item_effect",effect="add_money",dese="%%加钱"}},
			{21, new CfgItemEffect{typeid=21,module="mod_item_effect",effect="member_gather",dese="%%使用门派令"}},
			{22, new CfgItemEffect{typeid=22,module="mod_item_effect",effect="reset_attr_points",dese="%%洗属性点"}},
			{23, new CfgItemEffect{typeid=23,module="mod_item_effect",effect="add_training_point",dese="%%训练丹，增加训练点"}},
			{24, new CfgItemEffect{typeid=24,module="mod_item_effect",effect="show_newcomer_manual",dese="%%查看新手的江湖宝典"}},
			{28, new CfgItemEffect{typeid=28,module="mod_item_effect",effect="gather_factionist",dese="%%使用国王令，召集国民"}},
			{29, new CfgItemEffect{typeid=29,module="mod_item_effect",effect="get_new_pet",dese="%%使用道具获得一只神将"}},
			{30, new CfgItemEffect{typeid=30,module="mod_item_effect",effect="add_pet_hp",dese="%%使用道具增加神将生命"}},
			{31, new CfgItemEffect{typeid=31,module="mod_item_effect",effect="change_skin",dese="%%变身符"}},
			{34, new CfgItemEffect{typeid=34,module="mod_item_effect",effect="add_pet_exp",dese="%%神将加经验"}},
			{35, new CfgItemEffect{typeid=35,module="mod_item_effect",effect="reset_pet_attr",dese="%%神将洗属性"}},
			{36, new CfgItemEffect{typeid=36,module="mod_item_effect",effect="vip_active",dese="%%开通VIP"}},
			{37, new CfgItemEffect{typeid=37,module="mod_item_effect",effect="add_drunk_buff",dese="%%加醉酒buff"}},
			{38, new CfgItemEffect{typeid=38,module="mod_item_effect",effect="add_pet_refining_exp",dese="%%神将炼制丹"}},
			{41, new CfgItemEffect{typeid=41,module="mod_item_effect",effect="item_call_monster",dese="%%道具召唤怪物"}},
			{42, new CfgItemEffect{typeid=42,module="mod_item_effect",effect="add_energy",dese="%%增加精力值"}},
			{43, new CfgItemEffect{typeid=43,module="mod_item_effect",effect="add_noattack_buff",dese="%%免战牌"}},
			{44, new CfgItemEffect{typeid=44,module="mod_item_effect",effect="add_jingjie_max_hp",dese="%%加境界生命上限"}},
			{45, new CfgItemEffect{typeid=45,module="mod_item_effect",effect="add_jingjie_max_mp",dese="%%加境界斗气上限"}},
			{46, new CfgItemEffect{typeid=46,module="mod_item_effect",effect="add_jingjie_phy_attack",dese="%%加境界物攻"}},
			{47, new CfgItemEffect{typeid=47,module="mod_item_effect",effect="add_jingjie_mgc_attack",dese="%%加境界斗攻"}},
			{48, new CfgItemEffect{typeid=48,module="mod_item_effect",effect="add_jingjie_phy_defence",dese="%%加境界物防"}},
			{49, new CfgItemEffect{typeid=49,module="mod_item_effect",effect="add_jingjie_mgc_defence",dese="%%加境界斗防"}},
			{50, new CfgItemEffect{typeid=50,module="mod_item_effect",effect="add_hp_by_jingjie",dese="%%根据境界加血"}},
			{51, new CfgItemEffect{typeid=51,module="mod_item_effect",effect="add_mp_by_jingjie",dese="%%根据境界加斗气"}},
			{52, new CfgItemEffect{typeid=52,module="mod_item_effect",effect="add_country_treasure_buff",dese="%%异火争夺战中使用无敌符"}},
			{53, new CfgItemEffect{typeid=53,module="mod_item_effect",effect="use_cang_bao_tu",dese="%%使用藏宝图道具"}},
			{54, new CfgItemEffect{typeid=54,module="mod_item_effect",effect="add_soul_max_hp",dese="%%加境界生命上限"}},
			{55, new CfgItemEffect{typeid=55,module="mod_item_effect",effect="add_property_phy_attack",dese="%%使用属性丹加物攻"}},
			{56, new CfgItemEffect{typeid=56,module="mod_item_effect",effect="add_property_mgc_attack",dese="%%使用属性丹加斗攻"}},
			{57, new CfgItemEffect{typeid=57,module="mod_item_effect",effect="add_property_phy_defence",dese="%%使用属性丹加物防"}},
			{58, new CfgItemEffect{typeid=58,module="mod_item_effect",effect="add_property_mgc_defence",dese="%%使用属性丹加斗防"}},
			{59, new CfgItemEffect{typeid=59,module="mod_item_effect",effect="bomb",dese="%%夺命金丹"}},
			{60, new CfgItemEffect{typeid=60,module="mod_item_effect",effect="add_jifen",dese="%%加积分"}},
			{61, new CfgItemEffect{typeid=61,module="mod_item_effect",effect="add_warofmonster_buff",dese="%%加怪物攻城战的BUFF"}},
			{62, new CfgItemEffect{typeid=62,module="mod_item_effect",effect="add_gongxun",dese="%%加战功"}},
			{63, new CfgItemEffect{typeid=63,module="mod_item_effect",effect="add_tili",dese="%%使用体力卡"}},
			{64, new CfgItemEffect{typeid=64,module="mod_item_effect",effect="use_qiyuan_card",dese="%%使用奇缘卡"}},
			{65, new CfgItemEffect{typeid=65,module="mod_item_effect",effect="use_egg",dese="%%使用金蛋"}},
			{66, new CfgItemEffect{typeid=66,module="mod_item_effect",effect="add_xinghun",dese="%%使用神火令获得星魂值"}},
			{67, new CfgItemEffect{typeid=67,module="mod_item_effect",effect="add_honor",dese="%%使用道具获得荣誉值"}},
			{68, new CfgItemEffect{typeid=68,module="mod_item_effect",effect="add_jingjie_exp",dese="%%增加境界经验(1:百分比;2:绝对值)"}},
			{69, new CfgItemEffect{typeid=69,module="mod_item_effect",effect="add_buff_by_item",dese="%%Buff药水"}},
			{70, new CfgItemEffect{typeid=70,module="mod_item_effect",effect="use_super_gift",dese="%%Buff药水"}},
			{71, new CfgItemEffect{typeid=71,module="mod_item_effect",effect="add_equip_jingjie_score",dese="%%Buff药水"}},
			{72, new CfgItemEffect{typeid=72,module="mod_item_effect",effect="add_stone_jifen",dese="%%使用宝石修炼积分卡"}},
			{73, new CfgItemEffect{typeid=73,module="mod_item_effect",effect="add_role_jingqi",dese="%%使用精气瓶加精气"}},
			{74, new CfgItemEffect{typeid=74,module="mod_item_effect",effect="use_water_cang_bao_tu",dese="%%使用甘露藏宝图"}},
			{75, new CfgItemEffect{typeid=75,module="mod_item_effect",effect="add_exp_according_level",dese="%%使用道具更具等级增加经验"}},
			{76, new CfgItemEffect{typeid=76,module="mod_item_effect",effect="use_fool_day_props",dese="%%使用愚人节愚人令"}},
			{77, new CfgItemEffect{typeid=77,module="mod_item_effect",effect="add_scale_exp",dese="%%按比例增加经验，最大不超过人物当前升级所需经验值"}},
			{78, new CfgItemEffect{typeid=78,module="mod_item_effect",effect="add_examine_fb_times",dese="%%增加一次精英关卡挑战次数"}},
			{79, new CfgItemEffect{typeid=79,module="mod_item_effect",effect="active_god_skill",dese="%%激活神兵苍穹技能"}},
			{80, new CfgItemEffect{typeid=80,module="mod_item_effect",effect="use_family_bonus",dese="%%使用家族红包"}},
			{81, new CfgItemEffect{typeid=81,module="mod_item_effect",effect="add_specific_exp",dese="%%添加特定的经验"}},
			{82, new CfgItemEffect{typeid=82,module="mod_item_effect",effect="add_specific_silver",dese="%%添加特定的铜币"}},
			{83, new CfgItemEffect{typeid=83,module="mod_item_effect",effect="add_specific_family_contribute",dese="%%添加特定的公会贡献度"}},
			{1000, new CfgItemEffect{typeid=1000,module="mod_item_effect",effect="show_client_effect",dese="%%道具召唤怪物"}},
			{1001, new CfgItemEffect{typeid=1001,module="mod_item_effect",effect="add_boss_challenge_count",dese="%%添加boss劵使用"}},
			{1002, new CfgItemEffect{typeid=1002,module="mod_item_effect",effect="add_hanging_double_buff",dese="%%挂机双倍奖励"}},
			{1003, new CfgItemEffect{typeid=1003,module="mod_item_effect",effect="fast_fighting",dese="%%扫荡小怪符"}},
			{1004, new CfgItemEffect{typeid=1004,module="mod_item_effect",effect="add_petcard_score",dese="%%增加特定的真气值"}},
			{1005, new CfgItemEffect{typeid=1005,module="mod_item_effect",effect="add_build_score",dese="%%增加特定的熔炼值"}},
			{1006, new CfgItemEffect{typeid=1006,module="mod_item_effect",effect="add_pvp_protect",dese="%%增加被挑战免于被抢夺道具的保护时间"}},
			{1007, new CfgItemEffect{typeid=1007,module="mod_item_effect",effect="add_grab_times",dese="%%增加夺宝挑战次数"}},
			{1008, new CfgItemEffect{typeid=1008,module="mod_item_effect",effect="add_rnkm_times",dese="%%增加战神殿挑战次数"}}
		};
	}
}
