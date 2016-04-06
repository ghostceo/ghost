using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_mount_upgrade_toc:IncommingBase{
	//ID
	public int protocolID = 16703;

	//fields
	public bool succ = true;
	public bool is_auto_buy = false;
	public string reason;
	public p_mount_info mount;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.is_auto_buy = ba.ReadBoolean();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.mount = new p_mount_info();
			this.mount.fill2c(ba);
		}
	}
}