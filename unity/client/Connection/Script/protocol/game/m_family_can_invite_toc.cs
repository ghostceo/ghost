using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_can_invite_toc:IncommingBase{
	//ID
	public int protocolID = 3131;

	//fields
	public ArrayList roles;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.roles = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_recommend_member_info p = new p_recommend_member_info();
			p.fill2c(ba);
			this.roles.Add(p);
		}
	}
}