using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_present_info:GameNetInfo{
	//fields
	public int present_id = 0;
	public ArrayList prop_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.present_id = ba.ReadInt();
		this.prop_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_prop p = new p_reward_prop();
			p.fill2c(ba);
			this.prop_list.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.present_id);
		for (int i = 0; i < prop_list.Count; i++){
		((p_reward_prop)this.prop_list[i]).fill2s(ba);		}
	}
}