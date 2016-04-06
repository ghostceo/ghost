using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_monster_skill_toc:IncommingBase{
	//ID
	public int protocolID = 1810;

	//fields
	public int monster_id = 0;
	public int delay = 0;
	public int skill_type = 0;
	public int start_pos = 0;
	public int attack_range = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.monster_id = ba.ReadInt();
		this.delay = ba.ReadInt();
		this.skill_type = ba.ReadInt();
		this.start_pos = ba.ReadInt();
		this.attack_range = ba.ReadInt();
	}
}