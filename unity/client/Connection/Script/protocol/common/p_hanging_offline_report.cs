using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_hanging_offline_report:GameNetInfo{
	//fields
	public int elapsed_time = 0;
	public int hanging_buff_time = 0;
	public int barrier_id = 0;
	public int win_num = 0;
	public int fail_num = 0;
	public int old_level = 0;
	public int new_level = 0;
	public int exp = 0;
	public int silver = 0;
	public ArrayList item_drop_list;
	public ArrayList get_rewards;
	public ArrayList sell_rewards;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.elapsed_time = ba.ReadInt();
		this.hanging_buff_time = ba.ReadInt();
		this.barrier_id = ba.ReadInt();
		this.win_num = ba.ReadInt();
		this.fail_num = ba.ReadInt();
		this.old_level = ba.ReadInt();
		this.new_level = ba.ReadInt();
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
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.elapsed_time);
		ba.WriteInt(this.hanging_buff_time);
		ba.WriteInt(this.barrier_id);
		ba.WriteInt(this.win_num);
		ba.WriteInt(this.fail_num);
		ba.WriteInt(this.old_level);
		ba.WriteInt(this.new_level);
		ba.WriteInt(this.exp);
		ba.WriteInt(this.silver);
		for (int i = 0; i < item_drop_list.Count; i++){
		((p_reward_prop)this.item_drop_list[i]).fill2s(ba);		}
		for (int i = 0; i < get_rewards.Count; i++){
		((p_reward_color)this.get_rewards[i]).fill2s(ba);		}
		for (int i = 0; i < sell_rewards.Count; i++){
		((p_reward_color)this.sell_rewards[i]).fill2s(ba);		}
	}
}