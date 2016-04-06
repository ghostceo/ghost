using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_round_pvp_rank:GameNetInfo{
	//fields
	public int rank = 0;
	public int role_id = 0;
	public string role_name;
	public int win_count = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rank = ba.ReadInt();
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.win_count = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.rank);
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.win_count);
	}
}