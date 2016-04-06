using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_equip_mount_renewal:GameNetInfo{
	//fields
	public int type_id = 0;
	public int renewal_type = 0;
	public int renewal_days = 0;
	public int renewal_fee = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type_id = ba.ReadInt();
		this.renewal_type = ba.ReadInt();
		this.renewal_days = ba.ReadInt();
		this.renewal_fee = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.type_id);
		ba.WriteInt(this.renewal_type);
		ba.WriteInt(this.renewal_days);
		ba.WriteInt(this.renewal_fee);
	}
}