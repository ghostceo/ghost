using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_fb_rank:GameNetInfo{
	//fields
	public int family_id = 0;
	public int max_barrier = 0;
	public int role_id = 0;
	public int role_name = 0;
	public int category = 0;
	public int update_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.family_id = ba.ReadInt();
		this.max_barrier = ba.ReadInt();
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadInt();
		this.category = ba.ReadInt();
		this.update_time = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.family_id);
		ba.WriteInt(this.max_barrier);
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.role_name);
		ba.WriteInt(this.category);
		ba.WriteInt(this.update_time);
	}
}