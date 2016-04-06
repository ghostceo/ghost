using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_ranking_get_rank_toc:IncommingBase{
	//ID
	public int protocolID = 4102;

	//fields
	public int rank_id = 0;
	public ArrayList rows;
	public int my_rank = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rank_id = ba.ReadInt();
		this.rows = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_rank_row p = new p_rank_row();
			p.fill2c(ba);
			this.rows.Add(p);
		}
		this.my_rank = ba.ReadInt();
	}
}