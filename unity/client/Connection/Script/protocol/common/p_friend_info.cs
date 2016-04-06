using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_friend_info:GameNetInfo{
	//fields
	public int roleid = 0;
	public string rolename;
	public int type = 0;
	public int sex = 0;
	public int level = 0;
	public bool is_online = true;
	public string sign;
	public string family_name;
	public int vip_level = 0;
	public int fightpower = 0;
	public int category = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.roleid = ba.ReadInt();
		this.rolename = ba.ReadString();
		this.type = ba.ReadInt();
		this.sex = ba.ReadInt();
		this.level = ba.ReadInt();
		this.is_online = ba.ReadBoolean();
		this.sign = ba.ReadString();
		this.family_name = ba.ReadString();
		this.vip_level = ba.ReadInt();
		this.fightpower = ba.ReadInt();
		this.category = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.roleid);
		ba.WriteString(this.rolename);
		ba.WriteInt(this.type);
		ba.WriteInt(this.sex);
		ba.WriteInt(this.level);
		ba.WriteBool(this.is_online);
		ba.WriteString(this.sign);
		ba.WriteString(this.family_name);
		ba.WriteInt(this.vip_level);
		ba.WriteInt(this.fightpower);
		ba.WriteInt(this.category);
	}
}