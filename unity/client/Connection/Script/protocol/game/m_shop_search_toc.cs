using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shop_search_toc:IncommingBase{
	//ID
	public int protocolID = 1304;

	//fields
	public ArrayList search_all_goods;
	public int npc_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.search_all_goods = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_shop_goods_info p = new p_shop_goods_info();
			p.fill2c(ba);
			this.search_all_goods.Add(p);
		}
		this.npc_id = ba.ReadInt();
	}
}