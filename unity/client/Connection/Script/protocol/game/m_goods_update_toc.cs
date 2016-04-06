using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_goods_update_toc:IncommingBase{
	//ID
	public int protocolID = 2006;

	//fields
	public ArrayList del_list;
	public ArrayList update_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.del_list = new ArrayList();
		ba.ReadIntArray(this.del_list);
		this.update_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.update_list.Add(p);
		}
	}
}