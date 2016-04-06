using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_pay_gift_info_toc:IncommingBase{
	//ID
	public int protocolID = 5609;

	//fields
	public int err_code = 0;
	public string reason;
	public int type = 0;
	public ArrayList gift_infos;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.type = ba.ReadInt();
		this.gift_infos = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_activity_pay_gift_info p = new p_activity_pay_gift_info();
			p.fill2c(ba);
			this.gift_infos.Add(p);
		}
	}
}