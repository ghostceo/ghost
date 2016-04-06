using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_accept_toc:IncommingBase{
	//ID
	public int protocolID = 1002;

	//fields
	public bool succ = true;
	public string name;
	public p_friend_info friend_info;
	public string reason;
	public bool return_self = true;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.name = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.friend_info = new p_friend_info();
			this.friend_info.fill2c(ba);
		}
		this.reason = ba.ReadString();
		this.return_self = ba.ReadBoolean();
	}
}