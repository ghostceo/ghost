using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_war_score_toc:IncommingBase{
	//ID
	public int protocolID = 18001;

	//fields
	public int my_score = 0;
	public ArrayList family_rank;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.my_score = ba.ReadInt();
		this.family_rank = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_war_score p = new p_family_war_score();
			p.fill2c(ba);
			this.family_rank.Add(p);
		}
	}
}