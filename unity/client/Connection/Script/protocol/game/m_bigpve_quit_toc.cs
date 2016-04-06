using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_bigpve_quit_toc:IncommingBase{
	//ID
	public int protocolID = 10602;

	//fields
	public int err_code = 0;
	public string reason;
	public int type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.type = ba.ReadInt();
	}
}