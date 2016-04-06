using System.Collections.Generic;
public class CfgEquipReinforceRate
{
	//装备颜色
	public int colour;
	//强化等级
	public int rein_lv;
	//加成百分比(如3表示3%)
	public int rate;

	public CfgEquipReinforceRate(){}
	private static Dictionary<string, CfgEquipReinforceRate> _dataDic;
	public static Dictionary<string, CfgEquipReinforceRate> dataDic
	{
		get {
			if (_dataDic == null)
			{
				getData();
			}
			return _dataDic;
		}
	}
	public static CfgEquipReinforceRate getValue(string colour_rein_lv)
	{
		return dataDic[colour_rein_lv];
	}
	private static void getData()
	{
		_dataDic = new Dictionary<string, CfgEquipReinforceRate>
		{
			{"1_1", new CfgEquipReinforceRate{colour=1,rein_lv=1,rate=1}},
			{"1_2", new CfgEquipReinforceRate{colour=1,rein_lv=2,rate=2}},
			{"1_3", new CfgEquipReinforceRate{colour=1,rein_lv=3,rate=3}},
			{"1_4", new CfgEquipReinforceRate{colour=1,rein_lv=4,rate=4}},
			{"1_5", new CfgEquipReinforceRate{colour=1,rein_lv=5,rate=5}},
			{"1_6", new CfgEquipReinforceRate{colour=1,rein_lv=6,rate=7}},
			{"1_7", new CfgEquipReinforceRate{colour=1,rein_lv=7,rate=9}},
			{"1_8", new CfgEquipReinforceRate{colour=1,rein_lv=8,rate=11}},
			{"1_9", new CfgEquipReinforceRate{colour=1,rein_lv=9,rate=13}},
			{"1_10", new CfgEquipReinforceRate{colour=1,rein_lv=10,rate=15}},
			{"1_11", new CfgEquipReinforceRate{colour=1,rein_lv=11,rate=18}},
			{"1_12", new CfgEquipReinforceRate{colour=1,rein_lv=12,rate=21}},
			{"1_13", new CfgEquipReinforceRate{colour=1,rein_lv=13,rate=24}},
			{"1_14", new CfgEquipReinforceRate{colour=1,rein_lv=14,rate=27}},
			{"1_15", new CfgEquipReinforceRate{colour=1,rein_lv=15,rate=30}},
			{"1_16", new CfgEquipReinforceRate{colour=1,rein_lv=16,rate=34}},
			{"1_17", new CfgEquipReinforceRate{colour=1,rein_lv=17,rate=38}},
			{"1_18", new CfgEquipReinforceRate{colour=1,rein_lv=18,rate=42}},
			{"1_19", new CfgEquipReinforceRate{colour=1,rein_lv=19,rate=46}},
			{"1_20", new CfgEquipReinforceRate{colour=1,rein_lv=20,rate=50}},
			{"2_1", new CfgEquipReinforceRate{colour=2,rein_lv=1,rate=2}},
			{"2_2", new CfgEquipReinforceRate{colour=2,rein_lv=2,rate=4}},
			{"2_3", new CfgEquipReinforceRate{colour=2,rein_lv=3,rate=6}},
			{"2_4", new CfgEquipReinforceRate{colour=2,rein_lv=4,rate=8}},
			{"2_5", new CfgEquipReinforceRate{colour=2,rein_lv=5,rate=10}},
			{"2_6", new CfgEquipReinforceRate{colour=2,rein_lv=6,rate=13}},
			{"2_7", new CfgEquipReinforceRate{colour=2,rein_lv=7,rate=16}},
			{"2_8", new CfgEquipReinforceRate{colour=2,rein_lv=8,rate=19}},
			{"2_9", new CfgEquipReinforceRate{colour=2,rein_lv=9,rate=22}},
			{"2_10", new CfgEquipReinforceRate{colour=2,rein_lv=10,rate=25}},
			{"2_11", new CfgEquipReinforceRate{colour=2,rein_lv=11,rate=29}},
			{"2_12", new CfgEquipReinforceRate{colour=2,rein_lv=12,rate=33}},
			{"2_13", new CfgEquipReinforceRate{colour=2,rein_lv=13,rate=37}},
			{"2_14", new CfgEquipReinforceRate{colour=2,rein_lv=14,rate=41}},
			{"2_15", new CfgEquipReinforceRate{colour=2,rein_lv=15,rate=45}},
			{"2_16", new CfgEquipReinforceRate{colour=2,rein_lv=16,rate=50}},
			{"2_17", new CfgEquipReinforceRate{colour=2,rein_lv=17,rate=55}},
			{"2_18", new CfgEquipReinforceRate{colour=2,rein_lv=18,rate=60}},
			{"2_19", new CfgEquipReinforceRate{colour=2,rein_lv=19,rate=65}},
			{"2_20", new CfgEquipReinforceRate{colour=2,rein_lv=20,rate=70}},
			{"3_1", new CfgEquipReinforceRate{colour=3,rein_lv=1,rate=4}},
			{"3_2", new CfgEquipReinforceRate{colour=3,rein_lv=2,rate=8}},
			{"3_3", new CfgEquipReinforceRate{colour=3,rein_lv=3,rate=12}},
			{"3_4", new CfgEquipReinforceRate{colour=3,rein_lv=4,rate=16}},
			{"3_5", new CfgEquipReinforceRate{colour=3,rein_lv=5,rate=20}},
			{"3_6", new CfgEquipReinforceRate{colour=3,rein_lv=6,rate=25}},
			{"3_7", new CfgEquipReinforceRate{colour=3,rein_lv=7,rate=30}},
			{"3_8", new CfgEquipReinforceRate{colour=3,rein_lv=8,rate=35}},
			{"3_9", new CfgEquipReinforceRate{colour=3,rein_lv=9,rate=40}},
			{"3_10", new CfgEquipReinforceRate{colour=3,rein_lv=10,rate=45}},
			{"3_11", new CfgEquipReinforceRate{colour=3,rein_lv=11,rate=56}},
			{"3_12", new CfgEquipReinforceRate{colour=3,rein_lv=12,rate=67}},
			{"3_13", new CfgEquipReinforceRate{colour=3,rein_lv=13,rate=78}},
			{"3_14", new CfgEquipReinforceRate{colour=3,rein_lv=14,rate=89}},
			{"3_15", new CfgEquipReinforceRate{colour=3,rein_lv=15,rate=100}},
			{"3_16", new CfgEquipReinforceRate{colour=3,rein_lv=16,rate=108}},
			{"3_17", new CfgEquipReinforceRate{colour=3,rein_lv=17,rate=116}},
			{"3_18", new CfgEquipReinforceRate{colour=3,rein_lv=18,rate=124}},
			{"3_19", new CfgEquipReinforceRate{colour=3,rein_lv=19,rate=132}},
			{"3_20", new CfgEquipReinforceRate{colour=3,rein_lv=20,rate=140}},
			{"4_1", new CfgEquipReinforceRate{colour=4,rein_lv=1,rate=6}},
			{"4_2", new CfgEquipReinforceRate{colour=4,rein_lv=2,rate=12}},
			{"4_3", new CfgEquipReinforceRate{colour=4,rein_lv=3,rate=18}},
			{"4_4", new CfgEquipReinforceRate{colour=4,rein_lv=4,rate=24}},
			{"4_5", new CfgEquipReinforceRate{colour=4,rein_lv=5,rate=30}},
			{"4_6", new CfgEquipReinforceRate{colour=4,rein_lv=6,rate=38}},
			{"4_7", new CfgEquipReinforceRate{colour=4,rein_lv=7,rate=46}},
			{"4_8", new CfgEquipReinforceRate{colour=4,rein_lv=8,rate=54}},
			{"4_9", new CfgEquipReinforceRate{colour=4,rein_lv=9,rate=62}},
			{"4_10", new CfgEquipReinforceRate{colour=4,rein_lv=10,rate=70}},
			{"4_11", new CfgEquipReinforceRate{colour=4,rein_lv=11,rate=80}},
			{"4_12", new CfgEquipReinforceRate{colour=4,rein_lv=12,rate=90}},
			{"4_13", new CfgEquipReinforceRate{colour=4,rein_lv=13,rate=100}},
			{"4_14", new CfgEquipReinforceRate{colour=4,rein_lv=14,rate=110}},
			{"4_15", new CfgEquipReinforceRate{colour=4,rein_lv=15,rate=120}},
			{"4_16", new CfgEquipReinforceRate{colour=4,rein_lv=16,rate=132}},
			{"4_17", new CfgEquipReinforceRate{colour=4,rein_lv=17,rate=144}},
			{"4_18", new CfgEquipReinforceRate{colour=4,rein_lv=18,rate=156}},
			{"4_19", new CfgEquipReinforceRate{colour=4,rein_lv=19,rate=168}},
			{"4_20", new CfgEquipReinforceRate{colour=4,rein_lv=20,rate=180}},
			{"5_1", new CfgEquipReinforceRate{colour=5,rein_lv=1,rate=8}},
			{"5_2", new CfgEquipReinforceRate{colour=5,rein_lv=2,rate=16}},
			{"5_3", new CfgEquipReinforceRate{colour=5,rein_lv=3,rate=24}},
			{"5_4", new CfgEquipReinforceRate{colour=5,rein_lv=4,rate=32}},
			{"5_5", new CfgEquipReinforceRate{colour=5,rein_lv=5,rate=40}},
			{"5_6", new CfgEquipReinforceRate{colour=5,rein_lv=6,rate=50}},
			{"5_7", new CfgEquipReinforceRate{colour=5,rein_lv=7,rate=60}},
			{"5_8", new CfgEquipReinforceRate{colour=5,rein_lv=8,rate=70}},
			{"5_9", new CfgEquipReinforceRate{colour=5,rein_lv=9,rate=80}},
			{"5_10", new CfgEquipReinforceRate{colour=5,rein_lv=10,rate=90}},
			{"5_11", new CfgEquipReinforceRate{colour=5,rein_lv=11,rate=102}},
			{"5_12", new CfgEquipReinforceRate{colour=5,rein_lv=12,rate=114}},
			{"5_13", new CfgEquipReinforceRate{colour=5,rein_lv=13,rate=126}},
			{"5_14", new CfgEquipReinforceRate{colour=5,rein_lv=14,rate=138}},
			{"5_15", new CfgEquipReinforceRate{colour=5,rein_lv=15,rate=150}},
			{"5_16", new CfgEquipReinforceRate{colour=5,rein_lv=16,rate=165}},
			{"5_17", new CfgEquipReinforceRate{colour=5,rein_lv=17,rate=180}},
			{"5_18", new CfgEquipReinforceRate{colour=5,rein_lv=18,rate=195}},
			{"5_19", new CfgEquipReinforceRate{colour=5,rein_lv=19,rate=210}},
			{"5_20", new CfgEquipReinforceRate{colour=5,rein_lv=20,rate=225}}
		};
	}
}
