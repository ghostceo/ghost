using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_pet_collect_eat_tos:OutgoingBase{
	//ID
	public int protocolID = 1210;

	//fields
	public int type = 0;
	public int type_id = 0;
	public ArrayList pet_eat_items;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1210);
		ba.WriteInt(this.type);
		ba.WriteInt(this.type_id);
		for (int i = 0; i < pet_eat_items.Count; i++){
		((p_pet_eat_item)this.pet_eat_items[i]).fill2s(ba);		}
	}
}