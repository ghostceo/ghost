using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_update_toc:IncommingBase{
	//ID
	public int protocolID = 816;

	//fields
	public int pet_id = 0;
	public ArrayList equips;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pet_id = ba.ReadInt();
		this.equips = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.equips.Add(p);
		}
	}
}