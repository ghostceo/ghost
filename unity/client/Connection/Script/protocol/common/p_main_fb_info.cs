using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_main_fb_info:GameNetInfo{
	//fields
	public int open_barrier_id = 0;
	public int open_barrier_status = 0;
	public int hanging_barrier_id = 0;
	public int remain_count = 0;
	public int buy_count = 0;
	public int guide_quick_count = 0;
	public int quick_count = 0;
	public int finish_count = 0;
	public int remain_double_count = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.open_barrier_id = ba.ReadInt();
		this.open_barrier_status = ba.ReadInt();
		this.hanging_barrier_id = ba.ReadInt();
		this.remain_count = ba.ReadInt();
		this.buy_count = ba.ReadInt();
		this.guide_quick_count = ba.ReadInt();
		this.quick_count = ba.ReadInt();
		this.finish_count = ba.ReadInt();
		this.remain_double_count = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.open_barrier_id);
		ba.WriteInt(this.open_barrier_status);
		ba.WriteInt(this.hanging_barrier_id);
		ba.WriteInt(this.remain_count);
		ba.WriteInt(this.buy_count);
		ba.WriteInt(this.guide_quick_count);
		ba.WriteInt(this.quick_count);
		ba.WriteInt(this.finish_count);
		ba.WriteInt(this.remain_double_count);
	}
}