using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_bigpve_result_toc:IncommingBase{
	//ID
	public int protocolID = 10607;

	//fields
	public int rank = 1;
	public double total_add_exp = 2;
	public int total_add_prestige = 0;
	public double total_score = 0;
	public int bomb_use_num = 0;
	public int kill_num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rank = ba.ReadInt();
		this.total_add_exp = ba.ReadDouble();
		this.total_add_prestige = ba.ReadInt();
		this.total_score = ba.ReadDouble();
		this.bomb_use_num = ba.ReadInt();
		this.kill_num = ba.ReadInt();
	}
}