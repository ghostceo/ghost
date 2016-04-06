using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_request_toc:IncommingBase{
	//ID
	public int protocolID = 1001;

	//fields
	public bool succ = true;
	public string name;
	public string reason;
	public bool return_self = true;
	public bool isopenwindow = false;
	public p_friend_info friend_info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.name = ba.ReadString();
		this.reason = ba.ReadString();
		this.return_self = ba.ReadBoolean();
		this.isopenwindow = ba.ReadBoolean();
		if(ba.ReadByte() == 1){
			this.friend_info = new p_friend_info();
			this.friend_info.fill2c(ba);
		}
	}
}