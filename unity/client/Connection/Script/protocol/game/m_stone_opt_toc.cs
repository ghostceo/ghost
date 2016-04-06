using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_stone_opt_toc:IncommingBase{
	//ID
	public int protocolID = 20201;

	//fields
	public int opt_type = 0;
	public int id = 0;
	public p_goods equip;
	public int err_code = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.opt_type = ba.ReadInt();
		this.id = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.equip = new p_goods();
			this.equip.fill2c(ba);
		}
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}