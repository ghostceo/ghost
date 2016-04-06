using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_leftright_protector_toc:IncommingBase{
	//ID
	public int protocolID = 3171;

	//fields
	public int num = 0;
	public string reason;
	public int leftid = 0;
	public string leftrole_name;
	public int rightid = 0;
	public string rightrole_name;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.num = ba.ReadInt();
		this.reason = ba.ReadString();
		this.leftid = ba.ReadInt();
		this.leftrole_name = ba.ReadString();
		this.rightid = ba.ReadInt();
		this.rightrole_name = ba.ReadString();
	}
}