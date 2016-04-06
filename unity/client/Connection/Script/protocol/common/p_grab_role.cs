using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_grab_role:GameNetInfo{
	//fields
	public int role_id = 0;
	public int rank = 0;
	public int fight_power = 0;
	public int remain_chances = 0;
	public int max_chances = 0;
	public int next_recover_time = 0;
	public int added_chances = 0;
	public int protect_time = 0;
	public int buy_need_gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.rank = ba.ReadInt();
		this.fight_power = ba.ReadInt();
		this.remain_chances = ba.ReadInt();
		this.max_chances = ba.ReadInt();
		this.next_recover_time = ba.ReadInt();
		this.added_chances = ba.ReadInt();
		this.protect_time = ba.ReadInt();
		this.buy_need_gold = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.rank);
		ba.WriteInt(this.fight_power);
		ba.WriteInt(this.remain_chances);
		ba.WriteInt(this.max_chances);
		ba.WriteInt(this.next_recover_time);
		ba.WriteInt(this.added_chances);
		ba.WriteInt(this.protect_time);
		ba.WriteInt(this.buy_need_gold);
	}
}