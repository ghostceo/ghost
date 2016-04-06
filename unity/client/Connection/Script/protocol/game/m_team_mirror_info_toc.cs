using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_mirror_info_toc:IncommingBase{
	//ID
	public int protocolID = 17900;

	//fields
	public int fb_id = 0;
	public int left_times = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.fb_id = ba.ReadInt();
		this.left_times = ba.ReadInt();
	}
}