using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_item_extend_bag_row_toc:IncommingBase{
	//ID
	public int protocolID = 1109;

	//fields
	public bool succ = true;
	public int reason_code = 0;
	public int bagid = 0;
	public int rows = 0;
	public int columns = 0;
	public int grid_number = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason_code = ba.ReadInt();
		this.bagid = ba.ReadInt();
		this.rows = ba.ReadInt();
		this.columns = ba.ReadInt();
		this.grid_number = ba.ReadInt();
	}
}