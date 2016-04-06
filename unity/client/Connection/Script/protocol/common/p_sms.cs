using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_sms:GameNetInfo{
	//fields
	public int sms_type = 0;
	public string content;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.sms_type = ba.ReadInt();
		this.content = ba.ReadString();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.sms_type);
		ba.WriteString(this.content);
	}
}