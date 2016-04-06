using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_depot_tidy_toc:IncommingBase{
	//ID
	public int protocolID = 2708;

	//fields
	public bool succ = false;
	public int bagid = 0;
	public ArrayList goods_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.bagid = ba.ReadInt();
		this.goods_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.goods_list.Add(p);
		}
	}
}