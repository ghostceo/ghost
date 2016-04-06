using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_enemy_toc:IncommingBase{
	//ID
	public int protocolID = 1012;

	//fields
	public p_friend_info enemy_info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.enemy_info = new p_friend_info();
			this.enemy_info.fill2c(ba);
		}
	}
}