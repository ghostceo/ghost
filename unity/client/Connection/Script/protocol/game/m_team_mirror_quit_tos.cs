using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_mirror_quit_tos:OutgoingBase{
	//ID
	public int protocolID = 17902;

	//fields
	public int fb_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(17902);
		ba.WriteInt(this.fb_id);
	}
}