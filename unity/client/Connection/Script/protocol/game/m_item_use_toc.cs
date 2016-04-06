using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_item_use_toc:IncommingBase{
	//ID
	public int protocolID = 1102;

	//fields
	public bool succ = true;
	public ArrayList reason;
	public int itemid = 0;
	public int type_id = 0;
	public int rest = 0;
	public int reason_code = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = new ArrayList();
		ba.ReadStringArray(this.reason);
		this.itemid = ba.ReadInt();
		this.type_id = ba.ReadInt();
		this.rest = ba.ReadInt();
		this.reason_code = ba.ReadInt();
	}
}