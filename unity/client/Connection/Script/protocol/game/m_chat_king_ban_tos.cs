using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_king_ban_tos:OutgoingBase{
	//ID
	public int protocolID = 920;

	//fields
	public int roleid = 0;
	public string rolename;
	public int total_times = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(920);
		ba.WriteInt(this.roleid);
		ba.WriteString(this.rolename);
		ba.WriteInt(this.total_times);
	}
}