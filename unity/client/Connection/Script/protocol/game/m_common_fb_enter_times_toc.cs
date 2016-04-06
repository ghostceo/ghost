using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_common_fb_enter_times_toc:IncommingBase{
	//ID
	public int protocolID = 17306;

	//fields
	public int fb_map_id = 0;
	public int max_times = 0;
	public int left_times = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.fb_map_id = ba.ReadInt();
		this.max_times = ba.ReadInt();
		this.left_times = ba.ReadInt();
	}
}