using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_foster_refresh_toc:IncommingBase{
	//ID
	public int protocolID = 834;

	//fields
	public int foster_type = 0;
	public int pet_id = 0;
	public int equip_id = 0;
	public ArrayList result;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.foster_type = ba.ReadInt();
		this.pet_id = ba.ReadInt();
		this.equip_id = ba.ReadInt();
		this.result = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_attr p = new p_attr();
			p.fill2c(ba);
			this.result.Add(p);
		}
	}
}