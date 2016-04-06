using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_monster_walk_toc:IncommingBase{
	//ID
	public int protocolID = 1806;

	//fields
	public p_map_monster monsterinfo;
	public p_pos pos;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.monsterinfo = new p_map_monster();
			this.monsterinfo.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
	}
}