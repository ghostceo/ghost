using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_letter_delete:GameNetInfo{
	//fields
	public int letter_id = 0;
	public bool is_self_send = false;
	public int table = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.letter_id = ba.ReadInt();
		this.is_self_send = ba.ReadBoolean();
		this.table = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.letter_id);
		ba.WriteBool(this.is_self_send);
		ba.WriteInt(this.table);
	}
}