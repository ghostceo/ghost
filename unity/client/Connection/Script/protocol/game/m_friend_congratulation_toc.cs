using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_congratulation_toc:IncommingBase{
	//ID
	public int protocolID = 1020;

	//fields
	public bool succ = true;
	public bool return_self = true;
	public string reason;
	public int exp_add = 0;
	public int hyd_add = 0;
	public string from_friend;
	public string congratulation;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.return_self = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.exp_add = ba.ReadInt();
		this.hyd_add = ba.ReadInt();
		this.from_friend = ba.ReadString();
		this.congratulation = ba.ReadString();
	}
}