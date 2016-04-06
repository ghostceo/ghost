using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_bigpve_boss_dead_toc:IncommingBase{
	//ID
	public int protocolID = 10605;

	//fields
	public string boss_name;
	public double score = 0;
	public int rank = 3;
	public double add_exp = 0;
	public int add_prestige = 0;
	public string killer_name;
	public double killer_add_exp = 0;
	public int killer_add_prestige = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.boss_name = ba.ReadString();
		this.score = ba.ReadDouble();
		this.rank = ba.ReadInt();
		this.add_exp = ba.ReadDouble();
		this.add_prestige = ba.ReadInt();
		this.killer_name = ba.ReadString();
		this.killer_add_exp = ba.ReadDouble();
		this.killer_add_prestige = ba.ReadInt();
	}
}