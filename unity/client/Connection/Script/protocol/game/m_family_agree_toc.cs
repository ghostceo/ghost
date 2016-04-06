using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_agree_toc:IncommingBase{
	//ID
	public int protocolID = 3104;

	//fields
	public bool succ = true;
	public string reason;
	public bool return_self = true;
	public p_family_member_info member_info;
	public p_family_info family_info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.return_self = ba.ReadBoolean();
		if(ba.ReadByte() == 1){
			this.member_info = new p_family_member_info();
			this.member_info.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.family_info = new p_family_info();
			this.family_info.fill2c(ba);
		}
	}
}