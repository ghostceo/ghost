using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_fb_call_tos:OutgoingBase{
	//ID
	public int protocolID = 1723;

	//fields
	public int fb_type = 0;
	public int fb_level = 0;
	public string fb_name;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1723);
		ba.WriteInt(this.fb_type);
		ba.WriteInt(this.fb_level);
		ba.WriteString(this.fb_name);
	}
}