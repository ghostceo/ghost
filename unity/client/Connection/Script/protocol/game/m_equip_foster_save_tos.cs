using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_foster_save_tos:OutgoingBase{
	//ID
	public int protocolID = 835;

	//fields
	public int pet_id = 0;
	public int equip_id = 0;
	public bool is_loaded = false;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(835);
		ba.WriteInt(this.pet_id);
		ba.WriteInt(this.equip_id);
		ba.WriteBool(this.is_loaded);
	}
}