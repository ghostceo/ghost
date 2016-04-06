using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_mount_list_toc:IncommingBase{
	//ID
	public int protocolID = 16700;

	//fields
	public ArrayList mounts;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.mounts = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_mount_info p = new p_mount_info();
			p.fill2c(ba);
			this.mounts.Add(p);
		}
	}
}