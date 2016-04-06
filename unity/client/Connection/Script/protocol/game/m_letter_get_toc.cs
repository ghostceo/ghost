using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_letter_get_toc:IncommingBase{
	//ID
	public int protocolID = 2104;

	//fields
	public ArrayList letters;
	public int request_mark = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.letters = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_letter_simple_info p = new p_letter_simple_info();
			p.fill2c(ba);
			this.letters.Add(p);
		}
		this.request_mark = ba.ReadInt();
	}
}