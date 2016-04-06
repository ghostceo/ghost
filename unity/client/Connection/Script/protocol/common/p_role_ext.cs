using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_ext:GameNetInfo{
	//fields
	public int role_id = 0;
	public string signature;
	public int birthday = 0;
	public int constellation = 0;
	public int country = 0;
	public int province = 0;
	public int city = 0;
	public string blog;
	public int family_last_op_time = 0;
	public int last_login_time = 0;
	public int last_offline_time = 0;
	public string role_name;
	public int sex = 0;
	public ArrayList open_systems;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.signature = ba.ReadString();
		this.birthday = ba.ReadInt();
		this.constellation = ba.ReadInt();
		this.country = ba.ReadInt();
		this.province = ba.ReadInt();
		this.city = ba.ReadInt();
		this.blog = ba.ReadString();
		this.family_last_op_time = ba.ReadInt();
		this.last_login_time = ba.ReadInt();
		this.last_offline_time = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.sex = ba.ReadInt();
		this.open_systems = new ArrayList();
		ba.ReadIntArray(this.open_systems);
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.signature);
		ba.WriteInt(this.birthday);
		ba.WriteInt(this.constellation);
		ba.WriteInt(this.country);
		ba.WriteInt(this.province);
		ba.WriteInt(this.city);
		ba.WriteString(this.blog);
		ba.WriteInt(this.family_last_op_time);
		ba.WriteInt(this.last_login_time);
		ba.WriteInt(this.last_offline_time);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.sex);
		ba.WriteIntArray(this.open_systems);
	}
}