using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_hanging_round_start_toc:IncommingBase{
	//ID
	public int protocolID = 2312;

	//fields
	public p_hanging_round hanging_round;
	public ArrayList fb_buffs;
	public bool is_guide_dialog = false;
	public int succ_rate = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.hanging_round = new p_hanging_round();
			this.hanging_round.fill2c(ba);
		}
		this.fb_buffs = new ArrayList();
		ba.ReadIntArray(this.fb_buffs);
		this.is_guide_dialog = ba.ReadBoolean();
		this.succ_rate = ba.ReadInt();
	}
}