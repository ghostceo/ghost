using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_broadcast_laba_toc:IncommingBase{
	//ID
	public int protocolID = 2919;

	//fields
	public bool succ = true;
	public bool return_self = true;
	public string reason;
	public string content;
	public int role_id = 0;
	public string role_name;
	public int sex = 0;
	public int faction_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.return_self = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.content = ba.ReadString();
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.sex = ba.ReadInt();
		this.faction_id = ba.ReadInt();
	}
}