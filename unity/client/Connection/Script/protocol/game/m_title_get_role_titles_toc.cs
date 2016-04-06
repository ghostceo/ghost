using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_title_get_role_titles_toc:IncommingBase{
	//ID
	public int protocolID = 4401;

	//fields
	public ArrayList titles;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.titles = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_title p = new p_title();
			p.fill2c(ba);
			this.titles.Add(p);
		}
	}
}