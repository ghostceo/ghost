using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_lotto_info_toc:IncommingBase{
	//ID
	public int protocolID = 1902;

	//fields
	public int left_times = 0;
	public int acc_times = 0;
	public int need_gold = 0;
	public int total_bonus = 0;
	public int add_bonus = 0;
	public ArrayList prop_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.left_times = ba.ReadInt();
		this.acc_times = ba.ReadInt();
		this.need_gold = ba.ReadInt();
		this.total_bonus = ba.ReadInt();
		this.add_bonus = ba.ReadInt();
		this.prop_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_prop p = new p_prop();
			p.fill2c(ba);
			this.prop_list.Add(p);
		}
	}
}