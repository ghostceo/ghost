using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_get_goods_toc:IncommingBase{
	//ID
	public int protocolID = 918;

	//fields
	public bool succ = true;
	public int goods_id = 0;
	public p_goods goods_info;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.goods_id = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.goods_info = new p_goods();
			this.goods_info.fill2c(ba);
		}
		this.reason = ba.ReadString();
	}
}