using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_agree_f_toc:IncommingBase{
	//ID
	public int protocolID = 3106;

	//fields
	public bool succ = true;
	public string reason;
	public bool return_self = true;
	public p_family_info family_info;
	public int admit_role_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.return_self = ba.ReadBoolean();
		if(ba.ReadByte() == 1){
			this.family_info = new p_family_info();
			this.family_info.fill2c(ba);
		}
		this.admit_role_id = ba.ReadInt();
	}
}