using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_stone_opt_tos:OutgoingBase{
	//ID
	public int protocolID = 20201;

	//fields
	public int opt_type = 0;
	public int id = 0;
	public int equip_id = 0;
	public int stone_id = 0;
	public int stone_typeid = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(20201);
		ba.WriteInt(this.opt_type);
		ba.WriteInt(this.id);
		ba.WriteInt(this.equip_id);
		ba.WriteInt(this.stone_id);
		ba.WriteInt(this.stone_typeid);
	}
}