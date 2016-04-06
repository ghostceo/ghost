using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_scene_war_fb_end_toc:IncommingBase{
	//ID
	public int protocolID = 7607;

	//fields
	public int close_seconds = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.close_seconds = ba.ReadInt();
	}
}