using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_download_task_info_toc:IncommingBase{
	//ID
	public int protocolID = 20501;

	//fields
	public ArrayList status_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.status_list = new ArrayList();
		ba.ReadIntArray(this.status_list);
	}
}