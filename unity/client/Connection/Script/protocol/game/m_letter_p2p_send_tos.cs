using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_letter_p2p_send_tos:OutgoingBase{
	//ID
	public int protocolID = 2101;

	//fields
	public string receiver;
	public string text;
	public ArrayList goods_list;
	public string title;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2101);
		ba.WriteString(this.receiver);
		ba.WriteString(this.text);
		for (int i = 0; i < goods_list.Count; i++){
		((p_letter_goods)this.goods_list[i]).fill2s(ba);		}
		ba.WriteString(this.title);
	}
}