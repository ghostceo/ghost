using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_buff_result:GameNetInfo{
	//fields
	public int dest_type = 0;
	public int dest_id = 0;
	public ArrayList buffs;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.dest_type = ba.ReadInt();
		this.dest_id = ba.ReadInt();
		this.buffs = new ArrayList();
		ba.ReadIntArray(this.buffs);
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.dest_type);
		ba.WriteInt(this.dest_id);
		ba.WriteIntArray(this.buffs);
	}
}