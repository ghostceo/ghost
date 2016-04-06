using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_grab_challenge_tos:OutgoingBase{
	//ID
	public int protocolID = 11002;

	//fields
	public int mirror_id = 0;
	public int item = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(11002);
		ba.WriteInt(this.mirror_id);
		ba.WriteInt(this.item);
	}
}