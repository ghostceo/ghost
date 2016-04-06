using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_title:GameNetInfo{
	//fields
	public int id = 0;
	public string name;
	public int type = 0;
	public bool auto_timeout = false;
	public int timeout_time = 0;
	public int role_id = 0;
	public bool show_in_chat = false;
	public bool show_in_sence = false;
	public string color;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.name = ba.ReadString();
		this.type = ba.ReadInt();
		this.auto_timeout = ba.ReadBoolean();
		this.timeout_time = ba.ReadInt();
		this.role_id = ba.ReadInt();
		this.show_in_chat = ba.ReadBoolean();
		this.show_in_sence = ba.ReadBoolean();
		this.color = ba.ReadString();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteString(this.name);
		ba.WriteInt(this.type);
		ba.WriteBool(this.auto_timeout);
		ba.WriteInt(this.timeout_time);
		ba.WriteInt(this.role_id);
		ba.WriteBool(this.show_in_chat);
		ba.WriteBool(this.show_in_sence);
		ba.WriteString(this.color);
	}
}