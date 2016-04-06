using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_fb_result_toc:IncommingBase{
	//ID
	public int protocolID = 11403;

	//fields
	public int barrier_id = 0;
	public bool is_win = false;
	public ArrayList rewards;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.barrier_id = ba.ReadInt();
		this.is_win = ba.ReadBoolean();
		this.rewards = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_prop p = new p_prop();
			p.fill2c(ba);
			this.rewards.Add(p);
		}
	}
}