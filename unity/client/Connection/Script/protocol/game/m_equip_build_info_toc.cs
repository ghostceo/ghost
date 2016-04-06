using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_build_info_toc:IncommingBase{
	//ID
	public int protocolID = 830;

	//fields
	public int build_score = 0;
	public int petcard_score = 0;
	public int left_normal_times = 0;
	public p_goods current_equip;
	public int refresh_gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.build_score = ba.ReadInt();
		this.petcard_score = ba.ReadInt();
		this.left_normal_times = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.current_equip = new p_goods();
			this.current_equip.fill2c(ba);
		}
		this.refresh_gold = ba.ReadInt();
	}
}