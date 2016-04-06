using System.Collections.Generic;
public class CfgStone
{
	//宝石ID
	public int typeid;
	//名字
	public string stonename;
	//初始颜色
	public int colour;
	//出售货币
	public int sell_type;
	//出售价格
	public int sell_price;
	//等级
	public int level;
	//主属性ID
	public int prop;
	//主属性名称
	public string propname;
	//最小值
	public int min_value;
	//最大值
	public int max_value;
	//初始经验
	public int init_exp;
	//升到下级所需经验
	public int next_level_exp;
	//下级宝石ID
	public int next_typeid;
	//宝石描述
	public string stone_decs;
	//宝石图片
	public string icon;
	//积分
	public int score;

	public CfgStone(){}
	private static Dictionary<int, CfgStone> _dataDic;
	public static Dictionary<int, CfgStone> dataDic
	{
		get {
			if (_dataDic == null)
			{
				getData();
			}
			return _dataDic;
		}
	}
	public static CfgStone getValue(int typeid)
	{
		return dataDic[typeid];
	}
	private static void getData()
	{
		_dataDic = new Dictionary<int, CfgStone>
		{
			{20100101, new CfgStone{typeid=20100101,stonename="1级力量石",colour=1,sell_type=0,sell_price=300,level=1,prop=1,propname="力量",min_value=50,max_value=50,init_exp=1,next_level_exp=3,next_typeid=20100102,stone_decs="镶嵌后+50点力量，可通过吞噬其它宝石提升等级",icon="/stones/101.jpg",score=1}},
			{20100102, new CfgStone{typeid=20100102,stonename="2级力量石",colour=1,sell_type=0,sell_price=1000,level=2,prop=1,propname="力量",min_value=100,max_value=100,init_exp=3,next_level_exp=9,next_typeid=20100103,stone_decs="镶嵌后+100点力量，可通过吞噬其它宝石提升等级",icon="/stones/101.jpg",score=3}},
			{20100103, new CfgStone{typeid=20100103,stonename="3级力量石",colour=1,sell_type=0,sell_price=3000,level=3,prop=1,propname="力量",min_value=150,max_value=150,init_exp=9,next_level_exp=27,next_typeid=20100104,stone_decs="镶嵌后+150点力量，可通过吞噬其它宝石提升等级",icon="/stones/103.jpg",score=8}},
			{20100104, new CfgStone{typeid=20100104,stonename="4级力量石",colour=1,sell_type=0,sell_price=8000,level=4,prop=1,propname="力量",min_value=250,max_value=250,init_exp=27,next_level_exp=81,next_typeid=20100105,stone_decs="镶嵌后+250点力量，可通过吞噬其它宝石提升等级",icon="/stones/103.jpg",score=28}},
			{20100105, new CfgStone{typeid=20100105,stonename="5级力量石",colour=1,sell_type=0,sell_price=25000,level=5,prop=1,propname="力量",min_value=400,max_value=400,init_exp=81,next_level_exp=243,next_typeid=20100106,stone_decs="镶嵌后+400点力量，可通过吞噬其它宝石提升等级",icon="/stones/105.jpg",score=88}},
			{20100106, new CfgStone{typeid=20100106,stonename="6级力量石",colour=1,sell_type=0,sell_price=80000,level=6,prop=1,propname="力量",min_value=600,max_value=600,init_exp=243,next_level_exp=729,next_typeid=20100107,stone_decs="镶嵌后+600点力量，可通过吞噬其它宝石提升等级",icon="/stones/105.jpg",score=288}},
			{20100107, new CfgStone{typeid=20100107,stonename="7级力量石",colour=1,sell_type=0,sell_price=250000,level=7,prop=1,propname="力量",min_value=900,max_value=900,init_exp=729,next_level_exp=2187,next_typeid=20100108,stone_decs="镶嵌后+900点力量，可通过吞噬其它宝石提升等级",icon="/stones/107.jpg",score=888}},
			{20100108, new CfgStone{typeid=20100108,stonename="8级力量石",colour=1,sell_type=0,sell_price=650000,level=8,prop=1,propname="力量",min_value=1200,max_value=1200,init_exp=2187,next_level_exp=6561,next_typeid=20100109,stone_decs="镶嵌后+1200点力量，可通过吞噬其它宝石提升等级",icon="/stones/107.jpg",score=2888}},
			{20100109, new CfgStone{typeid=20100109,stonename="9级力量石",colour=1,sell_type=0,sell_price=1200000,level=9,prop=1,propname="力量",min_value=1600,max_value=1600,init_exp=6561,next_level_exp=19683,next_typeid=20100110,stone_decs="镶嵌后+1600点力量，可通过吞噬其它宝石提升等级",icon="/stones/109.jpg",score=8888}},
			{20100110, new CfgStone{typeid=20100110,stonename="10级力量石",colour=1,sell_type=0,sell_price=2888888,level=10,prop=1,propname="力量",min_value=2000,max_value=2000,init_exp=19683,next_level_exp=19683,next_typeid=0,stone_decs="镶嵌后+2000点力量，可通过吞噬其它宝石提升等级",icon="/stones/109.jpg",score=28888}},
			{20100201, new CfgStone{typeid=20100201,stonename="1级智力石",colour=4,sell_type=0,sell_price=300,level=1,prop=2,propname="智力",min_value=50,max_value=50,init_exp=1,next_level_exp=3,next_typeid=20100202,stone_decs="镶嵌后+50点智力，可通过吞噬其它宝石提升等级",icon="/stones/301.jpg",score=1}},
			{20100202, new CfgStone{typeid=20100202,stonename="2级智力石",colour=4,sell_type=0,sell_price=1000,level=2,prop=2,propname="智力",min_value=100,max_value=100,init_exp=3,next_level_exp=9,next_typeid=20100203,stone_decs="镶嵌后+100点智力，可通过吞噬其它宝石提升等级",icon="/stones/301.jpg",score=3}},
			{20100203, new CfgStone{typeid=20100203,stonename="3级智力石",colour=4,sell_type=0,sell_price=3000,level=3,prop=2,propname="智力",min_value=150,max_value=150,init_exp=9,next_level_exp=27,next_typeid=20100204,stone_decs="镶嵌后+150点智力，可通过吞噬其它宝石提升等级",icon="/stones/303.jpg",score=8}},
			{20100204, new CfgStone{typeid=20100204,stonename="4级智力石",colour=4,sell_type=0,sell_price=8000,level=4,prop=2,propname="智力",min_value=250,max_value=250,init_exp=27,next_level_exp=81,next_typeid=20100205,stone_decs="镶嵌后+250点智力，可通过吞噬其它宝石提升等级",icon="/stones/303.jpg",score=28}},
			{20100205, new CfgStone{typeid=20100205,stonename="5级智力石",colour=4,sell_type=0,sell_price=25000,level=5,prop=2,propname="智力",min_value=400,max_value=400,init_exp=81,next_level_exp=243,next_typeid=20100206,stone_decs="镶嵌后+400点智力，可通过吞噬其它宝石提升等级",icon="/stones/305.jpg",score=88}},
			{20100206, new CfgStone{typeid=20100206,stonename="6级智力石",colour=4,sell_type=0,sell_price=80000,level=6,prop=2,propname="智力",min_value=600,max_value=600,init_exp=243,next_level_exp=729,next_typeid=20100207,stone_decs="镶嵌后+600点智力，可通过吞噬其它宝石提升等级",icon="/stones/305.jpg",score=288}},
			{20100207, new CfgStone{typeid=20100207,stonename="7级智力石",colour=4,sell_type=0,sell_price=250000,level=7,prop=2,propname="智力",min_value=900,max_value=900,init_exp=729,next_level_exp=2187,next_typeid=20100208,stone_decs="镶嵌后+900点智力，可通过吞噬其它宝石提升等级",icon="/stones/307.jpg",score=888}},
			{20100208, new CfgStone{typeid=20100208,stonename="8级智力石",colour=4,sell_type=0,sell_price=650000,level=8,prop=2,propname="智力",min_value=1200,max_value=1200,init_exp=2187,next_level_exp=6561,next_typeid=20100209,stone_decs="镶嵌后+1200点智力，可通过吞噬其它宝石提升等级",icon="/stones/307.jpg",score=2888}},
			{20100209, new CfgStone{typeid=20100209,stonename="9级智力石",colour=4,sell_type=0,sell_price=1200000,level=9,prop=2,propname="智力",min_value=1600,max_value=1600,init_exp=6561,next_level_exp=19683,next_typeid=20100210,stone_decs="镶嵌后+1600点智力，可通过吞噬其它宝石提升等级",icon="/stones/309.jpg",score=8888}},
			{20100210, new CfgStone{typeid=20100210,stonename="10级智力石",colour=4,sell_type=0,sell_price=2888888,level=10,prop=2,propname="智力",min_value=2000,max_value=2000,init_exp=19683,next_level_exp=19683,next_typeid=0,stone_decs="镶嵌后+2000点智力，可通过吞噬其它宝石提升等级",icon="/stones/309.jpg",score=28888}},
			{20100301, new CfgStone{typeid=20100301,stonename="1级敏捷石",colour=3,sell_type=0,sell_price=300,level=1,prop=3,propname="敏捷",min_value=50,max_value=50,init_exp=1,next_level_exp=3,next_typeid=20100302,stone_decs="镶嵌后+50点敏捷，可通过吞噬其它宝石提升等级",icon="/stones/201.jpg",score=1}},
			{20100302, new CfgStone{typeid=20100302,stonename="2级敏捷石",colour=3,sell_type=0,sell_price=1000,level=2,prop=3,propname="敏捷",min_value=100,max_value=100,init_exp=3,next_level_exp=9,next_typeid=20100303,stone_decs="镶嵌后+100点敏捷，可通过吞噬其它宝石提升等级",icon="/stones/201.jpg",score=3}},
			{20100303, new CfgStone{typeid=20100303,stonename="3级敏捷石",colour=3,sell_type=0,sell_price=3000,level=3,prop=3,propname="敏捷",min_value=150,max_value=150,init_exp=9,next_level_exp=27,next_typeid=20100304,stone_decs="镶嵌后+150点敏捷，可通过吞噬其它宝石提升等级",icon="/stones/203.jpg",score=8}},
			{20100304, new CfgStone{typeid=20100304,stonename="4级敏捷石",colour=3,sell_type=0,sell_price=8000,level=4,prop=3,propname="敏捷",min_value=250,max_value=250,init_exp=27,next_level_exp=81,next_typeid=20100305,stone_decs="镶嵌后+250点敏捷，可通过吞噬其它宝石提升等级",icon="/stones/203.jpg",score=28}},
			{20100305, new CfgStone{typeid=20100305,stonename="5级敏捷石",colour=3,sell_type=0,sell_price=25000,level=5,prop=3,propname="敏捷",min_value=400,max_value=400,init_exp=81,next_level_exp=243,next_typeid=20100306,stone_decs="镶嵌后+400点敏捷，可通过吞噬其它宝石提升等级",icon="/stones/205.jpg",score=88}},
			{20100306, new CfgStone{typeid=20100306,stonename="6级敏捷石",colour=3,sell_type=0,sell_price=80000,level=6,prop=3,propname="敏捷",min_value=600,max_value=600,init_exp=243,next_level_exp=729,next_typeid=20100307,stone_decs="镶嵌后+600点敏捷，可通过吞噬其它宝石提升等级",icon="/stones/205.jpg",score=288}},
			{20100307, new CfgStone{typeid=20100307,stonename="7级敏捷石",colour=3,sell_type=0,sell_price=250000,level=7,prop=3,propname="敏捷",min_value=900,max_value=900,init_exp=729,next_level_exp=2187,next_typeid=20100308,stone_decs="镶嵌后+900点敏捷，可通过吞噬其它宝石提升等级",icon="/stones/207.jpg",score=888}},
			{20100308, new CfgStone{typeid=20100308,stonename="8级敏捷石",colour=3,sell_type=0,sell_price=650000,level=8,prop=3,propname="敏捷",min_value=1200,max_value=1200,init_exp=2187,next_level_exp=6561,next_typeid=20100309,stone_decs="镶嵌后+1200点敏捷，可通过吞噬其它宝石提升等级",icon="/stones/207.jpg",score=2888}},
			{20100309, new CfgStone{typeid=20100309,stonename="9级敏捷石",colour=3,sell_type=0,sell_price=1200000,level=9,prop=3,propname="敏捷",min_value=1600,max_value=1600,init_exp=6561,next_level_exp=19683,next_typeid=20100310,stone_decs="镶嵌后+1600点敏捷，可通过吞噬其它宝石提升等级",icon="/stones/209.jpg",score=8888}},
			{20100310, new CfgStone{typeid=20100310,stonename="10级敏捷石",colour=3,sell_type=0,sell_price=2888888,level=10,prop=3,propname="敏捷",min_value=2000,max_value=2000,init_exp=19683,next_level_exp=19683,next_typeid=0,stone_decs="镶嵌后+2000点敏捷，可通过吞噬其它宝石提升等级",icon="/stones/209.jpg",score=28888}},
			{20100401, new CfgStone{typeid=20100401,stonename="1级体质石",colour=2,sell_type=0,sell_price=300,level=1,prop=4,propname="体质",min_value=50,max_value=50,init_exp=1,next_level_exp=3,next_typeid=20100402,stone_decs="镶嵌后+50点体质，可通过吞噬其它宝石提升等级",icon="/stones/401.jpg",score=1}},
			{20100402, new CfgStone{typeid=20100402,stonename="2级体质石",colour=2,sell_type=0,sell_price=1000,level=2,prop=4,propname="体质",min_value=100,max_value=100,init_exp=3,next_level_exp=9,next_typeid=20100403,stone_decs="镶嵌后+100点体质，可通过吞噬其它宝石提升等级",icon="/stones/401.jpg",score=3}},
			{20100403, new CfgStone{typeid=20100403,stonename="3级体质石",colour=2,sell_type=0,sell_price=3000,level=3,prop=4,propname="体质",min_value=150,max_value=150,init_exp=9,next_level_exp=27,next_typeid=20100404,stone_decs="镶嵌后+150点体质，可通过吞噬其它宝石提升等级",icon="/stones/403.jpg",score=8}},
			{20100404, new CfgStone{typeid=20100404,stonename="4级体质石",colour=2,sell_type=0,sell_price=8000,level=4,prop=4,propname="体质",min_value=250,max_value=250,init_exp=27,next_level_exp=81,next_typeid=20100405,stone_decs="镶嵌后+250点体质，可通过吞噬其它宝石提升等级",icon="/stones/403.jpg",score=28}},
			{20100405, new CfgStone{typeid=20100405,stonename="5级体质石",colour=2,sell_type=0,sell_price=25000,level=5,prop=4,propname="体质",min_value=400,max_value=400,init_exp=81,next_level_exp=243,next_typeid=20100406,stone_decs="镶嵌后+400点体质，可通过吞噬其它宝石提升等级",icon="/stones/405.jpg",score=88}},
			{20100406, new CfgStone{typeid=20100406,stonename="6级体质石",colour=2,sell_type=0,sell_price=80000,level=6,prop=4,propname="体质",min_value=600,max_value=600,init_exp=243,next_level_exp=729,next_typeid=20100407,stone_decs="镶嵌后+600点体质，可通过吞噬其它宝石提升等级",icon="/stones/405.jpg",score=288}},
			{20100407, new CfgStone{typeid=20100407,stonename="7级体质石",colour=2,sell_type=0,sell_price=250000,level=7,prop=4,propname="体质",min_value=900,max_value=900,init_exp=729,next_level_exp=2187,next_typeid=20100408,stone_decs="镶嵌后+900点体质，可通过吞噬其它宝石提升等级",icon="/stones/407.jpg",score=888}},
			{20100408, new CfgStone{typeid=20100408,stonename="8级体质石",colour=2,sell_type=0,sell_price=650000,level=8,prop=4,propname="体质",min_value=1200,max_value=1200,init_exp=2187,next_level_exp=6561,next_typeid=20100409,stone_decs="镶嵌后+1200点体质，可通过吞噬其它宝石提升等级",icon="/stones/407.jpg",score=2888}},
			{20100409, new CfgStone{typeid=20100409,stonename="9级体质石",colour=2,sell_type=0,sell_price=1200000,level=9,prop=4,propname="体质",min_value=1600,max_value=1600,init_exp=6561,next_level_exp=19683,next_typeid=20100410,stone_decs="镶嵌后+1600点体质，可通过吞噬其它宝石提升等级",icon="/stones/409.jpg",score=8888}},
			{20100410, new CfgStone{typeid=20100410,stonename="10级体质石",colour=2,sell_type=0,sell_price=2888888,level=10,prop=4,propname="体质",min_value=2000,max_value=2000,init_exp=19683,next_level_exp=19683,next_typeid=0,stone_decs="镶嵌后+2000点体质，可通过吞噬其它宝石提升等级",icon="/stones/409.jpg",score=28888}}
		};
	}
}
