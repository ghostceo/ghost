using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_member_join_toc:IncommingBase{
	//ID
	public int protocolID = 3120;

	//fields
	public p_family_member_info member;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.member = new p_family_member_info();
			this.member.fill2c(ba);
		}
	}
}