using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_hanging_ready_toc:IncommingBase{
	//ID
	public int protocolID = 2317;

	//fields
	public p_battle cur_battle;
	public int round_num = 0;
	public ArrayList left_fighters;
	public ArrayList right_fighters;
	public int recommend_sanyuan;
	public bool is_guide_dialog = false;
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
		this.recommend_sanyuan = ba.ReadInt();
		this.is_guide_dialog = ba.ReadBoolean();
	}
}