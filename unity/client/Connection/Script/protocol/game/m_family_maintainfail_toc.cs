using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_maintainfail_toc:IncommingBase{
	//ID
	public int protocolID = 3141;

	//fields
	public string message;
	public int result = 0;
	public int new_level = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.message = ba.ReadString();
		this.result = ba.ReadInt();
		this.new_level = ba.ReadInt();
	}
}