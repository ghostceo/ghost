using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_mountup_toc:IncommingBase{
	//ID
	public int protocolID = 807;

	//fields
	public bool succ = true;
	public string reason;
	public p_goods mount_new;
	public p_goods mount_old;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.mount_new = new p_goods();
			this.mount_new.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.mount_old = new p_goods();
			this.mount_old.fill2c(ba);
		}
	}
}