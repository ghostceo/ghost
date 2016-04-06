using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_tower_fb_info_toc:IncommingBase{
	//ID
	public int protocolID = 19303;

	//fields
	public bool succ = true;
	public int err_code = 0;
	public string reason;
	public int last_level = 0;
	public int best_level = 0;
	public ArrayList reward_list;
	public int challenge_state = 0;
	public int group_count = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.last_level = ba.ReadInt();
		this.best_level = ba.ReadInt();
		this.reward_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_prop p = new p_reward_prop();
			p.fill2c(ba);
			this.reward_list.Add(p);
		}
		this.challenge_state = ba.ReadInt();
		this.group_count = ba.ReadInt();
	}
}