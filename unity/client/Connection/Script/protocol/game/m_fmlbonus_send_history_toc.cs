using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fmlbonus_send_history_toc:IncommingBase{
	//ID
	public int protocolID = 20305;

	//fields
	public ArrayList member_ids;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.member_ids = new ArrayList();
		ba.ReadIntArray(this.member_ids);
	}
}