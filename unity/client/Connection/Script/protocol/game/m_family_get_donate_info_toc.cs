using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_get_donate_info_toc:IncommingBase{
	//ID
	public int protocolID = 3174;

	//fields
	public bool succ = true;
	public string reason;
	public int reason_code = 0;
	public ArrayList donate_gold_list;
	public ArrayList donate_silver_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.reason_code = ba.ReadInt();
		this.donate_gold_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_role_family_donate_info p = new p_role_family_donate_info();
			p.fill2c(ba);
			this.donate_gold_list.Add(p);
		}
		this.donate_silver_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_role_family_donate_info p = new p_role_family_donate_info();
			p.fill2c(ba);
			this.donate_silver_list.Add(p);
		}
	}
}