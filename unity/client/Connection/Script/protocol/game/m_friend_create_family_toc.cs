using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_create_family_toc:IncommingBase{
	//ID
	public int protocolID = 1015;

	//fields
	public int role_id = 0;
	public int family_id = 0;
	public string family_name;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.family_id = ba.ReadInt();
		this.family_name = ba.ReadString();
	}
}