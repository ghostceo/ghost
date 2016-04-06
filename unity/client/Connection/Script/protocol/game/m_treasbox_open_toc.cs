using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_treasbox_open_toc:IncommingBase{
	//ID
	public int protocolID = 11802;

	//fields
	public int err_code = 0;
	public string reason;
	public int op_fee_type = 0;
	public int num_type = 0;
	public ArrayList award_list;
	public ArrayList box_list;
	public p_reward_prop activity_reward;
	public p_treasbox_log self_log;
	public p_treasbox_log big_log;
	public int remain_cnt = 0;
	public int free_remain_cnt = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.op_fee_type = ba.ReadInt();
		this.num_type = ba.ReadInt();
		this.award_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.award_list.Add(p);
		}
		this.box_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.box_list.Add(p);
		}
		if(ba.ReadByte() == 1){
			this.activity_reward = new p_reward_prop();
			this.activity_reward.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.self_log = new p_treasbox_log();
			this.self_log.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.big_log = new p_treasbox_log();
			this.big_log.fill2c(ba);
		}
		this.remain_cnt = ba.ReadInt();
		this.free_remain_cnt = ba.ReadInt();
	}
}