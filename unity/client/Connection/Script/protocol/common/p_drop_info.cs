using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_drop_info:GameNetInfo{
	//fields
	public ArrayList drops;
	public int rate = 0;
	public int max_num = 0;
	public p_drop_mode drop_mode;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.drops = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_single_drop p = new p_single_drop();
			p.fill2c(ba);
			this.drops.Add(p);
		}
		this.rate = ba.ReadInt();
		this.max_num = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.drop_mode = new p_drop_mode();
			this.drop_mode.fill2c(ba);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		for (int i = 0; i < drops.Count; i++){
		((p_single_drop)this.drops[i]).fill2s(ba);		}
		ba.WriteInt(this.rate);
		ba.WriteInt(this.max_num);
		this.drop_mode.fill2s(ba);
	}
}