using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_member_info:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public string title;
	public string office_name;
	public int family_contribution = 0;
	public int sex = 0;
	public int head = 0;
	public bool online = false;
	public int role_level = 0;
	public int last_login_time = 0;
	public int role_category = 0;
	public int fight_power = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.title = ba.ReadString();
		this.office_name = ba.ReadString();
		this.family_contribution = ba.ReadInt();
		this.sex = ba.ReadInt();
		this.head = ba.ReadInt();
		this.online = ba.ReadBoolean();
		this.role_level = ba.ReadInt();
		this.last_login_time = ba.ReadInt();
		this.role_category = ba.ReadInt();
		this.fight_power = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteString(this.title);
		ba.WriteString(this.office_name);
		ba.WriteInt(this.family_contribution);
		ba.WriteInt(this.sex);
		ba.WriteInt(this.head);
		ba.WriteBool(this.online);
		ba.WriteInt(this.role_level);
		ba.WriteInt(this.last_login_time);
		ba.WriteInt(this.role_category);
		ba.WriteInt(this.fight_power);
	}
}