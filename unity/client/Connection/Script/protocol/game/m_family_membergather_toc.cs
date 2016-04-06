using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_membergather_toc:IncommingBase{
	//ID
	public int protocolID = 3143;

	//fields
	public string message;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.message = ba.ReadString();
	}
}