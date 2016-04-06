using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_hanging_fb_result_toc:IncommingBase{
	//ID
	public int protocolID = 2315;

	//fields
	public int battle_type = 0;
	public int result = 0;
	public bool is_pass = false;
	public int exp = 0;
	public int silver = 0;
	public ArrayList rewards;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.battle_type = ba.ReadInt();
		this.result = ba.ReadInt();
		this.is_pass = ba.ReadBoolean();
		this.exp = ba.ReadInt();
		this.silver = ba.ReadInt();
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