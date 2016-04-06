using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_bigpve_rank_toc:IncommingBase{
	//ID
	public int protocolID = 10604;

	//fields
	public ArrayList ranks;
	public double my_score = 0;
	public int my_rank = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.ranks = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_bigpve_rank p = new p_bigpve_rank();
			p.fill2c(ba);
			this.ranks.Add(p);
		}
		this.my_score = ba.ReadDouble();
		this.my_rank = ba.ReadInt();
	}
}