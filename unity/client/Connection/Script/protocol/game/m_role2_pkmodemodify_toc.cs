using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_pkmodemodify_toc:IncommingBase{
	//ID
	public int protocolID = 515;

	//fields
	public bool succ = true;
	public string reason;
	public int pk_mode = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.pk_mode = ba.ReadInt();
	}
}