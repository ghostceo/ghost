using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_channel_info:GameNetInfo{
	//fields
	public string channel_sign;
	public int channel_type = 0;
	public string channel_name;
	public int online_num = 0;
	public int total_num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.channel_sign = ba.ReadString();
		this.channel_type = ba.ReadInt();
		this.channel_name = ba.ReadString();
		this.online_num = ba.ReadInt();
		this.total_num = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteString(this.channel_sign);
		ba.WriteInt(this.channel_type);
		ba.WriteString(this.channel_name);
		ba.WriteInt(this.online_num);
		ba.WriteInt(this.total_num);
	}
}