using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_round_pvp_info_toc:IncommingBase{
	//ID
	public int protocolID = 10802;

	//fields
	public ArrayList ranks;
	public int my_rank = 0;
	public int acc_win = 0;
	public int con_win = 0;
	public int reward_exp = 0;
	public int reward_silver = 0;
	public ArrayList reward_items;
	public p_reward_prop con_win_gift;
	public int in_times = 0;
	public int con_win_history = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.ranks = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_round_pvp_rank p = new p_round_pvp_rank();
			p.fill2c(ba);
			this.ranks.Add(p);
		}
		this.my_rank = ba.ReadInt();
		this.acc_win = ba.ReadInt();
		this.con_win = ba.ReadInt();
		this.reward_exp = ba.ReadInt();
		this.reward_silver = ba.ReadInt();
		this.reward_items = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_prop p = new p_reward_prop();
			p.fill2c(ba);
			this.reward_items.Add(p);
		}
		if(ba.ReadByte() == 1){
			this.con_win_gift = new p_reward_prop();
			this.con_win_gift.fill2c(ba);
		}
		this.in_times = ba.ReadInt();
		this.con_win_history = ba.ReadInt();
	}
}