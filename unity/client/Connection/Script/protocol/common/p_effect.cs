using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_effect:GameNetInfo{
	//fields
	public int effect_id = 0;
	public int effect_type = 0;
	public int calc_type = 0;
	public int absolute_or_rate = 0;
	public int value = 0;
	public int probability = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.effect_id = ba.ReadInt();
		this.effect_type = ba.ReadInt();
		this.calc_type = ba.ReadInt();
		this.absolute_or_rate = ba.ReadInt();
		this.value = ba.ReadInt();
		this.probability = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.effect_id);
		ba.WriteInt(this.effect_type);
		ba.WriteInt(this.calc_type);
		ba.WriteInt(this.absolute_or_rate);
		ba.WriteInt(this.value);
		ba.WriteInt(this.probability);
	}
}