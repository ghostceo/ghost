using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_pet_id_name:GameNetInfo{
	//fields
	public int pet_id = 0;
	public int name = 0;
	public int category = 0;
	public int star_lv = 0;
	public int quality = 0;
	public int color = 0;
	public int type_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pet_id = ba.ReadInt();
		this.name = ba.ReadInt();
		this.category = ba.ReadInt();
		this.star_lv = ba.ReadInt();
		this.quality = ba.ReadInt();
		this.color = ba.ReadInt();
		this.type_id = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.pet_id);
		ba.WriteInt(this.name);
		ba.WriteInt(this.category);
		ba.WriteInt(this.star_lv);
		ba.WriteInt(this.quality);
		ba.WriteInt(this.color);
		ba.WriteInt(this.type_id);
	}
}