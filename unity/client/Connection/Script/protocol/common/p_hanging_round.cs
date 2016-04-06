using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_hanging_round:GameNetInfo{
	//fields
	public p_battle cur_battle;
	public int round_num = 0;
	public ArrayList left_fighters;
	public ArrayList right_fighters;
	public ArrayList parts;
	public int round_result = 0;
	public int real_time = 0;
	public int max_time = 0;
	public ArrayList extra_data;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.cur_battle = new p_battle();
			this.cur_battle.fill2c(ba);
		}
		this.round_num = ba.ReadInt();
		this.left_fighters = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_fighter p = new p_fighter();
			p.fill2c(ba);
			this.left_fighters.Add(p);
		}
		this.right_fighters = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_fighter p = new p_fighter();
			p.fill2c(ba);
			this.right_fighters.Add(p);
		}
		this.parts = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_hanging_part p = new p_hanging_part();
			p.fill2c(ba);
			this.parts.Add(p);
		}
		this.round_result = ba.ReadInt();
		this.real_time = ba.ReadInt();
		this.max_time = ba.ReadInt();
		this.extra_data = new ArrayList();
		ba.ReadIntArray(this.extra_data);
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		this.cur_battle.fill2s(ba);
		ba.WriteInt(this.round_num);
		for (int i = 0; i < left_fighters.Count; i++){
		((p_fighter)this.left_fighters[i]).fill2s(ba);		}
		for (int i = 0; i < right_fighters.Count; i++){
		((p_fighter)this.right_fighters[i]).fill2s(ba);		}
		for (int i = 0; i < parts.Count; i++){
		((p_hanging_part)this.parts[i]).fill2s(ba);		}
		ba.WriteInt(this.round_result);
		ba.WriteInt(this.real_time);
		ba.WriteInt(this.max_time);
		ba.WriteIntArray(this.extra_data);
	}
}