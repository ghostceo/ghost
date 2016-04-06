using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_scene_war_fb_link:GameNetInfo{
	//fields
	public int fb_type = 0;
	public int fb_level = 0;
	public int fb_id = 0;
	public int fb_seconds = 0;
	public int enter_fee = 0;
	public int fb_times = 0;
	public int fb_max_times = 0;
	public bool is_finished = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.fb_type = ba.ReadInt();
		this.fb_level = ba.ReadInt();
		this.fb_id = ba.ReadInt();
		this.fb_seconds = ba.ReadInt();
		this.enter_fee = ba.ReadInt();
		this.fb_times = ba.ReadInt();
		this.fb_max_times = ba.ReadInt();
		this.is_finished = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.fb_type);
		ba.WriteInt(this.fb_level);
		ba.WriteInt(this.fb_id);
		ba.WriteInt(this.fb_seconds);
		ba.WriteInt(this.enter_fee);
		ba.WriteInt(this.fb_times);
		ba.WriteInt(this.fb_max_times);
		ba.WriteBool(this.is_finished);
	}
}