using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_gengu_autoupgrade_toc:IncommingBase{
	//ID
	public int protocolID = 17503;

	//fields
	public int err_code = 0;
	public string reason;
	public p_gengu_info gengu;
	public int use_gold = 0;
	public int use_item_num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.gengu = new p_gengu_info();
			this.gengu.fill2c(ba);
		}
		this.use_gold = ba.ReadInt();
		this.use_item_num = ba.ReadInt();
	}
}