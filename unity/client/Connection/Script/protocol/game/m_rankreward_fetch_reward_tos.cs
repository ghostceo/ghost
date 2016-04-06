using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_rankreward_fetch_reward_tos:OutgoingBase{
	//ID
	public int protocolID = 9003;

	//fields
	public int rank_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(9003);
		ba.WriteInt(this.rank_id);
	}
}