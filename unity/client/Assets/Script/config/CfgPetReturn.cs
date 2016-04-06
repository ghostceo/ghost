using System.Collections.Generic;
public class CfgPetReturn
{
	//职业
	public int category;
	//道具
	public int return_item;

	public CfgPetReturn(){}
	private static Dictionary<int, CfgPetReturn> _dataDic;
	public static Dictionary<int, CfgPetReturn> dataDic
	{
		get {
			if (_dataDic == null)
			{
				getData();
			}
			return _dataDic;
		}
	}
	public static CfgPetReturn getValue(int category)
	{
		return dataDic[category];
	}
	private static void getData()
	{
		_dataDic = new Dictionary<int, CfgPetReturn>
		{
			{1, new CfgPetReturn{category=1,return_item=12300091}},
			{2, new CfgPetReturn{category=2,return_item=12300092}},
			{3, new CfgPetReturn{category=3,return_item=12300093}}
		};
	}
}
