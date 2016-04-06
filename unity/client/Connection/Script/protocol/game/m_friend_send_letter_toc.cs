using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_send_letter_toc:IncommingBase{
	//ID
	public int protocolID = 1032;

	//fields
	public string name;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.name = ba.ReadString();
	}
}