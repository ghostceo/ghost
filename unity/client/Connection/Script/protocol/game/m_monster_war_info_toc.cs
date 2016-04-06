using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_monster_war_info_toc:IncommingBase{
	//ID
	public int protocolID = 10901;

	//fields
	public int rank = 0;
	public int total_hurts = 0;
	public ArrayList rank_datas;
	public int end_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rank = ba.ReadInt();
		this.total_hurts = ba.ReadInt();
		this.rank_datas = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_monster_war_rank p = new p_monster_war_rank();
			p.fill2c(ba);
			this.rank_datas.Add(p);
		}
		this.end_time = ba.ReadInt();
	}
}