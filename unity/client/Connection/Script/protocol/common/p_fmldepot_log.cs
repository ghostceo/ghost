using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_fmldepot_log:GameNetInfo{
	//fields
	public int log_time = 0;
	public string role_name;
	public int item_type_id = 0;
	public int item_color = 0;
	public int item_num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.log_time = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.item_type_id = ba.ReadInt();
		this.item_color = ba.ReadInt();
		this.item_num = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.log_time);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.item_type_id);
		ba.WriteInt(this.item_color);
		ba.WriteInt(this.item_num);
	}
}