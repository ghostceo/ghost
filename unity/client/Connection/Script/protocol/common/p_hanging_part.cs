using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_hanging_part:GameNetInfo{
	//fields
	public int index = 0;
	public ArrayList steps;
	public ArrayList steps_2nd;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.index = ba.ReadInt();
		this.steps = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_hanging_step p = new p_hanging_step();
			p.fill2c(ba);
			this.steps.Add(p);
		}
		this.steps_2nd = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_hanging_step p = new p_hanging_step();
			p.fill2c(ba);
			this.steps_2nd.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.index);
		for (int i = 0; i < steps.Count; i++){
		((p_hanging_step)this.steps[i]).fill2s(ba);		}
		for (int i = 0; i < steps_2nd.Count; i++){
		((p_hanging_step)this.steps_2nd[i]).fill2s(ba);		}
	}
}