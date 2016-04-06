using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_map_update_actor_mapinfo_tos:OutgoingBase{
	//ID
	public int protocolID = 306;

	//fields
	public int actor_id = 0;
	public int actor_type = 0;
	public int map_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(306);
		ba.WriteInt(this.actor_id);
		ba.WriteInt(this.actor_type);
		ba.WriteInt(this.map_id);
	}
}