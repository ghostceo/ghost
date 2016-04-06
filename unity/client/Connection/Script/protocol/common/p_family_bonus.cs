using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_bonus:GameNetInfo{
	//fields
	public double bonus_id = 0;
	public int role_id = 0;
	public int role_name = 0;
	public int type_id = 0;
	public int pay_gold = 0;
	public int remain_num = 0;
	public int start_time = 0;
	public int end_time = 0;
	public int state = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.bonus_id = ba.ReadDouble();
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadInt();
		this.type_id = ba.ReadInt();
		this.pay_gold = ba.ReadInt();
		this.remain_num = ba.ReadInt();
		this.start_time = ba.ReadInt();
		this.end_time = ba.ReadInt();
		this.state = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteDouble(this.bonus_id);
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.role_name);
		ba.WriteInt(this.type_id);
		ba.WriteInt(this.pay_gold);
		ba.WriteInt(this.remain_num);
		ba.WriteInt(this.start_time);
		ba.WriteInt(this.end_time);
		ba.WriteInt(this.state);
	}
}