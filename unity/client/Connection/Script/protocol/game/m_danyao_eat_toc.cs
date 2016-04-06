using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_danyao_eat_toc:IncommingBase{
	//ID
	public int protocolID = 3702;

	//fields
	public int type = 0;
	public int all_score = 0;
	public int eat_limit = 0;
	public int level_limit = 0;
	public ArrayList change_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.all_score = ba.ReadInt();
		this.eat_limit = ba.ReadInt();
		this.level_limit = ba.ReadInt();
		this.change_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_danyao_hole p = new p_danyao_hole();
			p.fill2c(ba);
			this.change_list.Add(p);
		}
	}
}