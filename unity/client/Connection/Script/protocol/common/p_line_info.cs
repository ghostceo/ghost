using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_line_info:GameNetInfo{
	//fields
	public string guid;
	public string ip;
	public int port = 0;
	public string line;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.guid = ba.ReadString();
		this.ip = ba.ReadString();
		this.port = ba.ReadInt();
		this.line = ba.ReadString();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteString(this.guid);
		ba.WriteString(this.ip);
		ba.WriteInt(this.port);
		ba.WriteString(this.line);
	}
}