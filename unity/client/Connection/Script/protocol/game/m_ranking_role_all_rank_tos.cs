using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_ranking_role_all_rank_tos:OutgoingBase{
	//ID
	public int protocolID = 4111;

	//fields
	public int role_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(4111);
		ba.WriteInt(this.role_id);
	}
}