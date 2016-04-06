using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_get_roles_toc:IncommingBase{
	//ID
	public int protocolID = 916;

	//fields
	public bool succ = false;
	public string reason;
	public string channel_sign;
	public int channel_type = 0;
	public ArrayList roles;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.channel_sign = ba.ReadString();
		this.channel_type = ba.ReadInt();
		this.roles = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_chat_channel_role_info p = new p_chat_channel_role_info();
			p.fill2c(ba);
			this.roles.Add(p);
		}
	}
}