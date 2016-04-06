using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_del_toc:IncommingBase{
	//ID
	public int protocolID = 811;

	//fields
	public int pet_id = 0;
	public ArrayList slot_nums;
	public p_goods new_equip;
	public p_skin new_skin;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pet_id = ba.ReadInt();
		this.slot_nums = new ArrayList();
		ba.ReadIntArray(this.slot_nums);
		if(ba.ReadByte() == 1){
			this.new_equip = new p_goods();
			this.new_equip.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.new_skin = new p_skin();
			this.new_skin.fill2c(ba);
		}
	}
}