using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_load_tos:OutgoingBase{
	//ID
	public int protocolID = 802;

	//fields
	public int pet_id = 0;
	public int equip_slot_num = 0;
	public int equipid = 0;
	public int from = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(802);
		ba.WriteInt(this.pet_id);
		ba.WriteInt(this.equip_slot_num);
		ba.WriteInt(this.equipid);
		ba.WriteInt(this.from);
	}
}