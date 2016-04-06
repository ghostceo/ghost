using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shenqi_eat_tos:OutgoingBase{
	//ID
	public int protocolID = 10401;

	//fields
	public ArrayList eat_list;
	public int pet_id = 0;
	public int up_equip = 0;
	public bool is_loaded = false;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(10401);
		ba.WriteIntArray(this.eat_list);
		ba.WriteInt(this.pet_id);
		ba.WriteInt(this.up_equip);
		ba.WriteBool(this.is_loaded);
	}
}