using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_pkmodemodify_tos:OutgoingBase{
	//ID
	public int protocolID = 515;

	//fields
	public int pk_mode = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(515);
		ba.WriteInt(this.pk_mode);
	}
}