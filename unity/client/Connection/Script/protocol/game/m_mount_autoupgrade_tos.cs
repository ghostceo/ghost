using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_mount_autoupgrade_tos:OutgoingBase{
	//ID
	public int protocolID = 16705;

	//fields
	public int mountid = 0;
	public int target_level = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(16705);
		ba.WriteInt(this.mountid);
		ba.WriteInt(this.target_level);
	}
}