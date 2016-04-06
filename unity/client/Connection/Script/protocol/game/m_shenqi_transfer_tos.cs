using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shenqi_transfer_tos:OutgoingBase{
	//ID
	public int protocolID = 10402;

	//fields
	public int to_pet_id = 0;
	public int to_equip = 0;
	public bool is_loaded1 = false;
	public int from_pet_id = 0;
	public int from_equip = 0;
	public bool is_loaded2 = false;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(10402);
		ba.WriteInt(this.to_pet_id);
		ba.WriteInt(this.to_equip);
		ba.WriteBool(this.is_loaded1);
		ba.WriteInt(this.from_pet_id);
		ba.WriteInt(this.from_equip);
		ba.WriteBool(this.is_loaded2);
	}
}