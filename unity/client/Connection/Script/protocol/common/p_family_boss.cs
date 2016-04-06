using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_boss:GameNetInfo{
	//fields
	public int boss_type = 0;
	public int boss_feed_lv = 0;
	public int boss_id = 0;
	public int boss_exp = 0;
	public int boss_lv_up_exp = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.boss_type = ba.ReadInt();
		this.boss_feed_lv = ba.ReadInt();
		this.boss_id = ba.ReadInt();
		this.boss_exp = ba.ReadInt();
		this.boss_lv_up_exp = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.boss_type);
		ba.WriteInt(this.boss_feed_lv);
		ba.WriteInt(this.boss_id);
		ba.WriteInt(this.boss_exp);
		ba.WriteInt(this.boss_lv_up_exp);
	}
}