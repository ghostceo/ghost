using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_download_task_fetch_toc:IncommingBase{
	//ID
	public int protocolID = 20502;

	//fields
	public int task_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.task_id = ba.ReadInt();
	}
}