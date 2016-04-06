using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_stone_eat:GameNetInfo{
	//fields
	public int eat_stone_id = 0;
	public int eat_stone_num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.eat_stone_id = ba.ReadInt();
		this.eat_stone_num = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.eat_stone_id);
		ba.WriteInt(this.eat_stone_num);
	}
}