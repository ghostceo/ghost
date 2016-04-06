using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_vip_gift_toc:IncommingBase{
	//ID
	public int protocolID = 7415;

	//fields
	public bool succ = false;
	public string reason;
	public int type = 0;
	public ArrayList fetched_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.type = ba.ReadInt();
		this.fetched_list = new ArrayList();
		ba.ReadIntArray(this.fetched_list);
	}
}