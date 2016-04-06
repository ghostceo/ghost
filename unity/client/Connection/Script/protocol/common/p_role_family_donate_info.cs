using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_family_donate_info:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public int donate_amount = 0;
	public int left_donate_times = 0;
	public int update_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.donate_amount = ba.ReadInt();
		this.left_donate_times = ba.ReadInt();
		this.update_time = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.donate_amount);
		ba.WriteInt(this.left_donate_times);
		ba.WriteInt(this.update_time);
	}
}