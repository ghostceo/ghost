using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_fmlmatch_family_rank:GameNetInfo{
	//fields
	public int rank = 0;
	public int family_id = 0;
	public string family_name;
	public int family_score = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rank = ba.ReadInt();
		this.family_id = ba.ReadInt();
		this.family_name = ba.ReadString();
		this.family_score = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.rank);
		ba.WriteInt(this.family_id);
		ba.WriteString(this.family_name);
		ba.WriteInt(this.family_score);
	}
}