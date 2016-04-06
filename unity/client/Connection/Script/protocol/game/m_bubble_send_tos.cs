using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_bubble_send_tos:OutgoingBase{
	//ID
	public int protocolID = 3301;

	//fields
	public int action_type = 0;
	public string msg;
	public int to_role_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3301);
		ba.WriteInt(this.action_type);
		ba.WriteString(this.msg);
		ba.WriteInt(this.to_role_id);
	}
}