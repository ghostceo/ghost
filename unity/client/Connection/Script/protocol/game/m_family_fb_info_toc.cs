using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_fb_info_toc:IncommingBase{
	//ID
	public int protocolID = 11401;

	//fields
	public int barrier_id = 0;
	public ArrayList buffs;
	public p_family_fb_rank rank;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.barrier_id = ba.ReadInt();
		this.buffs = new ArrayList();
		ba.ReadIntArray(this.buffs);
		if(ba.ReadByte() == 1){
			this.rank = new p_family_fb_rank();
			this.rank.fill2c(ba);
		}
	}
}