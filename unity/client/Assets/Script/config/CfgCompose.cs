using System.Collections.Generic;
public class CfgCompose
{
	public int typeid;
	public int atypeid;
	public int jingjie;
	public int law;

	public CfgCompose(){}
	private static Dictionary<int, CfgCompose> _dataDic;
	public static Dictionary<int, CfgCompose> dataDic
	{
		get {
			if (_dataDic == null)
			{
				getData();
			}
			return _dataDic;
		}
	}
	public static CfgCompose getValue(int typeid)
	{
		return dataDic[typeid];
	}
	private static void getData()
	{
		_dataDic = new Dictionary<int, CfgCompose>
		{
			{10100002, new CfgCompose{typeid=10100002,atypeid=10100003,jingjie=0,law=5}},
			{10100003, new CfgCompose{typeid=10100003,atypeid=10100004,jingjie=0,law=5}},
			{10100004, new CfgCompose{typeid=10100004,atypeid=10100048,jingjie=0,law=5}},
			{12300118, new CfgCompose{typeid=12300118,atypeid=12300119,jingjie=0,law=5}},
			{12300119, new CfgCompose{typeid=12300119,atypeid=12300120,jingjie=0,law=5}},
			{12300120, new CfgCompose{typeid=12300120,atypeid=12300151,jingjie=0,law=5}},
			{10407010, new CfgCompose{typeid=10407010,atypeid=10401001,jingjie=0,law=5}},
			{10407011, new CfgCompose{typeid=10407011,atypeid=10401002,jingjie=0,law=5}},
			{10410017, new CfgCompose{typeid=10410017,atypeid=10410016,jingjie=0,law=5}},
			{10000002, new CfgCompose{typeid=10000002,atypeid=10100110,jingjie=0,law=3}},
			{10100110, new CfgCompose{typeid=10100110,atypeid=10100111,jingjie=0,law=3}},
			{10001001, new CfgCompose{typeid=10001001,atypeid=10001002,jingjie=0,law=3}},
			{10001002, new CfgCompose{typeid=10001002,atypeid=10001003,jingjie=0,law=3}},
			{10001003, new CfgCompose{typeid=10001003,atypeid=10001004,jingjie=0,law=3}},
			{10001004, new CfgCompose{typeid=10001004,atypeid=10001005,jingjie=0,law=3}},
			{10001005, new CfgCompose{typeid=10001005,atypeid=10001006,jingjie=110,law=3}},
			{10001006, new CfgCompose{typeid=10001006,atypeid=10001007,jingjie=410,law=3}},
			{10001007, new CfgCompose{typeid=10001007,atypeid=10001008,jingjie=610,law=3}},
			{10002001, new CfgCompose{typeid=10002001,atypeid=10002002,jingjie=0,law=3}},
			{10002002, new CfgCompose{typeid=10002002,atypeid=10002003,jingjie=0,law=3}},
			{10002003, new CfgCompose{typeid=10002003,atypeid=10002004,jingjie=0,law=3}},
			{10002004, new CfgCompose{typeid=10002004,atypeid=10002005,jingjie=0,law=3}},
			{10002005, new CfgCompose{typeid=10002005,atypeid=10002006,jingjie=110,law=3}},
			{10002006, new CfgCompose{typeid=10002006,atypeid=10002007,jingjie=410,law=3}},
			{10002007, new CfgCompose{typeid=10002007,atypeid=10002008,jingjie=610,law=3}},
			{10003001, new CfgCompose{typeid=10003001,atypeid=10003002,jingjie=0,law=3}},
			{10003002, new CfgCompose{typeid=10003002,atypeid=10003003,jingjie=0,law=3}},
			{10003003, new CfgCompose{typeid=10003003,atypeid=10003004,jingjie=0,law=3}},
			{10003004, new CfgCompose{typeid=10003004,atypeid=10003005,jingjie=0,law=3}},
			{10003005, new CfgCompose{typeid=10003005,atypeid=10003006,jingjie=110,law=3}},
			{10003006, new CfgCompose{typeid=10003006,atypeid=10003007,jingjie=410,law=3}},
			{10003007, new CfgCompose{typeid=10003007,atypeid=10003008,jingjie=610,law=3}},
			{10004001, new CfgCompose{typeid=10004001,atypeid=10004002,jingjie=0,law=3}},
			{10004002, new CfgCompose{typeid=10004002,atypeid=10004003,jingjie=0,law=3}},
			{10004003, new CfgCompose{typeid=10004003,atypeid=10004004,jingjie=0,law=3}},
			{10004004, new CfgCompose{typeid=10004004,atypeid=10004005,jingjie=0,law=3}},
			{10004005, new CfgCompose{typeid=10004005,atypeid=10004006,jingjie=110,law=3}},
			{10004006, new CfgCompose{typeid=10004006,atypeid=10004007,jingjie=410,law=3}},
			{10004007, new CfgCompose{typeid=10004007,atypeid=10004008,jingjie=610,law=3}},
			{10005001, new CfgCompose{typeid=10005001,atypeid=10005002,jingjie=0,law=3}},
			{10005002, new CfgCompose{typeid=10005002,atypeid=10005003,jingjie=0,law=3}},
			{10005003, new CfgCompose{typeid=10005003,atypeid=10005004,jingjie=0,law=3}},
			{10005004, new CfgCompose{typeid=10005004,atypeid=10005005,jingjie=0,law=3}},
			{10005005, new CfgCompose{typeid=10005005,atypeid=10005006,jingjie=110,law=3}},
			{10005006, new CfgCompose{typeid=10005006,atypeid=10005007,jingjie=410,law=3}},
			{10005007, new CfgCompose{typeid=10005007,atypeid=10005008,jingjie=610,law=3}},
			{10000281, new CfgCompose{typeid=10000281,atypeid=30112170,jingjie=0,law=5}},
			{10000287, new CfgCompose{typeid=10000287,atypeid=30112176,jingjie=0,law=5}}
		};
	}
}
