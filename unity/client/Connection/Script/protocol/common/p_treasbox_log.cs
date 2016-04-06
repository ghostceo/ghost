using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_treasbox_log:GameNetInfo{
	//fields
	public int role_id = 0;
	public int role_sex = 0;
	public string role_name;
	public int faction_id = 0;
	public int award_time = 0;
	public ArrayList box_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_sex = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.faction_id = ba.ReadInt();
		this.award_time = ba.ReadInt();
		this.box_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_prop p = new p_reward_prop();
			p.fill2c(ba);
			this.box_list.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.role_sex);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.award_time);
		for (int i = 0; i < box_list.Count; i++){
		((p_reward_prop)this.box_list[i]).fill2s(ba);		}
	}
}