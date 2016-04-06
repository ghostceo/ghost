using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_mirror_get_friends_toc:IncommingBase{
	//ID
	public int protocolID = 17904;

	//fields
	public int barrier_id = 0;
	public ArrayList mirrors;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.barrier_id = ba.ReadInt();
		this.mirrors = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_team_mirror_info p = new p_team_mirror_info();
			p.fill2c(ba);
			this.mirrors.Add(p);
		}
	}
}