using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_common_error_toc:IncommingBase{
	//ID
	public int protocolID = 1401;

	//fields
	public int error_code = 0;
	public string error_str;
	public ArrayList args;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.error_code = ba.ReadInt();
		this.error_str = ba.ReadString();
		this.args = new ArrayList();
		ba.ReadIntArray(this.args);
	}
}