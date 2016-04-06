using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_super_mission_info_toc:IncommingBase{
	//ID
	public int protocolID = 18502;

	//fields
	public int need_pay = 0;
	public int today_pay = 0;
	public ArrayList task_list;
	public int cost_gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.need_pay = ba.ReadInt();
		this.today_pay = ba.ReadInt();
		this.task_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_super_task p = new p_super_task();
			p.fill2c(ba);
			this.task_list.Add(p);
		}
		this.cost_gold = ba.ReadInt();
	}
}