using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_war_commit_medicine_toc:IncommingBase{
	//ID
	public int protocolID = 18004;

	//fields
	public bool is_robbed = false;
	public int score = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.is_robbed = ba.ReadBoolean();
		this.score = ba.ReadInt();
	}
}