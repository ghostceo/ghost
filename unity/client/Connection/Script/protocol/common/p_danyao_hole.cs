using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_danyao_hole:GameNetInfo{
	//fields
	public int hole_id = 0;
	public int hole_attr = 0;
	public ArrayList prop_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.hole_id = ba.ReadInt();
		this.hole_attr = ba.ReadInt();
		this.prop_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_prop p = new p_prop();
			p.fill2c(ba);
			this.prop_list.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.hole_id);
		ba.WriteInt(this.hole_attr);
		for (int i = 0; i < prop_list.Count; i++){
		((p_prop)this.prop_list[i]).fill2s(ba);		}
	}
}