using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_fml_buff:GameNetInfo{
	//fields
	public int fml_buff_id = 0;
	public int level = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.fml_buff_id = ba.ReadInt();
		this.level = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.fml_buff_id);
		ba.WriteInt(this.level);
	}
}