using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_common_fb_mirrors_toc:IncommingBase{
	//ID
	public int protocolID = 17308;

	//fields
	public int fb_type = 0;
	public ArrayList mirrors;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.fb_type = ba.ReadInt();
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