using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_room_member:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public int role_level = 0;
	public int role_sex = 0;
	public int role_category = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.role_level = ba.ReadInt();
		this.role_sex = ba.ReadInt();
		this.role_category = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.role_level);
		ba.WriteInt(this.role_sex);
		ba.WriteInt(this.role_category);
	}
}