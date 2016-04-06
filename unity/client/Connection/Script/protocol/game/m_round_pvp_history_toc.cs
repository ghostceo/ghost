using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_round_pvp_history_toc:IncommingBase{
	//ID
	public int protocolID = 10801;

	//fields
	public ArrayList datas;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.datas = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_round_pvp_history p = new p_round_pvp_history();
			p.fill2c(ba);
			this.datas.Add(p);
		}
	}
}