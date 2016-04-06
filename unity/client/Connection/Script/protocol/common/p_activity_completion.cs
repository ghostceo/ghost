using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_activity_completion:GameNetInfo{
	//fields
	public int group_id = 0;
	public int point = 0;
	public ArrayList state;
	public ArrayList completions;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.group_id = ba.ReadInt();
		this.point = ba.ReadInt();
		this.state = new ArrayList();
		ba.ReadIntArray(this.state);
		this.completions = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_k_v p = new p_k_v();
			p.fill2c(ba);
			this.completions.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.group_id);
		ba.WriteInt(this.point);
		ba.WriteIntArray(this.state);
		for (int i = 0; i < completions.Count; i++){
		((p_k_v)this.completions[i]).fill2s(ba);		}
	}
}