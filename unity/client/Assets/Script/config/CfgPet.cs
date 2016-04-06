using System.Collections.Generic;
public class CfgPet
{
	//宠物ID
	public int type_id;
	//名字
	public string pet_name;
	//可携带等级
	public int carry_level;
	//攻击类型
	public int attack_type;
	//阶位
	public int star_lv;
	//头像
	public string icon;
	//形象
	public int image;
	//职业
	public int category;

	public CfgPet(){}
	private static Dictionary<int, CfgPet> _dataDic;
	public static Dictionary<int, CfgPet> dataDic
	{
		get {
			if (_dataDic == null)
			{
				getData();
			}
			return _dataDic;
		}
	}
	public static CfgPet getValue(int type_id)
	{
		return dataDic[type_id];
	}
	private static void getData()
	{
		_dataDic = new Dictionary<int, CfgPet>
		{
			{30000201, new CfgPet{type_id=30000201,pet_name="黑无常",carry_level=11,attack_type=1,star_lv=2,icon="/generals/60062000.jpg",image=60062000,category=1}},
			{30000202, new CfgPet{type_id=30000202,pet_name="精卫",carry_level=11,attack_type=2,star_lv=2,icon="/generals/60071000.jpg",image=60071000,category=2}},
			{30000203, new CfgPet{type_id=30000203,pet_name="孟婆",carry_level=11,attack_type=3,star_lv=2,icon="/generals/60072000.jpg",image=60072000,category=3}},
			{30000301, new CfgPet{type_id=30000301,pet_name="钟馗",carry_level=21,attack_type=1,star_lv=3,icon="/generals/60061000.jpg",image=60061000,category=1}},
			{30000302, new CfgPet{type_id=30000302,pet_name="灶神",carry_level=21,attack_type=2,star_lv=3,icon="/generals/60028000.jpg",image=60028000,category=2}},
			{30000303, new CfgPet{type_id=30000303,pet_name="白骨精",carry_level=21,attack_type=3,star_lv=3,icon="/generals/60063000.jpg",image=60063000,category=3}},
			{30000401, new CfgPet{type_id=30000401,pet_name="玉兔精",carry_level=31,attack_type=1,star_lv=4,icon="/generals/60065000.jpg",image=60065000,category=1}},
			{30000402, new CfgPet{type_id=30000402,pet_name="青狮精",carry_level=31,attack_type=2,star_lv=4,icon="/generals/60036000.jpg",image=60036000,category=2}},
			{30000403, new CfgPet{type_id=30000403,pet_name="蜘蛛精",carry_level=31,attack_type=3,star_lv=4,icon="/generals/60069000.jpg",image=60069000,category=3}},
			{30000501, new CfgPet{type_id=30000501,pet_name="蝎子精",carry_level=41,attack_type=1,star_lv=5,icon="/generals/60068000.jpg",image=60068000,category=1}},
			{30000502, new CfgPet{type_id=30000502,pet_name="崔判官",carry_level=41,attack_type=2,star_lv=5,icon="/generals/60034000.jpg",image=60034000,category=2}},
			{30000503, new CfgPet{type_id=30000503,pet_name="嫦娥",carry_level=41,attack_type=3,star_lv=5,icon="/generals/60066000.jpg",image=60066000,category=3}},
			{30000601, new CfgPet{type_id=30000601,pet_name="酆都大帝",carry_level=51,attack_type=1,star_lv=6,icon="/generals/60021000.jpg",image=60021000,category=1}},
			{30000602, new CfgPet{type_id=30000602,pet_name="白无常",carry_level=51,attack_type=2,star_lv=6,icon="/generals/60064000.jpg",image=60064000,category=2}},
			{30000603, new CfgPet{type_id=30000603,pet_name="电母",carry_level=51,attack_type=3,star_lv=6,icon="/generals/60070000.jpg",image=60070000,category=3}},
			{30000701, new CfgPet{type_id=30000701,pet_name="太白金星",carry_level=61,attack_type=1,star_lv=7,icon="/generals/60035000.jpg",image=60035000,category=1}},
			{30000702, new CfgPet{type_id=30000702,pet_name="九凤",carry_level=61,attack_type=2,star_lv=7,icon="/generals/60049000.jpg",image=60049000,category=2}},
			{30000703, new CfgPet{type_id=30000703,pet_name="阎罗王",carry_level=61,attack_type=3,star_lv=7,icon="/generals/60038000.jpg",image=60038000,category=3}},
			{30000801, new CfgPet{type_id=30000801,pet_name="杨戬",carry_level=71,attack_type=1,star_lv=8,icon="/generals/60027000.jpg",image=60027000,category=1}},
			{30000802, new CfgPet{type_id=30000802,pet_name="后土娘娘",carry_level=71,attack_type=2,star_lv=8,icon="/generals/60051000.jpg",image=60051000,category=2}},
			{30000803, new CfgPet{type_id=30000803,pet_name="地藏菩萨",carry_level=71,attack_type=3,star_lv=8,icon="/generals/60030000.jpg",image=60030000,category=3}},
			{30000901, new CfgPet{type_id=30000901,pet_name="狮妖",carry_level=81,attack_type=1,star_lv=9,icon="/generals/60026000.jpg",image=60026000,category=1}},
			{30000902, new CfgPet{type_id=30000902,pet_name="美杜莎",carry_level=81,attack_type=2,star_lv=9,icon="/generals/60061000.jpg",image=60061000,category=2}},
			{30000903, new CfgPet{type_id=30000903,pet_name="蛮天尺",carry_level=81,attack_type=3,star_lv=9,icon="/generals/60061000.jpg",image=60061000,category=3}},
			{30001001, new CfgPet{type_id=30001001,pet_name="冰皇",carry_level=91,attack_type=1,star_lv=10,icon="/generals/60061000.jpg",image=60061000,category=1}},
			{30001002, new CfgPet{type_id=30001002,pet_name="天蛇女",carry_level=91,attack_type=2,star_lv=10,icon="/generals/60061000.jpg",image=60061000,category=2}},
			{30001003, new CfgPet{type_id=30001003,pet_name="玄衣",carry_level=91,attack_type=3,star_lv=10,icon="/generals/60061000.jpg",image=60061000,category=3}},
			{30001101, new CfgPet{type_id=30001101,pet_name="凤清儿",carry_level=101,attack_type=1,star_lv=11,icon="/generals/60061000.jpg",image=60061000,category=1}},
			{30001102, new CfgPet{type_id=30001102,pet_name="紫嫣",carry_level=101,attack_type=2,star_lv=11,icon="/generals/60061000.jpg",image=60061000,category=2}},
			{30001103, new CfgPet{type_id=30001103,pet_name="白泽",carry_level=101,attack_type=3,star_lv=11,icon="/generals/60061000.jpg",image=60061000,category=3}}
		};
	}
}
