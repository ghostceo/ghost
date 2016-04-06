using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_lotto_play_toc:IncommingBase{
	//ID
	public int protocolID = 1904;

	//fields
	public int play_num = 0;
	public int left_times = 0;
	public int acc_times = 0;
	public int total_bonus = 0;
	public p_prop reward_prop;
	public int reward_bonus = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.play_num = ba.ReadInt();
		this.left_times = ba.ReadInt();
		this.acc_times = ba.ReadInt();
		this.total_bonus = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.reward_prop = new p_prop();
			this.reward_prop.fill2c(ba);
		}
		this.reward_bonus = ba.ReadInt();
	}
}