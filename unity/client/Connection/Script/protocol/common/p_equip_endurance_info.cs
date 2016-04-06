using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_equip_endurance_info:GameNetInfo{
	//fields
	public int equip_id = 0;
	public int num = 0;
	public int max_num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.equip_id = ba.ReadInt();
		this.num = ba.ReadInt();
		this.max_num = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.equip_id);
		ba.WriteInt(this.num);
		ba.WriteInt(this.max_num);
	}
}