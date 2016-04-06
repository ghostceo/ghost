using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_lotto_opt_tos:OutgoingBase{
	//ID
	public int protocolID = 1901;

	//fields
	public int opt = 0;
	public int play_num = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(1901);
		ba.WriteInt(this.opt);
		ba.WriteInt(this.play_num);
	}
}