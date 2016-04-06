using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_buf:GameNetInfo{
	//fields
	public int buff_id = 0;
	public int level = 0;
	public int absolute_or_rate = 0;
	public int value = 0;
	public int prop_id = 0;
	public int probability = 0;
	public int last_value = 0;
	public int last_interval = 0;
	public bool can_remove = false;
	public int kind = 0;
	public int buff_type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.buff_id = ba.ReadInt();
		this.level = ba.ReadInt();
		this.absolute_or_rate = ba.ReadInt();
		this.value = ba.ReadInt();
		this.prop_id = ba.ReadInt();
		this.probability = ba.ReadInt();
		this.last_value = ba.ReadInt();
		this.last_interval = ba.ReadInt();
		this.can_remove = ba.ReadBoolean();
		this.kind = ba.ReadInt();
		this.buff_type = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.buff_id);
		ba.WriteInt(this.level);
		ba.WriteInt(this.absolute_or_rate);
		ba.WriteInt(this.value);
		ba.WriteInt(this.prop_id);
		ba.WriteInt(this.probability);
		ba.WriteInt(this.last_value);
		ba.WriteInt(this.last_interval);
		ba.WriteBool(this.can_remove);
		ba.WriteInt(this.kind);
		ba.WriteInt(this.buff_type);
	}
}