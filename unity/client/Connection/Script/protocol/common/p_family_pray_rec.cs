using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_pray_rec:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public int pray_type = 0;
	public int add_family_active_points = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.pray_type = ba.ReadInt();
		this.add_family_active_points = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.pray_type);
		ba.WriteInt(this.add_family_active_points);
	}
}