using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_newcomer_onlinetime_info_toc:IncommingBase{
	//ID
	public int protocolID = 5706;

	//fields
	public ArrayList next_reward_props;
	public int next_reward_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.next_reward_props = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_prop p = new p_reward_prop();
			p.fill2c(ba);
			this.next_reward_props.Add(p);
		}
		this.next_reward_time = ba.ReadInt();
	}
}