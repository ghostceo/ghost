using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_gm_complaint_tos:OutgoingBase{
	//ID
	public int protocolID = 4001;

	//fields
	public int type = 0;
	public string title;
	public string content;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(4001);
		ba.WriteInt(this.type);
		ba.WriteString(this.title);
		ba.WriteString(this.content);
	}
}