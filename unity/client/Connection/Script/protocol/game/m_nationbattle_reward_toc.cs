using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_nationbattle_reward_toc:IncommingBase{
	//ID
	public int protocolID = 9107;

	//fields
	public int error_code = 0;
	public string reason;
	public p_nationbattle_rank battle_rank;
	public int reward_silver = 0;
	public ArrayList reward_prop;
	public int reward_equip_score = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.error_code = ba.ReadInt();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.battle_rank = new p_nationbattle_rank();
			this.battle_rank.fill2c(ba);
		}
		this.reward_silver = ba.ReadInt();
		this.reward_prop = new ArrayList();
		ba.ReadIntArray(this.reward_prop);
		this.reward_equip_score = ba.ReadInt();
	}
}