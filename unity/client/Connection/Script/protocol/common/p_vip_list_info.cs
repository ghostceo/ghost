using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_vip_list_info:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public int skin_id = 0;
	public int level = 0;
	public int faction_id = 0;
	public string family_name;
	public int total_time = 0;
	public bool is_online = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.skin_id = ba.ReadInt();
		this.level = ba.ReadInt();
		this.faction_id = ba.ReadInt();
		this.family_name = ba.ReadString();
		this.total_time = ba.ReadInt();
		this.is_online = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.skin_id);
		ba.WriteInt(this.level);
		ba.WriteInt(this.faction_id);
		ba.WriteString(this.family_name);
		ba.WriteInt(this.total_time);
		ba.WriteBool(this.is_online);
	}
}