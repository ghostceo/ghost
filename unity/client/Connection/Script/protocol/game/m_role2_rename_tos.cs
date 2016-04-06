using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_rename_tos:OutgoingBase{
	//ID
	public int protocolID = 544;

	//fields
	public string new_name;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(544);
		ba.WriteString(this.new_name);
	}
}