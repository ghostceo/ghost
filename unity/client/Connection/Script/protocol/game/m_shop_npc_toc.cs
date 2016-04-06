using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shop_npc_toc:IncommingBase{
	//ID
	public int protocolID = 1305;

	//fields
	public int npc_id = 0;
	public ArrayList shops;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.npc_id = ba.ReadInt();
		this.shops = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_shop_info p = new p_shop_info();
			p.fill2c(ba);
			this.shops.Add(p);
		}
	}
}