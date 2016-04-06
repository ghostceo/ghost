using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_goods_tidy_toc:IncommingBase{
	//ID
	public int protocolID = 2007;

	//fields
	public int bagid = 0;
	public ArrayList goods;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.bagid = ba.ReadInt();
		this.goods = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.goods.Add(p);
		}
	}
}