using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_war_score:GameNetInfo{
	//fields
	public int rank = 0;
	public string family_name;
	public int score = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rank = ba.ReadInt();
		this.family_name = ba.ReadString();
		this.score = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.rank);
		ba.WriteString(this.family_name);
		ba.WriteInt(this.score);
	}
}