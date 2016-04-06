using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_attr_change_toc:IncommingBase{
	//ID
	public int protocolID = 501;

	//fields
	public int roleid = 0;
	public ArrayList changes;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.roleid = ba.ReadInt();
		this.changes = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_role_attr_change p = new p_role_attr_change();
			p.fill2c(ba);
			this.changes.Add(p);
		}
	}
}