using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_scene_war_fb_enter_toc:IncommingBase{
	//ID
	public int protocolID = 7601;

	//fields
	public bool succ = true;
	public bool return_self = true;
	public string reason;
	public int reason_code = 0;
	public int fb_fee = 0;
	public int fb_times = 0;
	public int npc_id = 0;
	public int fb_type = 0;
	public int fb_level = 0;
	public int fb_id = 0;
	public int fb_seconds = 0;
	public int fb_max_times = 0;
	public bool is_ever_first = true;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.return_self = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.reason_code = ba.ReadInt();
		this.fb_fee = ba.ReadInt();
		this.fb_times = ba.ReadInt();
		this.npc_id = ba.ReadInt();
		this.fb_type = ba.ReadInt();
		this.fb_level = ba.ReadInt();
		this.fb_id = ba.ReadInt();
		this.fb_seconds = ba.ReadInt();
		this.fb_max_times = ba.ReadInt();
		this.is_ever_first = ba.ReadBoolean();
	}
}