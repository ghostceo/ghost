using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_chat_title:GameNetInfo{
	//fields
	public int id = 0;
	public string name;
	public string color;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.name = ba.ReadString();
		this.color = ba.ReadString();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteString(this.name);
		ba.WriteString(this.color);
	}
}