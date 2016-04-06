using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_letter_delete_toc:IncommingBase{
	//ID
	public int protocolID = 2108;

	//fields
	public bool succ = false;
	public ArrayList no_del;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.no_del = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_letter_delete p = new p_letter_delete();
			p.fill2c(ba);
			this.no_del.Add(p);
		}
		this.reason = ba.ReadString();
	}
}