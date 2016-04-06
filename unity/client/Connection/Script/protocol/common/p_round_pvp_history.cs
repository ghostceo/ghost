using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_round_pvp_history:GameNetInfo{
	//fields
	public int rank = 0;
	public string role_name;
	public int role_id = 0;
	public int mount = 0;
	public int fashion = 0;
	public int sex = 0;
	public int category = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rank = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.role_id = ba.ReadInt();
		this.mount = ba.ReadInt();
		this.fashion = ba.ReadInt();
		this.sex = ba.ReadInt();
		this.category = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.rank);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.mount);
		ba.WriteInt(this.fashion);
		ba.WriteInt(this.sex);
		ba.WriteInt(this.category);
	}
}