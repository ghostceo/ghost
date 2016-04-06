using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_load_toc:IncommingBase{
	//ID
	public int protocolID = 802;

	//fields
	public int pet_id = 0;
	public bool succ = true;
	public string reason;
	public p_goods equip_load;
	public p_goods equip_bag;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pet_id = ba.ReadInt();
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.equip_load = new p_goods();
			this.equip_load.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.equip_bag = new p_goods();
			this.equip_bag.fill2c(ba);
		}
	}
}