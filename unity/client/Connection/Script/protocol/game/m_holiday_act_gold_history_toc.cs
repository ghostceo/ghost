using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_holiday_act_gold_history_toc:IncommingBase{
	//ID
	public int protocolID = 20103;

	//fields
	public ArrayList history;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.history = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_holiday_gold_act_history p = new p_holiday_gold_act_history();
			p.fill2c(ba);
			this.history.Add(p);
		}
	}
}