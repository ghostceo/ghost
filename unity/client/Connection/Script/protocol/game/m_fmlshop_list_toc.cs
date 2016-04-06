using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fmlshop_list_toc:IncommingBase{
	//ID
	public int protocolID = 4901;

	//fields
	public ArrayList items;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.items = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_fmlshop_item p = new p_fmlshop_item();
			p.fill2c(ba);
			this.items.Add(p);
		}
	}
}