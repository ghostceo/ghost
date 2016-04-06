using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_map_change_map_toc:IncommingBase{
	//ID
	public int protocolID = 307;

	//fields
	public bool succ = true;
	public int mapid = 0;
	public int tx = 0;
	public int ty = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.mapid = ba.ReadInt();
		this.tx = ba.ReadInt();
		this.ty = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}