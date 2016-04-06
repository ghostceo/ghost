using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_shenqi_build:GameNetInfo{
	//fields
	public int equip_id = 0;
	public int shengwang = 0;
	public int build_score = 0;
	public ArrayList attrs;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.equip_id = ba.ReadInt();
		this.shengwang = ba.ReadInt();
		this.build_score = ba.ReadInt();
		this.attrs = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_attr p = new p_attr();
			p.fill2c(ba);
			this.attrs.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.equip_id);
		ba.WriteInt(this.shengwang);
		ba.WriteInt(this.build_score);
		for (int i = 0; i < attrs.Count; i++){
		((p_attr)this.attrs[i]).fill2s(ba);		}
	}
}