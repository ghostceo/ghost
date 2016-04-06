using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fashion_autoupgrade_toc:IncommingBase{
	//ID
	public int protocolID = 2504;

	//fields
	public int err_code = 0;
	public string reason;
	public p_mount_info mount;
	public int use_speed_card_num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.mount = new p_mount_info();
			this.mount.fill2c(ba);
		}
		this.use_speed_card_num = ba.ReadInt();
	}
}