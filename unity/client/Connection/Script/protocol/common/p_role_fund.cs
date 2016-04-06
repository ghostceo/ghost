using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_fund:GameNetInfo{
	//fields
	public int type = 0;
	public int end_time = 0;
	public int reset_time = 0;
	public int return_gold = 0;
	public int award_gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.end_time = ba.ReadInt();
		this.reset_time = ba.ReadInt();
		this.return_gold = ba.ReadInt();
		this.award_gold = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.type);
		ba.WriteInt(this.end_time);
		ba.WriteInt(this.reset_time);
		ba.WriteInt(this.return_gold);
		ba.WriteInt(this.award_gold);
	}
}