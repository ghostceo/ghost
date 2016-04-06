using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_skill_item_consume:GameNetInfo{
	//fields
	public int item_typeid = 0;
	public int number = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.item_typeid = ba.ReadInt();
		this.number = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.item_typeid);
		ba.WriteInt(this.number);
	}
}