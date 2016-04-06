using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_mountdown_toc:IncommingBase{
	//ID
	public int protocolID = 808;

	//fields
	public bool succ = true;
	public string reason;
	public p_goods mount;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.mount = new p_goods();
			this.mount.fill2c(ba);
		}
	}
}