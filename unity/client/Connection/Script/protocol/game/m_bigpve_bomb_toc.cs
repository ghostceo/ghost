using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_bigpve_bomb_toc:IncommingBase{
	//ID
	public int protocolID = 10608;

	//fields
	public bool return_self = false;
	public int monster_id = 2;
	public double reduce_hp = 3;
	public int add_prestige = 0;
	public int prestige_ratio = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.return_self = ba.ReadBoolean();
		this.monster_id = ba.ReadInt();
		this.reduce_hp = ba.ReadDouble();
		this.add_prestige = ba.ReadInt();
		this.prestige_ratio = ba.ReadInt();
	}
}