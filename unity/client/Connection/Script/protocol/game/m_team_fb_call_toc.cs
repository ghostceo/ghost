using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_fb_call_toc:IncommingBase{
	//ID
	public int protocolID = 1723;

	//fields
	public bool return_self = true;
	public int err_code = 0;
	public string reason;
	public int fb_type = 0;
	public int fb_level = 0;
	public string fb_name;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.return_self = ba.ReadBoolean();
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.fb_type = ba.ReadInt();
		this.fb_level = ba.ReadInt();
		this.fb_name = ba.ReadString();
	}
}