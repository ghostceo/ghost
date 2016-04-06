using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_chat_channel_role_info:GameNetInfo{
	//fields
	public string channel_sign;
	public int channel_type = 0;
	public int role_id = 0;
	public string role_name;
	public int sex = 0;
	public int faction_id = 0;
	public string office_name;
	public int head = 0;
	public string sign;
	public bool is_online = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.channel_sign = ba.ReadString();
		this.channel_type = ba.ReadInt();
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.sex = ba.ReadInt();
		this.faction_id = ba.ReadInt();
		this.office_name = ba.ReadString();
		this.head = ba.ReadInt();
		this.sign = ba.ReadString();
		this.is_online = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteString(this.channel_sign);
		ba.WriteInt(this.channel_type);
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.sex);
		ba.WriteInt(this.faction_id);
		ba.WriteString(this.office_name);
		ba.WriteInt(this.head);
		ba.WriteString(this.sign);
		ba.WriteBool(this.is_online);
	}
}