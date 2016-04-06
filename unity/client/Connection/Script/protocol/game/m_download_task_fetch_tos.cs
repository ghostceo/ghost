using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_download_task_fetch_tos:OutgoingBase{
	//ID
	public int protocolID = 20502;

	//fields
	public int task_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(20502);
		ba.WriteInt(this.task_id);
	}
}