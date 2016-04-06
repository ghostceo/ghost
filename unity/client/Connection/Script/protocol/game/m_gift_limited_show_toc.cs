using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_gift_limited_show_toc:IncommingBase{
	//ID
	public int protocolID = 15400;

	//fields
	public int err_code = 0;
	public string reason;
	public ArrayList had_get_lists;
	public ArrayList gifts;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.had_get_lists = new ArrayList();
		ba.ReadIntArray(this.had_get_lists);
		this.gifts = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_gift_reward p = new p_gift_reward();
			p.fill2c(ba);
			this.gifts.Add(p);
		}
	}
}