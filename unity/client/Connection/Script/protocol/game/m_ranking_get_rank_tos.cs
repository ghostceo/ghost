using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_ranking_get_rank_tos:OutgoingBase{
	//ID
	public int protocolID = 4102;

	//fields
	public int rank_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(4102);
		ba.WriteInt(this.rank_id);
	}
}