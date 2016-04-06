using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_rnkm_challenge_tos:OutgoingBase{
	//ID
	public int protocolID = 11204;

	//fields
	public int rank = 0;
	public int role_id = 0;
	public int item = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(11204);
		ba.WriteInt(this.rank);
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.item);
	}
}