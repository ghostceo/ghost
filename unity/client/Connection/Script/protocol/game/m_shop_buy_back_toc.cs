using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shop_buy_back_toc:IncommingBase{
	//ID
	public int protocolID = 1308;

	//fields
	public int op_type = 0;
	public ArrayList goods;
	public bool succ = true;
	public string reason;
	public int goods_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.op_type = ba.ReadInt();
		this.goods = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.goods.Add(p);
		}
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.goods_id = ba.ReadInt();
	}
}