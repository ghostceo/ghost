using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_vip:GameNetInfo{
	//fields
	public int role_id = 0;
	public int end_time = 0;
	public int vip_level = 0;
	public int mission_transfer_times = 0;
	public bool is_transfer_notice_free = false;
	public bool is_transfer_notice = false;
	public bool is_expire = false;
	public int cur_jifen = 0;
	public int total_jifen = 0;
	public int next_level_jifen = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.end_time = ba.ReadInt();
		this.vip_level = ba.ReadInt();
		this.mission_transfer_times = ba.ReadInt();
		this.is_transfer_notice_free = ba.ReadBoolean();
		this.is_transfer_notice = ba.ReadBoolean();
		this.is_expire = ba.ReadBoolean();
		this.cur_jifen = ba.ReadInt();
		this.total_jifen = ba.ReadInt();
		this.next_level_jifen = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.end_time);
		ba.WriteInt(this.vip_level);
		ba.WriteInt(this.mission_transfer_times);
		ba.WriteBool(this.is_transfer_notice_free);
		ba.WriteBool(this.is_transfer_notice);
		ba.WriteBool(this.is_expire);
		ba.WriteInt(this.cur_jifen);
		ba.WriteInt(this.total_jifen);
		ba.WriteInt(this.next_level_jifen);
	}
}