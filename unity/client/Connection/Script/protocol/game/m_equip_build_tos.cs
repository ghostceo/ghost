using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_build_tos:OutgoingBase{
	//ID
	public int protocolID = 832;

	//fields
	public int build_type = 0;
	public int target_equip = 0;
	public int target_type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(832);
		ba.WriteInt(this.build_type);
		ba.WriteInt(this.target_equip);
		ba.WriteInt(this.target_type);
	}
}