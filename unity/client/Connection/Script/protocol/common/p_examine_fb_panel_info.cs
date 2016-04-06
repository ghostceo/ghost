using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_examine_fb_panel_info:GameNetInfo{
	//fields
	public ArrayList open_barriers;
	public ArrayList barrier_records;
	public int last_enter_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.open_barriers = new ArrayList();
		ba.ReadIntArray(this.open_barriers);
		this.barrier_records = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_examine_fb_barrier p = new p_examine_fb_barrier();
			p.fill2c(ba);
			this.barrier_records.Add(p);
		}
		this.last_enter_time = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteIntArray(this.open_barriers);
		for (int i = 0; i < barrier_records.Count; i++){
		((p_examine_fb_barrier)this.barrier_records[i]).fill2s(ba);		}
		ba.WriteInt(this.last_enter_time);
	}
}