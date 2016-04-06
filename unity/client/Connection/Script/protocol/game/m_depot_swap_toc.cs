using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_depot_swap_toc:IncommingBase{
	//ID
	public int protocolID = 2704;

	//fields
	public bool succ = true;
	public string reason;
	public p_goods goods1;
	public p_goods goods2;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.goods1 = new p_goods();
			this.goods1.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.goods2 = new p_goods();
			this.goods2.fill2c(ba);
		}
	}
}