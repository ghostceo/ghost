using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_info_change_toc:IncommingBase{
	//ID
	public int protocolID = 3164;

	//fields
	public ArrayList changes;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.changes = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_info_change p = new p_family_info_change();
			p.fill2c(ba);
			this.changes.Add(p);
		}
	}
}