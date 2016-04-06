using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role_add_tos:OutgoingBase{
	//ID
	public int protocolID = 402;

	//fields
	public string role_name;
	public int sex = 0;
	public int faction_id = 0;
	public int head = 0;
	public int hair_type = 0;
	public int hair_color = 0;
	public int category = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(402);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.sex);
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.head);
		ba.WriteInt(this.hair_type);
		ba.WriteInt(this.hair_color);
		ba.WriteInt(this.category);
	}
}