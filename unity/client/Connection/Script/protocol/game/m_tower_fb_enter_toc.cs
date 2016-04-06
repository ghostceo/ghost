using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_tower_fb_enter_toc:IncommingBase{
	//ID
	public int protocolID = 19301;

	//fields
	public bool succ = true;
	public int err_code = 0;
	public string reason;
	public int fb_time = 0;
	public int current_level = 0;
	public ArrayList level_reward;
	public ArrayList total_reward;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.fb_time = ba.ReadInt();
		this.current_level = ba.ReadInt();
		this.level_reward = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_prop p = new p_reward_prop();
			p.fill2c(ba);
			this.level_reward.Add(p);
		}
		this.total_reward = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_prop p = new p_reward_prop();
			p.fill2c(ba);
			this.total_reward.Add(p);
		}
	}
}