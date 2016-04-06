using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_nationbattle_rank_toc:IncommingBase{
	//ID
	public int protocolID = 9105;

	//fields
	public ArrayList ranks;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.ranks = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_nationbattle_rank p = new p_nationbattle_rank();
			p.fill2c(ba);
			this.ranks.Add(p);
		}
	}
}