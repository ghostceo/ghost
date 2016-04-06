using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_pet_collect:GameNetInfo{
	//fields
	public int type_id = 0;
	public int color = 0;
	public int quality = 0;
	public int exp = 0;
	public int next_quality_exp = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type_id = ba.ReadInt();
		this.color = ba.ReadInt();
		this.quality = ba.ReadInt();
		this.exp = ba.ReadInt();
		this.next_quality_exp = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.type_id);
		ba.WriteInt(this.color);
		ba.WriteInt(this.quality);
		ba.WriteInt(this.exp);
		ba.WriteInt(this.next_quality_exp);
	}
}