using System.Collections.Generic;
public class CfgBuffFunc
{
	//FuncID
	public int funcid;
	//类型关键字
	public string type;
	//Buff类型描述
	public string desc;

	public CfgBuffFunc(){}
	private static Dictionary<int, CfgBuffFunc> _dataDic;
	public static Dictionary<int, CfgBuffFunc> dataDic
	{
		get {
			if (_dataDic == null)
			{
				getData();
			}
			return _dataDic;
		}
	}
	public static CfgBuffFunc getValue(int funcid)
	{
		return dataDic[funcid];
	}
	private static void getData()
	{
		_dataDic = new Dictionary<int, CfgBuffFunc>
		{
			{1, new CfgBuffFunc{funcid=1,type="dizzy",desc="眩晕，无法移动，无法使用技能和道具"}},
			{2, new CfgBuffFunc{funcid=2,type="silent",desc="封印或禁魔，无法使用技能"}},
			{3, new CfgBuffFunc{funcid=3,type="reduce_damage",desc="减少最终受到的伤害"}},
			{4, new CfgBuffFunc{funcid=4,type="add_damage",desc="增加最终受到的伤害"}},
			{8, new CfgBuffFunc{funcid=8,type="atk_hurt_poisoning",desc="中毒：按攻击者百分比攻击力伤害掉血"}},
			{9, new CfgBuffFunc{funcid=9,type="max_hp_poisoning",desc="中毒：按防御方最大血量的比例掉血"}},
			{11, new CfgBuffFunc{funcid=11,type="hp_poisoning",desc="中毒：按防御方当前血量的比例掉血"}},
			{12, new CfgBuffFunc{funcid=12,type="atk_hurt_burning",desc="燃烧：按攻击者百分比攻击力伤害掉血"}},
			{13, new CfgBuffFunc{funcid=13,type="max_hp_burning",desc="燃烧：按防御方最大血量的比例掉血"}},
			{14, new CfgBuffFunc{funcid=14,type="hp_burning",desc="燃烧：按防御方当前血量的比例掉血"}},
			{15, new CfgBuffFunc{funcid=15,type="atk_hurt_lighting",desc="雷击：按攻击者百分比攻击力伤害掉血"}},
			{16, new CfgBuffFunc{funcid=16,type="max_hp_lighting",desc="雷击：按防御方最大血量的比例掉血"}},
			{17, new CfgBuffFunc{funcid=17,type="hp_lighting",desc="雷击：按防御方当前血量的比例掉血"}}
		};
	}
}
