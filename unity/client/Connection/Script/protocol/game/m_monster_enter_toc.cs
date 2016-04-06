using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_monster_enter_toc:IncommingBase{
	//ID
	public int protocolID = 1801;

	//fields
	public ArrayList monsters;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.monsters = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_monster p = new p_map_monster();
			p.fill2c(ba);
			this.monsters.Add(p);
		}
	}
}