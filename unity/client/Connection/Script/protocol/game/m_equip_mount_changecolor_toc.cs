using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_mount_changecolor_toc:IncommingBase{
	//ID
	public int protocolID = 809;

	//fields
	public bool succ = true;
	public bool is_auto_buy = false;
	public string reason;
	public int color = 0;
	public int level = 0;
	public p_goods mount;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.is_auto_buy = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.color = ba.ReadInt();
		this.level = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.mount = new p_goods();
			this.mount.fill2c(ba);
		}
	}
}