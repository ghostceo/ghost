using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_main_fb_sweep_toc:IncommingBase{
	//ID
	public int protocolID = 8103;

	//fields
	public int err_code = 0;
	public string reason;
	public int barrier_id = 0;
	public int boss_type_id = 0;
	public int exp = 0;
	public int silver = 0;
	public ArrayList item_drop_list;
	public ArrayList get_rewards;
	public ArrayList sell_rewards;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.barrier_id = ba.ReadInt();
		this.boss_type_id = ba.ReadInt();
		this.exp = ba.ReadInt();
		this.silver = ba.ReadInt();
		this.item_drop_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_prop p = new p_reward_prop();
			p.fill2c(ba);
			this.item_drop_list.Add(p);
		}
		this.get_rewards = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_color p = new p_reward_color();
			p.fill2c(ba);
			this.get_rewards.Add(p);
		}
		this.sell_rewards = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_color p = new p_reward_color();
			p.fill2c(ba);
			this.sell_rewards.Add(p);
		}
	}
}