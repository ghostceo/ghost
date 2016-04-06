using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_hanging_step:GameNetInfo{
	//fields
	public int src_type = 0;
	public int src_id = 0;
	public ArrayList results;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.src_type = ba.ReadInt();
		this.src_id = ba.ReadInt();
		this.results = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_skill_result p = new p_skill_result();
			p.fill2c(ba);
			this.results.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.src_type);
		ba.WriteInt(this.src_id);
		for (int i = 0; i < results.Count; i++){
		((p_skill_result)this.results[i]).fill2s(ba);		}
	}
}