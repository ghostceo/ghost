using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_equip_whole_attr:GameNetInfo{
	//fields
	public int id = 0;
	public int attr_code = 0;
	public int value = 0;
	public int attr_index = 0;
	public int active_number = 0;
	public int active = 0;
	public int number = 0;
	public int attr_type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.attr_code = ba.ReadInt();
		this.value = ba.ReadInt();
		this.attr_index = ba.ReadInt();
		this.active_number = ba.ReadInt();
		this.active = ba.ReadInt();
		this.number = ba.ReadInt();
		this.attr_type = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.attr_code);
		ba.WriteInt(this.value);
		ba.WriteInt(this.attr_index);
		ba.WriteInt(this.active_number);
		ba.WriteInt(this.active);
		ba.WriteInt(this.number);
		ba.WriteInt(this.attr_type);
	}
}