using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_item_extend_bag_row_tos:OutgoingBase{
	//ID
	public int protocolID = 1109;

	//fields
	public int row = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1109);
		ba.WriteInt(this.row);
	}
}