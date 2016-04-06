using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_reinforce_toc:IncommingBase{
	//ID
	public int protocolID = 828;

	//fields
	public int pet_id = 0;
	public int err_code = 0;
	public int equip_id = 0;
	public int reinforce_type = 0;
	public int times = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pet_id = ba.ReadInt();
		this.err_code = ba.ReadInt();
		this.equip_id = ba.ReadInt();
		this.reinforce_type = ba.ReadInt();
		this.times = ba.ReadInt();
	}
}