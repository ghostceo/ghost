using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_attack_result:GameNetInfo{
	//fields
	public int dest_type = 0;
	public int dest_id = 0;
	public int result_type = 0;
	public int result_value = 0;
	public ArrayList effects;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.dest_type = ba.ReadInt();
		this.dest_id = ba.ReadInt();
		this.result_type = ba.ReadInt();
		this.result_value = ba.ReadInt();
		this.effects = new ArrayList();
		ba.ReadIntArray(this.effects);
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.dest_type);
		ba.WriteInt(this.dest_id);
		ba.WriteInt(this.result_type);
		ba.WriteInt(this.result_value);
		ba.WriteIntArray(this.effects);
	}
}