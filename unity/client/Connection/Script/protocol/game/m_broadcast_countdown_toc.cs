using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_broadcast_countdown_toc:IncommingBase{
	//ID
	public int protocolID = 2902;

	//fields
	public int type = 0;
	public int sub_type = 0;
	public int id = 0;
	public string content;
	public int countdown_time = 0;
	public int current_countdown_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.sub_type = ba.ReadInt();
		this.id = ba.ReadInt();
		this.content = ba.ReadString();
		this.countdown_time = ba.ReadInt();
		this.current_countdown_time = ba.ReadInt();
	}
}