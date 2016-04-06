using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_gengu_upgrade_toc:IncommingBase{
	//ID
	public int protocolID = 17502;

	//fields
	public int err_code = 0;
	public bool is_auto_buy = false;
	public string reason;
	public p_gengu_info gengu;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.is_auto_buy = ba.ReadBoolean();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.gengu = new p_gengu_info();
			this.gengu.fill2c(ba);
		}
	}
}