using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_stat_browser_tos:OutgoingBase{
	//ID
	public int protocolID = 6403;

	//fields
	public string flash_ver;
	public string browser_name;
	public string browser_ver;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(6403);
		ba.WriteString(this.flash_ver);
		ba.WriteString(this.browser_name);
		ba.WriteString(this.browser_ver);
	}
}