using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_rnkm_role:GameNetInfo{
	//fields
	public int role_id = 0;
	public int rank = 0;
	public int fight_power = 0;
	public int remain_chances = 0;
	public int added_chances = 0;
	public int score = 0;
	public int chlg_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.rank = ba.ReadInt();
		this.fight_power = ba.ReadInt();
		this.remain_chances = ba.ReadInt();
		this.added_chances = ba.ReadInt();
		this.score = ba.ReadInt();
		this.chlg_time = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.rank);
		ba.WriteInt(this.fight_power);
		ba.WriteInt(this.remain_chances);
		ba.WriteInt(this.added_chances);
		ba.WriteInt(this.score);
		ba.WriteInt(this.chlg_time);
	}
}