using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_single_fb:GameNetInfo{
	//fields
	public int type = 0;
	public int fight_times = 0;
	public int max_times = 0;
	public int open_lv = 0;
	public bool is_open = false;
	public int cd_end_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.fight_times = ba.ReadInt();
		this.max_times = ba.ReadInt();
		this.open_lv = ba.ReadInt();
		this.is_open = ba.ReadBoolean();
		this.cd_end_time = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.type);
		ba.WriteInt(this.fight_times);
		ba.WriteInt(this.max_times);
		ba.WriteInt(this.open_lv);
		ba.WriteBool(this.is_open);
		ba.WriteInt(this.cd_end_time);
	}
}