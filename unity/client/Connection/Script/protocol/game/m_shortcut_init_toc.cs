using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shortcut_init_toc:IncommingBase{
	//ID
	public int protocolID = 3201;

	//fields
	public ArrayList shortcut_list;
	public int selected = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.shortcut_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_shortcut p = new p_shortcut();
			p.fill2c(ba);
			this.shortcut_list.Add(p);
		}
		this.selected = ba.ReadInt();
	}
}