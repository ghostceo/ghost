using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_invite_info:GameNetInfo{
	//fields
	public int target_role_id = 0;
	public int family_id = 0;
	public string family_name;
	public int src_role_id = 0;
	public string src_role_name;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.target_role_id = ba.ReadInt();
		this.family_id = ba.ReadInt();
		this.family_name = ba.ReadString();
		this.src_role_id = ba.ReadInt();
		this.src_role_name = ba.ReadString();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.target_role_id);
		ba.WriteInt(this.family_id);
		ba.WriteString(this.family_name);
		ba.WriteInt(this.src_role_id);
		ba.WriteString(this.src_role_name);
	}
}