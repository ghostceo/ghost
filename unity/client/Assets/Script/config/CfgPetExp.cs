using System.Collections.Generic;
public class CfgPetExp
{
	//等级
	public int level;
	//升下级所需经验
	public int next_level_exp;

	public CfgPetExp(){}
	private static Dictionary<int, CfgPetExp> _dataDic;
	public static Dictionary<int, CfgPetExp> dataDic
	{
		get {
			if (_dataDic == null)
			{
				getData();
			}
			return _dataDic;
		}
	}
	public static CfgPetExp getValue(int level)
	{
		return dataDic[level];
	}
	private static void getData()
	{
		_dataDic = new Dictionary<int, CfgPetExp>
		{
			{0, new CfgPetExp{level=0,next_level_exp=2}},
			{1, new CfgPetExp{level=1,next_level_exp=4}},
			{2, new CfgPetExp{level=2,next_level_exp=6}},
			{3, new CfgPetExp{level=3,next_level_exp=8}},
			{4, new CfgPetExp{level=4,next_level_exp=10}},
			{5, new CfgPetExp{level=5,next_level_exp=12}},
			{6, new CfgPetExp{level=6,next_level_exp=14}},
			{7, new CfgPetExp{level=7,next_level_exp=16}},
			{8, new CfgPetExp{level=8,next_level_exp=18}},
			{9, new CfgPetExp{level=9,next_level_exp=20}},
			{10, new CfgPetExp{level=10,next_level_exp=0}}
		};
	}
}
