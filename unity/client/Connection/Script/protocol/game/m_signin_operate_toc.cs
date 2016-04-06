using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_signin_operate_toc:IncommingBase{
	//ID
	public int protocolID = 19601;

	//fields
	public int op_type = 0;
	public int is_signed_today = 0;
	public int signin_days;
	public bool has_reward = false;
	public ArrayList hour_items;
	public bool is_signin_reward_fetched = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.op_type = ba.ReadInt();
		this.is_signed_today = ba.ReadInt();
		this.signin_days = ba.ReadInt();
		this.has_reward = ba.ReadBoolean();
		this.hour_items = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_prop p = new p_reward_prop();
			p.fill2c(ba);
			this.hour_items.Add(p);
		}
		this.is_signin_reward_fetched = ba.ReadBoolean();
	}
}