using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_pet_employ:GameNetInfo{
	//fields
	public int pet_item_id = 0;
	public int times = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pet_item_id = ba.ReadInt();
		this.times = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.pet_item_id);
		ba.WriteInt(this.times);
	}
}