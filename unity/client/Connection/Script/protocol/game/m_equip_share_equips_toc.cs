using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_share_equips_toc:IncommingBase{
	//ID
	public int protocolID = 844;

	//fields
	public ArrayList share_equips;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.share_equips = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.share_equips.Add(p);
		}
	}
}