using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_unload_toc:IncommingBase{
	//ID
	public int protocolID = 803;

	//fields
	public int pet_id = 0;
	public bool succ = true;
	public string reason;
	public p_goods equip;
	public int loadposition = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pet_id = ba.ReadInt();
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.equip = new p_goods();
			this.equip.fill2c(ba);
		}
		this.loadposition = ba.ReadInt();
	}
}