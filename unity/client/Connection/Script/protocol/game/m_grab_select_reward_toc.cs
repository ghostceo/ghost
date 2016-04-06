using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_grab_select_reward_toc:IncommingBase{
	//ID
	public int protocolID = 11006;

	//fields
	public int select_num = 0;
	public ArrayList select_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.select_num = ba.ReadInt();
		this.select_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_prop p = new p_prop();
			p.fill2c(ba);
			this.select_list.Add(p);
		}
	}
}