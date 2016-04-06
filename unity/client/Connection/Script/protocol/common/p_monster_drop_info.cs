using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_monster_drop_info:GameNetInfo{
	//fields
	public int typeid = 0;
	public ArrayList droplist;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.typeid = ba.ReadInt();
		this.droplist = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_drop_info p = new p_drop_info();
			p.fill2c(ba);
			this.droplist.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.typeid);
		for (int i = 0; i < droplist.Count; i++){
		((p_drop_info)this.droplist[i]).fill2s(ba);		}
	}
}