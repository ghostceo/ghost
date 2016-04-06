using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_jingjie_condition:GameNetInfo{
	//fields
	public int type = 0;
	public string cur_val;
	public int need_val = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.cur_val = ba.ReadString();
		this.need_val = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.type);
		ba.WriteString(this.cur_val);
		ba.WriteInt(this.need_val);
	}
}