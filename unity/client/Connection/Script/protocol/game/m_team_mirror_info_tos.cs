using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_mirror_info_tos:OutgoingBase{
	//ID
	public int protocolID = 17900;

	//fields
	public int fb_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(17900);
		ba.WriteInt(this.fb_id);
	}
}