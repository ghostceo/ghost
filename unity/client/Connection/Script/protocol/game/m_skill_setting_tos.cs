using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_skill_setting_tos:OutgoingBase{
	//ID
	public int protocolID = 2802;

	//fields
	public int type = 0;
	public ArrayList skills;
	public int strategy = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2802);
		ba.WriteInt(this.type);
		ba.WriteIntArray(this.skills);
		ba.WriteInt(this.strategy);
	}
}