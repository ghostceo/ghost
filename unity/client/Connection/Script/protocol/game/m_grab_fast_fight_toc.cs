using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_grab_fast_fight_toc:IncommingBase{
	//ID
	public int protocolID = 11009;

	//fields
	public int mirror_id = 0;
	public int item = 0;
	public int fight_times = 0;
	public p_prop grab_item;
	public int weiwang = 0;
	public int silver = 0;
	public ArrayList select_rewards;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.mirror_id = ba.ReadInt();
		this.item = ba.ReadInt();
		this.fight_times = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.grab_item = new p_prop();
			this.grab_item.fill2c(ba);
		}
		this.weiwang = ba.ReadInt();
		this.silver = ba.ReadInt();
		this.select_rewards = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_prop p = new p_prop();
			p.fill2c(ba);
			this.select_rewards.Add(p);
		}
	}
}