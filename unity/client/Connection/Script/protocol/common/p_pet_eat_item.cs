using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_pet_eat_item:GameNetInfo{
	//fields
	public int eat_id = 0;
	public int eat_num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.eat_id = ba.ReadInt();
		this.eat_num = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.eat_id);
		ba.WriteInt(this.eat_num);
	}
}