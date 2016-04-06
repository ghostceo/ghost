using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_unload_tos:OutgoingBase{
	//ID
	public int protocolID = 803;

	//fields
	public int pet_id = 0;
	public int equipid = 0;
	public int bagid = 0;
	public int position = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(803);
		ba.WriteInt(this.pet_id);
		ba.WriteInt(this.equipid);
		ba.WriteInt(this.bagid);
		ba.WriteInt(this.position);
	}
}