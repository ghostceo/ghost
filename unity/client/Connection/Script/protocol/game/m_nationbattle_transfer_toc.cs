using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_nationbattle_transfer_toc:IncommingBase{
	//ID
	public int protocolID = 9103;

	//fields
	public int role_id = 0;
	public int error_code = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.error_code = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}