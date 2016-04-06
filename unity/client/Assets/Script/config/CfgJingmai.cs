using System.Collections.Generic;
public class CfgJingmai
{
	//等级
	public int level;
	//最小攻击
	public int min_attack;
	//最大攻击
	public int max_attack;
	//物理防御
	public int phy_defence;
	//魔法防御
	public int magic_defence;
	//敏捷防御
	public int dex_defence;
	//血量
	public int max_hp;
	//升下级所需铜币
	public int need_silver;
	//升下级所需真气
	public int need_petcard_score;

	public CfgJingmai(){}
	private static Dictionary<int, CfgJingmai> _dataDic;
	public static Dictionary<int, CfgJingmai> dataDic
	{
		get {
			if (_dataDic == null)
			{
				getData();
			}
			return _dataDic;
		}
	}
	public static CfgJingmai getValue(int level)
	{
		return dataDic[level];
	}
	private static void getData()
	{
		_dataDic = new Dictionary<int, CfgJingmai>
		{
			{0, new CfgJingmai{level=0,min_attack=0,max_attack=0,phy_defence=0,magic_defence=0,dex_defence=0,max_hp=0,need_silver=30000,need_petcard_score=10}},
			{1, new CfgJingmai{level=1,min_attack=10,max_attack=20,phy_defence=15,magic_defence=15,dex_defence=15,max_hp=150,need_silver=33000,need_petcard_score=12}},
			{2, new CfgJingmai{level=2,min_attack=20,max_attack=40,phy_defence=30,magic_defence=30,dex_defence=30,max_hp=300,need_silver=36000,need_petcard_score=14}},
			{3, new CfgJingmai{level=3,min_attack=30,max_attack=60,phy_defence=45,magic_defence=45,dex_defence=45,max_hp=450,need_silver=39000,need_petcard_score=16}},
			{4, new CfgJingmai{level=4,min_attack=40,max_attack=80,phy_defence=60,magic_defence=60,dex_defence=60,max_hp=600,need_silver=42000,need_petcard_score=18}},
			{5, new CfgJingmai{level=5,min_attack=50,max_attack=100,phy_defence=75,magic_defence=75,dex_defence=75,max_hp=750,need_silver=45000,need_petcard_score=20}},
			{6, new CfgJingmai{level=6,min_attack=60,max_attack=120,phy_defence=90,magic_defence=90,dex_defence=90,max_hp=900,need_silver=48000,need_petcard_score=22}},
			{7, new CfgJingmai{level=7,min_attack=70,max_attack=140,phy_defence=105,magic_defence=105,dex_defence=105,max_hp=1050,need_silver=51000,need_petcard_score=24}},
			{8, new CfgJingmai{level=8,min_attack=80,max_attack=160,phy_defence=120,magic_defence=120,dex_defence=120,max_hp=1200,need_silver=54000,need_petcard_score=26}},
			{9, new CfgJingmai{level=9,min_attack=90,max_attack=180,phy_defence=135,magic_defence=135,dex_defence=135,max_hp=1350,need_silver=57000,need_petcard_score=28}},
			{10, new CfgJingmai{level=10,min_attack=100,max_attack=200,phy_defence=150,magic_defence=150,dex_defence=150,max_hp=1500,need_silver=60000,need_petcard_score=30}},
			{11, new CfgJingmai{level=11,min_attack=125,max_attack=250,phy_defence=175,magic_defence=175,dex_defence=175,max_hp=1750,need_silver=70000,need_petcard_score=35}},
			{12, new CfgJingmai{level=12,min_attack=150,max_attack=300,phy_defence=200,magic_defence=200,dex_defence=200,max_hp=2000,need_silver=80000,need_petcard_score=40}},
			{13, new CfgJingmai{level=13,min_attack=175,max_attack=350,phy_defence=225,magic_defence=225,dex_defence=225,max_hp=2250,need_silver=90000,need_petcard_score=45}},
			{14, new CfgJingmai{level=14,min_attack=200,max_attack=400,phy_defence=250,magic_defence=250,dex_defence=250,max_hp=2500,need_silver=100000,need_petcard_score=50}},
			{15, new CfgJingmai{level=15,min_attack=225,max_attack=450,phy_defence=275,magic_defence=275,dex_defence=275,max_hp=2750,need_silver=110000,need_petcard_score=55}},
			{16, new CfgJingmai{level=16,min_attack=250,max_attack=500,phy_defence=300,magic_defence=300,dex_defence=300,max_hp=3000,need_silver=120000,need_petcard_score=60}},
			{17, new CfgJingmai{level=17,min_attack=275,max_attack=550,phy_defence=325,magic_defence=325,dex_defence=325,max_hp=3250,need_silver=130000,need_petcard_score=65}},
			{18, new CfgJingmai{level=18,min_attack=300,max_attack=600,phy_defence=350,magic_defence=350,dex_defence=350,max_hp=3500,need_silver=140000,need_petcard_score=70}},
			{19, new CfgJingmai{level=19,min_attack=325,max_attack=650,phy_defence=375,magic_defence=375,dex_defence=375,max_hp=3750,need_silver=150000,need_petcard_score=75}},
			{20, new CfgJingmai{level=20,min_attack=350,max_attack=700,phy_defence=400,magic_defence=400,dex_defence=400,max_hp=4000,need_silver=160000,need_petcard_score=80}},
			{21, new CfgJingmai{level=21,min_attack=400,max_attack=800,phy_defence=450,magic_defence=450,dex_defence=450,max_hp=4500,need_silver=180000,need_petcard_score=90}},
			{22, new CfgJingmai{level=22,min_attack=450,max_attack=900,phy_defence=500,magic_defence=500,dex_defence=500,max_hp=5000,need_silver=200000,need_petcard_score=100}},
			{23, new CfgJingmai{level=23,min_attack=500,max_attack=1000,phy_defence=550,magic_defence=550,dex_defence=550,max_hp=5500,need_silver=220000,need_petcard_score=110}},
			{24, new CfgJingmai{level=24,min_attack=550,max_attack=1100,phy_defence=600,magic_defence=600,dex_defence=600,max_hp=6000,need_silver=240000,need_petcard_score=120}},
			{25, new CfgJingmai{level=25,min_attack=600,max_attack=1200,phy_defence=650,magic_defence=650,dex_defence=650,max_hp=6500,need_silver=260000,need_petcard_score=130}},
			{26, new CfgJingmai{level=26,min_attack=650,max_attack=1300,phy_defence=700,magic_defence=700,dex_defence=700,max_hp=7000,need_silver=280000,need_petcard_score=140}},
			{27, new CfgJingmai{level=27,min_attack=700,max_attack=1400,phy_defence=750,magic_defence=750,dex_defence=750,max_hp=7500,need_silver=300000,need_petcard_score=150}},
			{28, new CfgJingmai{level=28,min_attack=750,max_attack=1500,phy_defence=800,magic_defence=800,dex_defence=800,max_hp=8000,need_silver=320000,need_petcard_score=160}},
			{29, new CfgJingmai{level=29,min_attack=800,max_attack=1600,phy_defence=850,magic_defence=850,dex_defence=850,max_hp=8500,need_silver=340000,need_petcard_score=170}},
			{30, new CfgJingmai{level=30,min_attack=850,max_attack=1700,phy_defence=900,magic_defence=900,dex_defence=900,max_hp=9000,need_silver=360000,need_petcard_score=180}},
			{31, new CfgJingmai{level=31,min_attack=950,max_attack=1900,phy_defence=1000,magic_defence=1000,dex_defence=1000,max_hp=10000,need_silver=390000,need_petcard_score=200}},
			{32, new CfgJingmai{level=32,min_attack=1050,max_attack=2100,phy_defence=1100,magic_defence=1100,dex_defence=1100,max_hp=11000,need_silver=420000,need_petcard_score=220}},
			{33, new CfgJingmai{level=33,min_attack=1150,max_attack=2300,phy_defence=1200,magic_defence=1200,dex_defence=1200,max_hp=12000,need_silver=450000,need_petcard_score=240}},
			{34, new CfgJingmai{level=34,min_attack=1250,max_attack=2500,phy_defence=1300,magic_defence=1300,dex_defence=1300,max_hp=13000,need_silver=480000,need_petcard_score=260}},
			{35, new CfgJingmai{level=35,min_attack=1350,max_attack=2700,phy_defence=1400,magic_defence=1400,dex_defence=1400,max_hp=14000,need_silver=510000,need_petcard_score=280}},
			{36, new CfgJingmai{level=36,min_attack=1450,max_attack=2900,phy_defence=1500,magic_defence=1500,dex_defence=1500,max_hp=15000,need_silver=540000,need_petcard_score=300}},
			{37, new CfgJingmai{level=37,min_attack=1550,max_attack=3100,phy_defence=1600,magic_defence=1600,dex_defence=1600,max_hp=16000,need_silver=570000,need_petcard_score=320}},
			{38, new CfgJingmai{level=38,min_attack=1650,max_attack=3300,phy_defence=1700,magic_defence=1700,dex_defence=1700,max_hp=17000,need_silver=600000,need_petcard_score=340}},
			{39, new CfgJingmai{level=39,min_attack=1750,max_attack=3500,phy_defence=1800,magic_defence=1800,dex_defence=1800,max_hp=18000,need_silver=630000,need_petcard_score=360}},
			{40, new CfgJingmai{level=40,min_attack=1850,max_attack=3700,phy_defence=1900,magic_defence=1900,dex_defence=1900,max_hp=19000,need_silver=660000,need_petcard_score=380}},
			{41, new CfgJingmai{level=41,min_attack=2000,max_attack=4000,phy_defence=2100,magic_defence=2100,dex_defence=2100,max_hp=21000,need_silver=700000,need_petcard_score=420}},
			{42, new CfgJingmai{level=42,min_attack=2150,max_attack=4300,phy_defence=2300,magic_defence=2300,dex_defence=2300,max_hp=23000,need_silver=740000,need_petcard_score=460}},
			{43, new CfgJingmai{level=43,min_attack=2300,max_attack=4600,phy_defence=2500,magic_defence=2500,dex_defence=2500,max_hp=25000,need_silver=780000,need_petcard_score=500}},
			{44, new CfgJingmai{level=44,min_attack=2450,max_attack=4900,phy_defence=2700,magic_defence=2700,dex_defence=2700,max_hp=27000,need_silver=820000,need_petcard_score=540}},
			{45, new CfgJingmai{level=45,min_attack=2600,max_attack=5200,phy_defence=2900,magic_defence=2900,dex_defence=2900,max_hp=29000,need_silver=860000,need_petcard_score=580}},
			{46, new CfgJingmai{level=46,min_attack=2750,max_attack=5500,phy_defence=3100,magic_defence=3100,dex_defence=3100,max_hp=31000,need_silver=900000,need_petcard_score=620}},
			{47, new CfgJingmai{level=47,min_attack=2900,max_attack=5800,phy_defence=3300,magic_defence=3300,dex_defence=3300,max_hp=33000,need_silver=940000,need_petcard_score=660}},
			{48, new CfgJingmai{level=48,min_attack=3050,max_attack=6100,phy_defence=3500,magic_defence=3500,dex_defence=3500,max_hp=35000,need_silver=980000,need_petcard_score=700}},
			{49, new CfgJingmai{level=49,min_attack=3200,max_attack=6400,phy_defence=3700,magic_defence=3700,dex_defence=3700,max_hp=37000,need_silver=1020000,need_petcard_score=740}},
			{50, new CfgJingmai{level=50,min_attack=3350,max_attack=6700,phy_defence=3900,magic_defence=3900,dex_defence=3900,max_hp=39000,need_silver=1060000,need_petcard_score=780}},
			{51, new CfgJingmai{level=51,min_attack=3550,max_attack=7100,phy_defence=4200,magic_defence=4200,dex_defence=4200,max_hp=42000,need_silver=1120000,need_petcard_score=840}},
			{52, new CfgJingmai{level=52,min_attack=3750,max_attack=7500,phy_defence=4500,magic_defence=4500,dex_defence=4500,max_hp=45000,need_silver=1180000,need_petcard_score=900}},
			{53, new CfgJingmai{level=53,min_attack=3950,max_attack=7900,phy_defence=4800,magic_defence=4800,dex_defence=4800,max_hp=48000,need_silver=1240000,need_petcard_score=960}},
			{54, new CfgJingmai{level=54,min_attack=4150,max_attack=8300,phy_defence=5100,magic_defence=5100,dex_defence=5100,max_hp=51000,need_silver=1300000,need_petcard_score=1020}},
			{55, new CfgJingmai{level=55,min_attack=4350,max_attack=8700,phy_defence=5400,magic_defence=5400,dex_defence=5400,max_hp=54000,need_silver=1360000,need_petcard_score=1080}},
			{56, new CfgJingmai{level=56,min_attack=4550,max_attack=9100,phy_defence=5700,magic_defence=5700,dex_defence=5700,max_hp=57000,need_silver=1420000,need_petcard_score=1140}},
			{57, new CfgJingmai{level=57,min_attack=4750,max_attack=9500,phy_defence=6000,magic_defence=6000,dex_defence=6000,max_hp=60000,need_silver=1480000,need_petcard_score=1200}},
			{58, new CfgJingmai{level=58,min_attack=4950,max_attack=9900,phy_defence=6300,magic_defence=6300,dex_defence=6300,max_hp=63000,need_silver=1540000,need_petcard_score=1260}},
			{59, new CfgJingmai{level=59,min_attack=5150,max_attack=10300,phy_defence=6600,magic_defence=6600,dex_defence=6600,max_hp=66000,need_silver=1600000,need_petcard_score=1320}},
			{60, new CfgJingmai{level=60,min_attack=5350,max_attack=10700,phy_defence=6900,magic_defence=6900,dex_defence=6900,max_hp=69000,need_silver=1660000,need_petcard_score=1380}},
			{61, new CfgJingmai{level=61,min_attack=5650,max_attack=11300,phy_defence=7300,magic_defence=7300,dex_defence=7300,max_hp=73000,need_silver=1740000,need_petcard_score=1460}},
			{62, new CfgJingmai{level=62,min_attack=5950,max_attack=11900,phy_defence=7700,magic_defence=7700,dex_defence=7700,max_hp=77000,need_silver=1820000,need_petcard_score=1540}},
			{63, new CfgJingmai{level=63,min_attack=6250,max_attack=12500,phy_defence=8100,magic_defence=8100,dex_defence=8100,max_hp=81000,need_silver=1900000,need_petcard_score=1620}},
			{64, new CfgJingmai{level=64,min_attack=6550,max_attack=13100,phy_defence=8500,magic_defence=8500,dex_defence=8500,max_hp=85000,need_silver=1980000,need_petcard_score=1700}},
			{65, new CfgJingmai{level=65,min_attack=6850,max_attack=13700,phy_defence=8900,magic_defence=8900,dex_defence=8900,max_hp=89000,need_silver=2060000,need_petcard_score=1780}},
			{66, new CfgJingmai{level=66,min_attack=7150,max_attack=14300,phy_defence=9300,magic_defence=9300,dex_defence=9300,max_hp=93000,need_silver=2140000,need_petcard_score=1860}},
			{67, new CfgJingmai{level=67,min_attack=7450,max_attack=14900,phy_defence=9700,magic_defence=9700,dex_defence=9700,max_hp=97000,need_silver=2220000,need_petcard_score=1940}},
			{68, new CfgJingmai{level=68,min_attack=7750,max_attack=15500,phy_defence=10100,magic_defence=10100,dex_defence=10100,max_hp=101000,need_silver=2300000,need_petcard_score=2020}},
			{69, new CfgJingmai{level=69,min_attack=8050,max_attack=16100,phy_defence=10500,magic_defence=10500,dex_defence=10500,max_hp=105000,need_silver=2380000,need_petcard_score=2100}},
			{70, new CfgJingmai{level=70,min_attack=8350,max_attack=16700,phy_defence=10900,magic_defence=10900,dex_defence=10900,max_hp=109000,need_silver=2460000,need_petcard_score=2180}},
			{71, new CfgJingmai{level=71,min_attack=8650,max_attack=17300,phy_defence=11400,magic_defence=11400,dex_defence=11400,max_hp=114000,need_silver=2560000,need_petcard_score=2300}},
			{72, new CfgJingmai{level=72,min_attack=8950,max_attack=17900,phy_defence=11900,magic_defence=11900,dex_defence=11900,max_hp=119000,need_silver=2660000,need_petcard_score=2420}},
			{73, new CfgJingmai{level=73,min_attack=9250,max_attack=18500,phy_defence=12400,magic_defence=12400,dex_defence=12400,max_hp=124000,need_silver=2760000,need_petcard_score=2540}},
			{74, new CfgJingmai{level=74,min_attack=9550,max_attack=19100,phy_defence=12900,magic_defence=12900,dex_defence=12900,max_hp=129000,need_silver=2860000,need_petcard_score=2660}},
			{75, new CfgJingmai{level=75,min_attack=9850,max_attack=19700,phy_defence=13400,magic_defence=13400,dex_defence=13400,max_hp=134000,need_silver=2960000,need_petcard_score=2780}},
			{76, new CfgJingmai{level=76,min_attack=10150,max_attack=20300,phy_defence=13900,magic_defence=13900,dex_defence=13900,max_hp=139000,need_silver=3060000,need_petcard_score=2900}},
			{77, new CfgJingmai{level=77,min_attack=10450,max_attack=20900,phy_defence=14400,magic_defence=14400,dex_defence=14400,max_hp=144000,need_silver=3160000,need_petcard_score=3020}},
			{78, new CfgJingmai{level=78,min_attack=10750,max_attack=21500,phy_defence=14900,magic_defence=14900,dex_defence=14900,max_hp=149000,need_silver=3260000,need_petcard_score=3140}},
			{79, new CfgJingmai{level=79,min_attack=11050,max_attack=22100,phy_defence=15400,magic_defence=15400,dex_defence=15400,max_hp=154000,need_silver=3360000,need_petcard_score=3260}},
			{80, new CfgJingmai{level=80,min_attack=11350,max_attack=22700,phy_defence=15900,magic_defence=15900,dex_defence=15900,max_hp=159000,need_silver=3460000,need_petcard_score=3380}},
			{81, new CfgJingmai{level=81,min_attack=11750,max_attack=23500,phy_defence=16500,magic_defence=16500,dex_defence=16500,max_hp=165000,need_silver=3560000,need_petcard_score=3550}},
			{82, new CfgJingmai{level=82,min_attack=12150,max_attack=24300,phy_defence=17100,magic_defence=17100,dex_defence=17100,max_hp=171000,need_silver=3660000,need_petcard_score=3720}},
			{83, new CfgJingmai{level=83,min_attack=12550,max_attack=25100,phy_defence=17700,magic_defence=17700,dex_defence=17700,max_hp=177000,need_silver=3760000,need_petcard_score=3890}},
			{84, new CfgJingmai{level=84,min_attack=12950,max_attack=25900,phy_defence=18300,magic_defence=18300,dex_defence=18300,max_hp=183000,need_silver=3860000,need_petcard_score=4060}},
			{85, new CfgJingmai{level=85,min_attack=13350,max_attack=26700,phy_defence=18900,magic_defence=18900,dex_defence=18900,max_hp=189000,need_silver=3960000,need_petcard_score=4230}},
			{86, new CfgJingmai{level=86,min_attack=13750,max_attack=27500,phy_defence=19500,magic_defence=19500,dex_defence=19500,max_hp=195000,need_silver=4060000,need_petcard_score=4400}},
			{87, new CfgJingmai{level=87,min_attack=14150,max_attack=28300,phy_defence=20100,magic_defence=20100,dex_defence=20100,max_hp=201000,need_silver=4160000,need_petcard_score=4570}},
			{88, new CfgJingmai{level=88,min_attack=14550,max_attack=29100,phy_defence=20700,magic_defence=20700,dex_defence=20700,max_hp=207000,need_silver=4260000,need_petcard_score=4740}},
			{89, new CfgJingmai{level=89,min_attack=14950,max_attack=29900,phy_defence=21300,magic_defence=21300,dex_defence=21300,max_hp=213000,need_silver=4360000,need_petcard_score=4910}},
			{90, new CfgJingmai{level=90,min_attack=15350,max_attack=30700,phy_defence=21900,magic_defence=21900,dex_defence=21900,max_hp=219000,need_silver=4460000,need_petcard_score=5080}},
			{91, new CfgJingmai{level=91,min_attack=15750,max_attack=31500,phy_defence=22500,magic_defence=22500,dex_defence=22500,max_hp=225000,need_silver=4560000,need_petcard_score=5300}},
			{92, new CfgJingmai{level=92,min_attack=16150,max_attack=32300,phy_defence=23100,magic_defence=23100,dex_defence=23100,max_hp=231000,need_silver=4660000,need_petcard_score=5520}},
			{93, new CfgJingmai{level=93,min_attack=16550,max_attack=33100,phy_defence=23700,magic_defence=23700,dex_defence=23700,max_hp=237000,need_silver=4760000,need_petcard_score=5740}},
			{94, new CfgJingmai{level=94,min_attack=16950,max_attack=33900,phy_defence=24300,magic_defence=24300,dex_defence=24300,max_hp=243000,need_silver=4860000,need_petcard_score=5960}},
			{95, new CfgJingmai{level=95,min_attack=17350,max_attack=34700,phy_defence=24900,magic_defence=24900,dex_defence=24900,max_hp=249000,need_silver=4960000,need_petcard_score=6180}},
			{96, new CfgJingmai{level=96,min_attack=17750,max_attack=35500,phy_defence=25500,magic_defence=25500,dex_defence=25500,max_hp=255000,need_silver=5060000,need_petcard_score=6400}},
			{97, new CfgJingmai{level=97,min_attack=18150,max_attack=36300,phy_defence=26100,magic_defence=26100,dex_defence=26100,max_hp=261000,need_silver=5160000,need_petcard_score=6620}},
			{98, new CfgJingmai{level=98,min_attack=18550,max_attack=37100,phy_defence=26700,magic_defence=26700,dex_defence=26700,max_hp=267000,need_silver=5260000,need_petcard_score=6840}},
			{99, new CfgJingmai{level=99,min_attack=18950,max_attack=37900,phy_defence=27300,magic_defence=27300,dex_defence=27300,max_hp=273000,need_silver=5360000,need_petcard_score=7060}},
			{100, new CfgJingmai{level=100,min_attack=19350,max_attack=38700,phy_defence=27900,magic_defence=27900,dex_defence=27900,max_hp=279000,need_silver=99999999,need_petcard_score=99999999}}
		};
	}
}
