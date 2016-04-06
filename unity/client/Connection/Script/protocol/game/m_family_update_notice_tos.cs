using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_update_notice_tos:OutgoingBase{
	//ID
	public int protocolID = 3111;

	//fields
	public string pub_content;
	public string pri_content;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3111);
		ba.WriteString(this.pub_content);
		ba.WriteString(this.pri_content);
	}
}