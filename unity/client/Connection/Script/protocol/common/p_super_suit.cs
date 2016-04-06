using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_super_suit:GameNetInfo{
	//fields
	public int active_lv = 0;
	public bool is_activate = true;
	public ArrayList attrs;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.active_lv = ba.ReadInt();
		this.is_activate = ba.ReadBoolean();
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
		ba.WriteInt(this.active_lv);
		ba.WriteBool(this.is_activate);
		for (int i = 0; i < attrs.Count; i++){
		((p_attr)this.attrs[i]).fill2s(ba);		}
	}
}