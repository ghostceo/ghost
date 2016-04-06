using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shop_sale_tos:OutgoingBase{
	//ID
	public int protocolID = 1306;

	//fields
	public ArrayList goods;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1306);
		for (int i = 0; i < goods.Count; i++){
		((p_shop_sale_goods)this.goods[i]).fill2s(ba);		}
	}
}