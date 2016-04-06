using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_room_list_tos:OutgoingBase{
	//ID
	public int protocolID = 17101;

	//fields
	public int room_type = 0;
	public int page_num = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(17101);
		ba.WriteInt(this.room_type);
		ba.WriteInt(this.page_num);
	}
}