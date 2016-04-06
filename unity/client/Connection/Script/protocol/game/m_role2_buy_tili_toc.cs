using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_buy_tili_toc:IncommingBase{
	//ID
	public int protocolID = 548;

	//fields
	public int err_code = 0;
	public string reason;
	public p_tili_info p_tili;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.p_tili = new p_tili_info();
			this.p_tili.fill2c(ba);
		}
	}
}