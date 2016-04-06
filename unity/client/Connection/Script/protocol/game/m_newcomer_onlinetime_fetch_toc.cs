using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_newcomer_onlinetime_fetch_toc:IncommingBase{
	//ID
	public int protocolID = 5707;

	//fields
	public int err_code = 0;
	public string reason;
	public ArrayList fetch_props;
	public ArrayList next_reward_props;
	public int next_reward_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.fetch_props = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_prop p = new p_reward_prop();
			p.fill2c(ba);
			this.fetch_props.Add(p);
		}
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