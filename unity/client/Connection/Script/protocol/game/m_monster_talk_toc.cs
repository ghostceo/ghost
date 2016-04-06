using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_monster_talk_toc:IncommingBase{
	//ID
	public int protocolID = 1808;

	//fields
	public int monster_id = 0;
	public int show_type = 0;
	public string content;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.monster_id = ba.ReadInt();
		this.show_type = ba.ReadInt();
		this.content = ba.ReadString();
	}
}