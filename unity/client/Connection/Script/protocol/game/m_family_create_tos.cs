using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_create_tos:OutgoingBase{
	//ID
	public int protocolID = 3101;

	//fields
	public string family_name;
	public string public_notice;
	public string private_notice;
	public bool is_invite = false;
	public int badge = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3101);
		ba.WriteString(this.family_name);
		ba.WriteString(this.public_notice);
		ba.WriteString(this.private_notice);
		ba.WriteBool(this.is_invite);
		ba.WriteInt(this.badge);
	}
}