using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_rank_element:GameNetInfo{
	//fields
	public int element_name = 0;
	public int element_index = 0;
	public int element_color = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.element_name = ba.ReadInt();
		this.element_index = ba.ReadInt();
		this.element_color = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.element_name);
		ba.WriteInt(this.element_index);
		ba.WriteInt(this.element_color);
	}
}