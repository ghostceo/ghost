using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_congratulation_tos:OutgoingBase{
	//ID
	public int protocolID = 1020;

	//fields
	public int to_friend_id = 0;
	public string congratulation;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1020);
		ba.WriteInt(this.to_friend_id);
		ba.WriteString(this.congratulation);
	}
}