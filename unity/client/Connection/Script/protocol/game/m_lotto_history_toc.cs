using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_lotto_history_toc:IncommingBase{
	//ID
	public int protocolID = 1903;

	//fields
	public ArrayList his_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.his_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_lotto_his p = new p_lotto_his();
			p.fill2c(ba);
			this.his_list.Add(p);
		}
	}
}