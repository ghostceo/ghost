using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_main_fb_pass_boss_toc:IncommingBase{
	//ID
	public int protocolID = 8106;

	//fields
	public bool is_beaten = false;
	public string mirror_name;
	public bool is_double = false;
	public int exp = 0;
	public int silver = 0;
	public ArrayList item_drop_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.is_beaten = ba.ReadBoolean();
		this.mirror_name = ba.ReadString();
		this.is_double = ba.ReadBoolean();
		this.exp = ba.ReadInt();
		this.silver = ba.ReadInt();
		this.item_drop_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_prop p = new p_reward_prop();
			p.fill2c(ba);
			this.item_drop_list.Add(p);
		}
	}
}