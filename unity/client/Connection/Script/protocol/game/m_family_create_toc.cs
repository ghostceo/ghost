using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_create_toc:IncommingBase{
	//ID
	public int protocolID = 3101;

	//fields
	public bool succ = true;
	public string reason;
	public p_family_info family_info;
	public int new_silver = 0;
	public int new_silver_bind = 0;
	public int new_gold = 0;
	public int new_gold_bind = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.family_info = new p_family_info();
			this.family_info.fill2c(ba);
		}
		this.new_silver = ba.ReadInt();
		this.new_silver_bind = ba.ReadInt();
		this.new_gold = ba.ReadInt();
		this.new_gold_bind = ba.ReadInt();
	}
}