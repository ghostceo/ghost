using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_rank_row:GameNetInfo{
	//fields
	public int row_id = 0;
	public int role_id = 0;
	public ArrayList elements;
	public ArrayList int_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.row_id = ba.ReadInt();
		this.role_id = ba.ReadInt();
		this.elements = new ArrayList();
		ba.ReadStringArray(this.elements);
		this.int_list = new ArrayList();
		ba.ReadIntArray(this.int_list);
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.row_id);
		ba.WriteInt(this.role_id);
		ba.WriteStringArray(this.elements);
		ba.WriteIntArray(this.int_list);
	}
}