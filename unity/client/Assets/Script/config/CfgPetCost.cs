using System.Collections.Generic;
public class CfgPetCost
{
	//当前进化等级
	public int level;
	//当前等级吞噬每点经验所需铜币
	public int eat_cost;
	//当前等级退化所需铜币
	public int return_cost;

	public CfgPetCost(){}
	private static Dictionary<int, CfgPetCost> _dataDic;
	public static Dictionary<int, CfgPetCost> dataDic
	{
		get {
			if (_dataDic == null)
			{
				getData();
			}
			return _dataDic;
		}
	}
	public static CfgPetCost getValue(int level)
	{
		return dataDic[level];
	}
	private static void getData()
	{
		_dataDic = new Dictionary<int, CfgPetCost>
		{
			{0, new CfgPetCost{level=0,eat_cost=100000,return_cost=0}},
			{1, new CfgPetCost{level=1,eat_cost=120000,return_cost=100000}},
			{2, new CfgPetCost{level=2,eat_cost=140000,return_cost=300000}},
			{3, new CfgPetCost{level=3,eat_cost=160000,return_cost=600000}},
			{4, new CfgPetCost{level=4,eat_cost=180000,return_cost=1000000}},
			{5, new CfgPetCost{level=5,eat_cost=200000,return_cost=1500000}},
			{6, new CfgPetCost{level=6,eat_cost=220000,return_cost=2100000}},
			{7, new CfgPetCost{level=7,eat_cost=240000,return_cost=2800000}},
			{8, new CfgPetCost{level=8,eat_cost=260000,return_cost=3600000}},
			{9, new CfgPetCost{level=9,eat_cost=280000,return_cost=4500000}},
			{10, new CfgPetCost{level=10,eat_cost=300000,return_cost=5500000}}
		};
	}
}
