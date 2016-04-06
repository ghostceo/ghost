using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_yunying_info_toc:IncommingBase{
	//ID
	public int protocolID = 5628;

	//fields
	public int activity_id = 0;
	public int gold_info = 0;
	public int err_code = 0;
	public string reason;
	public ArrayList reward_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.activity_id = ba.ReadInt();
		this.gold_info = ba.ReadInt();
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.reward_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_activity_reward_info p = new p_activity_reward_info();
			p.fill2c(ba);
			this.reward_list.Add(p);
		}
	}
}