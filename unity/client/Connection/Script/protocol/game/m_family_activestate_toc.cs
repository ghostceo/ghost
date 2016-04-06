using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_activestate_toc:IncommingBase{
	//ID
	public int protocolID = 3169;

	//fields
	public bool succ = true;
	public ArrayList familytasklist;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.familytasklist = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_task p = new p_family_task();
			p.fill2c(ba);
			this.familytasklist.Add(p);
		}
	}
}