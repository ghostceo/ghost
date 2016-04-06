using System.Collections.Generic;
public class CfgStoneSuit
{
	//部位
	public int pos;
	//4个宝石等级
	public string suit_level;
	//属性ID
	public int attr_code;
	//主属性名称
	public string attr_desc;
	//最小值
	public int min_value;
	//最大值
	public int max_value;
	//描述
	public string desc;

	public CfgStoneSuit(){}
	private static Dictionary<string, CfgStoneSuit> _dataDic;
	public static Dictionary<string, CfgStoneSuit> dataDic
	{
		get {
			if (_dataDic == null)
			{
				getData();
			}
			return _dataDic;
		}
	}
	public static CfgStoneSuit getValue(string pos_suit_level)
	{
		return dataDic[pos_suit_level];
	}
	private static void getData()
	{
		_dataDic = new Dictionary<string, CfgStoneSuit>
		{
			{"1_1", new CfgStoneSuit{pos=1,suit_level="1",attr_code=78,attr_desc="抗性穿透",min_value=200,max_value=200,desc="该装备镶嵌4颗一级宝石"}},
			{"1_2", new CfgStoneSuit{pos=1,suit_level="2",attr_code=78,attr_desc="抗性穿透",min_value=400,max_value=400,desc="该装备镶嵌4颗二级宝石"}},
			{"1_3", new CfgStoneSuit{pos=1,suit_level="3",attr_code=78,attr_desc="抗性穿透",min_value=600,max_value=600,desc="该装备镶嵌4颗三级宝石"}},
			{"1_4", new CfgStoneSuit{pos=1,suit_level="4",attr_code=78,attr_desc="抗性穿透",min_value=800,max_value=800,desc="该装备镶嵌4颗四级宝石"}},
			{"1_5", new CfgStoneSuit{pos=1,suit_level="5",attr_code=78,attr_desc="抗性穿透",min_value=1000,max_value=1000,desc="该装备镶嵌4颗五级宝石"}},
			{"1_6", new CfgStoneSuit{pos=1,suit_level="6",attr_code=78,attr_desc="抗性穿透",min_value=1200,max_value=1200,desc="该装备镶嵌4颗六级宝石"}},
			{"1_7", new CfgStoneSuit{pos=1,suit_level="7",attr_code=78,attr_desc="抗性穿透",min_value=1400,max_value=1400,desc="该装备镶嵌4颗七级宝石"}},
			{"1_8", new CfgStoneSuit{pos=1,suit_level="8",attr_code=78,attr_desc="抗性穿透",min_value=1600,max_value=1600,desc="该装备镶嵌4颗八级宝石"}},
			{"1_9", new CfgStoneSuit{pos=1,suit_level="9",attr_code=78,attr_desc="抗性穿透",min_value=1800,max_value=1800,desc="该装备镶嵌4颗九级宝石"}},
			{"1_10", new CfgStoneSuit{pos=1,suit_level="10",attr_code=78,attr_desc="抗性穿透",min_value=2000,max_value=2000,desc="该装备镶嵌4颗十级宝石"}},
			{"2_1", new CfgStoneSuit{pos=2,suit_level="1",attr_code=78,attr_desc="抗性穿透",min_value=200,max_value=200,desc="该装备镶嵌4颗一级宝石"}},
			{"2_2", new CfgStoneSuit{pos=2,suit_level="2",attr_code=78,attr_desc="抗性穿透",min_value=400,max_value=400,desc="该装备镶嵌4颗二级宝石"}},
			{"2_3", new CfgStoneSuit{pos=2,suit_level="3",attr_code=78,attr_desc="抗性穿透",min_value=600,max_value=600,desc="该装备镶嵌4颗三级宝石"}},
			{"2_4", new CfgStoneSuit{pos=2,suit_level="4",attr_code=78,attr_desc="抗性穿透",min_value=800,max_value=800,desc="该装备镶嵌4颗四级宝石"}},
			{"2_5", new CfgStoneSuit{pos=2,suit_level="5",attr_code=78,attr_desc="抗性穿透",min_value=1000,max_value=1000,desc="该装备镶嵌4颗五级宝石"}},
			{"2_6", new CfgStoneSuit{pos=2,suit_level="6",attr_code=78,attr_desc="抗性穿透",min_value=1200,max_value=1200,desc="该装备镶嵌4颗六级宝石"}},
			{"2_7", new CfgStoneSuit{pos=2,suit_level="7",attr_code=78,attr_desc="抗性穿透",min_value=1400,max_value=1400,desc="该装备镶嵌4颗七级宝石"}},
			{"2_8", new CfgStoneSuit{pos=2,suit_level="8",attr_code=78,attr_desc="抗性穿透",min_value=1600,max_value=1600,desc="该装备镶嵌4颗八级宝石"}},
			{"2_9", new CfgStoneSuit{pos=2,suit_level="9",attr_code=78,attr_desc="抗性穿透",min_value=1800,max_value=1800,desc="该装备镶嵌4颗九级宝石"}},
			{"2_10", new CfgStoneSuit{pos=2,suit_level="10",attr_code=78,attr_desc="抗性穿透",min_value=2000,max_value=2000,desc="该装备镶嵌4颗十级宝石"}},
			{"3_1", new CfgStoneSuit{pos=3,suit_level="1",attr_code=78,attr_desc="抗性穿透",min_value=200,max_value=200,desc="该装备镶嵌4颗一级宝石"}},
			{"3_2", new CfgStoneSuit{pos=3,suit_level="2",attr_code=78,attr_desc="抗性穿透",min_value=400,max_value=400,desc="该装备镶嵌4颗二级宝石"}},
			{"3_3", new CfgStoneSuit{pos=3,suit_level="3",attr_code=78,attr_desc="抗性穿透",min_value=600,max_value=600,desc="该装备镶嵌4颗三级宝石"}},
			{"3_4", new CfgStoneSuit{pos=3,suit_level="4",attr_code=78,attr_desc="抗性穿透",min_value=800,max_value=800,desc="该装备镶嵌4颗四级宝石"}},
			{"3_5", new CfgStoneSuit{pos=3,suit_level="5",attr_code=78,attr_desc="抗性穿透",min_value=1000,max_value=1000,desc="该装备镶嵌4颗五级宝石"}},
			{"3_6", new CfgStoneSuit{pos=3,suit_level="6",attr_code=78,attr_desc="抗性穿透",min_value=1200,max_value=1200,desc="该装备镶嵌4颗六级宝石"}},
			{"3_7", new CfgStoneSuit{pos=3,suit_level="7",attr_code=78,attr_desc="抗性穿透",min_value=1400,max_value=1400,desc="该装备镶嵌4颗七级宝石"}},
			{"3_8", new CfgStoneSuit{pos=3,suit_level="8",attr_code=78,attr_desc="抗性穿透",min_value=1600,max_value=1600,desc="该装备镶嵌4颗八级宝石"}},
			{"3_9", new CfgStoneSuit{pos=3,suit_level="9",attr_code=78,attr_desc="抗性穿透",min_value=1800,max_value=1800,desc="该装备镶嵌4颗九级宝石"}},
			{"3_10", new CfgStoneSuit{pos=3,suit_level="10",attr_code=78,attr_desc="抗性穿透",min_value=2000,max_value=2000,desc="该装备镶嵌4颗十级宝石"}},
			{"4_1", new CfgStoneSuit{pos=4,suit_level="1",attr_code=78,attr_desc="抗性穿透",min_value=200,max_value=200,desc="该装备镶嵌4颗一级宝石"}},
			{"4_2", new CfgStoneSuit{pos=4,suit_level="2",attr_code=78,attr_desc="抗性穿透",min_value=400,max_value=400,desc="该装备镶嵌4颗二级宝石"}},
			{"4_3", new CfgStoneSuit{pos=4,suit_level="3",attr_code=78,attr_desc="抗性穿透",min_value=600,max_value=600,desc="该装备镶嵌4颗三级宝石"}},
			{"4_4", new CfgStoneSuit{pos=4,suit_level="4",attr_code=78,attr_desc="抗性穿透",min_value=800,max_value=800,desc="该装备镶嵌4颗四级宝石"}},
			{"4_5", new CfgStoneSuit{pos=4,suit_level="5",attr_code=78,attr_desc="抗性穿透",min_value=1000,max_value=1000,desc="该装备镶嵌4颗五级宝石"}},
			{"4_6", new CfgStoneSuit{pos=4,suit_level="6",attr_code=78,attr_desc="抗性穿透",min_value=1200,max_value=1200,desc="该装备镶嵌4颗六级宝石"}},
			{"4_7", new CfgStoneSuit{pos=4,suit_level="7",attr_code=78,attr_desc="抗性穿透",min_value=1400,max_value=1400,desc="该装备镶嵌4颗七级宝石"}},
			{"4_8", new CfgStoneSuit{pos=4,suit_level="8",attr_code=78,attr_desc="抗性穿透",min_value=1600,max_value=1600,desc="该装备镶嵌4颗八级宝石"}},
			{"4_9", new CfgStoneSuit{pos=4,suit_level="9",attr_code=78,attr_desc="抗性穿透",min_value=1800,max_value=1800,desc="该装备镶嵌4颗九级宝石"}},
			{"4_10", new CfgStoneSuit{pos=4,suit_level="10",attr_code=78,attr_desc="抗性穿透",min_value=2000,max_value=2000,desc="该装备镶嵌4颗十级宝石"}},
			{"5_1", new CfgStoneSuit{pos=5,suit_level="1",attr_code=24,attr_desc="物理抗性",min_value=400,max_value=200,desc="该装备镶嵌4颗一级宝石"}},
			{"5_2", new CfgStoneSuit{pos=5,suit_level="2",attr_code=24,attr_desc="物理抗性",min_value=800,max_value=400,desc="该装备镶嵌4颗二级宝石"}},
			{"5_3", new CfgStoneSuit{pos=5,suit_level="3",attr_code=24,attr_desc="物理抗性",min_value=1200,max_value=600,desc="该装备镶嵌4颗三级宝石"}},
			{"5_4", new CfgStoneSuit{pos=5,suit_level="4",attr_code=24,attr_desc="物理抗性",min_value=1600,max_value=800,desc="该装备镶嵌4颗四级宝石"}},
			{"5_5", new CfgStoneSuit{pos=5,suit_level="5",attr_code=24,attr_desc="物理抗性",min_value=2000,max_value=1000,desc="该装备镶嵌4颗五级宝石"}},
			{"5_6", new CfgStoneSuit{pos=5,suit_level="6",attr_code=24,attr_desc="物理抗性",min_value=2400,max_value=1200,desc="该装备镶嵌4颗六级宝石"}},
			{"5_7", new CfgStoneSuit{pos=5,suit_level="7",attr_code=24,attr_desc="物理抗性",min_value=2800,max_value=1400,desc="该装备镶嵌4颗七级宝石"}},
			{"5_8", new CfgStoneSuit{pos=5,suit_level="8",attr_code=24,attr_desc="物理抗性",min_value=3200,max_value=1600,desc="该装备镶嵌4颗八级宝石"}},
			{"5_9", new CfgStoneSuit{pos=5,suit_level="9",attr_code=24,attr_desc="物理抗性",min_value=3600,max_value=1800,desc="该装备镶嵌4颗九级宝石"}},
			{"5_10", new CfgStoneSuit{pos=5,suit_level="10",attr_code=24,attr_desc="物理抗性",min_value=4000,max_value=2000,desc="该装备镶嵌4颗十级宝石"}},
			{"6_1", new CfgStoneSuit{pos=6,suit_level="1",attr_code=25,attr_desc="魔法抗性",min_value=400,max_value=200,desc="该装备镶嵌4颗一级宝石"}},
			{"6_2", new CfgStoneSuit{pos=6,suit_level="2",attr_code=25,attr_desc="魔法抗性",min_value=800,max_value=400,desc="该装备镶嵌4颗二级宝石"}},
			{"6_3", new CfgStoneSuit{pos=6,suit_level="3",attr_code=25,attr_desc="魔法抗性",min_value=1200,max_value=600,desc="该装备镶嵌4颗三级宝石"}},
			{"6_4", new CfgStoneSuit{pos=6,suit_level="4",attr_code=25,attr_desc="魔法抗性",min_value=1600,max_value=800,desc="该装备镶嵌4颗四级宝石"}},
			{"6_5", new CfgStoneSuit{pos=6,suit_level="5",attr_code=25,attr_desc="魔法抗性",min_value=2000,max_value=1000,desc="该装备镶嵌4颗五级宝石"}},
			{"6_6", new CfgStoneSuit{pos=6,suit_level="6",attr_code=25,attr_desc="魔法抗性",min_value=2400,max_value=1200,desc="该装备镶嵌4颗六级宝石"}},
			{"6_7", new CfgStoneSuit{pos=6,suit_level="7",attr_code=25,attr_desc="魔法抗性",min_value=2800,max_value=1400,desc="该装备镶嵌4颗七级宝石"}},
			{"6_8", new CfgStoneSuit{pos=6,suit_level="8",attr_code=25,attr_desc="魔法抗性",min_value=3200,max_value=1600,desc="该装备镶嵌4颗八级宝石"}},
			{"6_9", new CfgStoneSuit{pos=6,suit_level="9",attr_code=25,attr_desc="魔法抗性",min_value=3600,max_value=1800,desc="该装备镶嵌4颗九级宝石"}},
			{"6_10", new CfgStoneSuit{pos=6,suit_level="10",attr_code=25,attr_desc="魔法抗性",min_value=4000,max_value=2000,desc="该装备镶嵌4颗十级宝石"}},
			{"7_1", new CfgStoneSuit{pos=7,suit_level="1",attr_code=26,attr_desc="敏捷抗性",min_value=400,max_value=200,desc="该装备镶嵌4颗一级宝石"}},
			{"7_2", new CfgStoneSuit{pos=7,suit_level="2",attr_code=26,attr_desc="敏捷抗性",min_value=800,max_value=400,desc="该装备镶嵌4颗二级宝石"}},
			{"7_3", new CfgStoneSuit{pos=7,suit_level="3",attr_code=26,attr_desc="敏捷抗性",min_value=1200,max_value=600,desc="该装备镶嵌4颗三级宝石"}},
			{"7_4", new CfgStoneSuit{pos=7,suit_level="4",attr_code=26,attr_desc="敏捷抗性",min_value=1600,max_value=800,desc="该装备镶嵌4颗四级宝石"}},
			{"7_5", new CfgStoneSuit{pos=7,suit_level="5",attr_code=26,attr_desc="敏捷抗性",min_value=2000,max_value=1000,desc="该装备镶嵌4颗五级宝石"}},
			{"7_6", new CfgStoneSuit{pos=7,suit_level="6",attr_code=26,attr_desc="敏捷抗性",min_value=2400,max_value=1200,desc="该装备镶嵌4颗六级宝石"}},
			{"7_7", new CfgStoneSuit{pos=7,suit_level="7",attr_code=26,attr_desc="敏捷抗性",min_value=2800,max_value=1400,desc="该装备镶嵌4颗七级宝石"}},
			{"7_8", new CfgStoneSuit{pos=7,suit_level="8",attr_code=26,attr_desc="敏捷抗性",min_value=3200,max_value=1600,desc="该装备镶嵌4颗八级宝石"}},
			{"7_9", new CfgStoneSuit{pos=7,suit_level="9",attr_code=26,attr_desc="敏捷抗性",min_value=3600,max_value=1800,desc="该装备镶嵌4颗九级宝石"}},
			{"7_10", new CfgStoneSuit{pos=7,suit_level="10",attr_code=26,attr_desc="敏捷抗性",min_value=4000,max_value=2000,desc="该装备镶嵌4颗十级宝石"}},
			{"8_1", new CfgStoneSuit{pos=8,suit_level="1",attr_code=24,attr_desc="物理抗性",min_value=400,max_value=200,desc="该装备镶嵌4颗一级宝石"}},
			{"8_2", new CfgStoneSuit{pos=8,suit_level="2",attr_code=24,attr_desc="物理抗性",min_value=800,max_value=400,desc="该装备镶嵌4颗二级宝石"}},
			{"8_3", new CfgStoneSuit{pos=8,suit_level="3",attr_code=24,attr_desc="物理抗性",min_value=1200,max_value=600,desc="该装备镶嵌4颗三级宝石"}},
			{"8_4", new CfgStoneSuit{pos=8,suit_level="4",attr_code=24,attr_desc="物理抗性",min_value=1600,max_value=800,desc="该装备镶嵌4颗四级宝石"}},
			{"8_5", new CfgStoneSuit{pos=8,suit_level="5",attr_code=24,attr_desc="物理抗性",min_value=2000,max_value=1000,desc="该装备镶嵌4颗五级宝石"}},
			{"8_6", new CfgStoneSuit{pos=8,suit_level="6",attr_code=24,attr_desc="物理抗性",min_value=2400,max_value=1200,desc="该装备镶嵌4颗六级宝石"}},
			{"8_7", new CfgStoneSuit{pos=8,suit_level="7",attr_code=24,attr_desc="物理抗性",min_value=2800,max_value=1400,desc="该装备镶嵌4颗七级宝石"}},
			{"8_8", new CfgStoneSuit{pos=8,suit_level="8",attr_code=24,attr_desc="物理抗性",min_value=3200,max_value=1600,desc="该装备镶嵌4颗八级宝石"}},
			{"8_9", new CfgStoneSuit{pos=8,suit_level="9",attr_code=24,attr_desc="物理抗性",min_value=3600,max_value=1800,desc="该装备镶嵌4颗九级宝石"}},
			{"8_10", new CfgStoneSuit{pos=8,suit_level="10",attr_code=24,attr_desc="物理抗性",min_value=4000,max_value=2000,desc="该装备镶嵌4颗十级宝石"}},
			{"9_1", new CfgStoneSuit{pos=9,suit_level="1",attr_code=25,attr_desc="魔法抗性",min_value=400,max_value=200,desc="该装备镶嵌4颗一级宝石"}},
			{"9_2", new CfgStoneSuit{pos=9,suit_level="2",attr_code=25,attr_desc="魔法抗性",min_value=800,max_value=400,desc="该装备镶嵌4颗二级宝石"}},
			{"9_3", new CfgStoneSuit{pos=9,suit_level="3",attr_code=25,attr_desc="魔法抗性",min_value=1200,max_value=600,desc="该装备镶嵌4颗三级宝石"}},
			{"9_4", new CfgStoneSuit{pos=9,suit_level="4",attr_code=25,attr_desc="魔法抗性",min_value=1600,max_value=800,desc="该装备镶嵌4颗四级宝石"}},
			{"9_5", new CfgStoneSuit{pos=9,suit_level="5",attr_code=25,attr_desc="魔法抗性",min_value=2000,max_value=1000,desc="该装备镶嵌4颗五级宝石"}},
			{"9_6", new CfgStoneSuit{pos=9,suit_level="6",attr_code=25,attr_desc="魔法抗性",min_value=2400,max_value=1200,desc="该装备镶嵌4颗六级宝石"}},
			{"9_7", new CfgStoneSuit{pos=9,suit_level="7",attr_code=25,attr_desc="魔法抗性",min_value=2800,max_value=1400,desc="该装备镶嵌4颗七级宝石"}},
			{"9_8", new CfgStoneSuit{pos=9,suit_level="8",attr_code=25,attr_desc="魔法抗性",min_value=3200,max_value=1600,desc="该装备镶嵌4颗八级宝石"}},
			{"9_9", new CfgStoneSuit{pos=9,suit_level="9",attr_code=25,attr_desc="魔法抗性",min_value=3600,max_value=1800,desc="该装备镶嵌4颗九级宝石"}},
			{"9_10", new CfgStoneSuit{pos=9,suit_level="10",attr_code=25,attr_desc="魔法抗性",min_value=4000,max_value=2000,desc="该装备镶嵌4颗十级宝石"}},
			{"10_1", new CfgStoneSuit{pos=10,suit_level="1",attr_code=26,attr_desc="敏捷抗性",min_value=400,max_value=200,desc="该装备镶嵌4颗一级宝石"}},
			{"10_2", new CfgStoneSuit{pos=10,suit_level="2",attr_code=26,attr_desc="敏捷抗性",min_value=800,max_value=400,desc="该装备镶嵌4颗二级宝石"}},
			{"10_3", new CfgStoneSuit{pos=10,suit_level="3",attr_code=26,attr_desc="敏捷抗性",min_value=1200,max_value=600,desc="该装备镶嵌4颗三级宝石"}},
			{"10_4", new CfgStoneSuit{pos=10,suit_level="4",attr_code=26,attr_desc="敏捷抗性",min_value=1600,max_value=800,desc="该装备镶嵌4颗四级宝石"}},
			{"10_5", new CfgStoneSuit{pos=10,suit_level="5",attr_code=26,attr_desc="敏捷抗性",min_value=2000,max_value=1000,desc="该装备镶嵌4颗五级宝石"}},
			{"10_6", new CfgStoneSuit{pos=10,suit_level="6",attr_code=26,attr_desc="敏捷抗性",min_value=2400,max_value=1200,desc="该装备镶嵌4颗六级宝石"}},
			{"10_7", new CfgStoneSuit{pos=10,suit_level="7",attr_code=26,attr_desc="敏捷抗性",min_value=2800,max_value=1400,desc="该装备镶嵌4颗七级宝石"}},
			{"10_8", new CfgStoneSuit{pos=10,suit_level="8",attr_code=26,attr_desc="敏捷抗性",min_value=3200,max_value=1600,desc="该装备镶嵌4颗八级宝石"}},
			{"10_9", new CfgStoneSuit{pos=10,suit_level="9",attr_code=26,attr_desc="敏捷抗性",min_value=3600,max_value=1800,desc="该装备镶嵌4颗九级宝石"}},
			{"10_10", new CfgStoneSuit{pos=10,suit_level="10",attr_code=26,attr_desc="敏捷抗性",min_value=4000,max_value=2000,desc="该装备镶嵌4颗十级宝石"}}
		};
	}
}
