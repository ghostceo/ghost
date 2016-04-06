using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_letter_simple_info:GameNetInfo{
	//fields
	public int id = 0;
	public string sender;
	public string receiver;
	public string title;
	public int send_time = 0;
	public int type = 0;
	public int state = 0;
	public bool is_have_goods = false;
	public int table = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.sender = ba.ReadString();
		this.receiver = ba.ReadString();
		this.title = ba.ReadString();
		this.send_time = ba.ReadInt();
		this.type = ba.ReadInt();
		this.state = ba.ReadInt();
		this.is_have_goods = ba.ReadBoolean();
		this.table = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteString(this.sender);
		ba.WriteString(this.receiver);
		ba.WriteString(this.title);
		ba.WriteInt(this.send_time);
		ba.WriteInt(this.type);
		ba.WriteInt(this.state);
		ba.WriteBool(this.is_have_goods);
		ba.WriteInt(this.table);
	}
}