using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_guide_info_toc:IncommingBase{
	//ID
	public int protocolID = 19001;

	//fields
	public int cur_mission_id = 0;
	public int status = 0;
	public bool is_guide_dialog = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.cur_mission_id = ba.ReadInt();
		this.status = ba.ReadInt();
		this.is_guide_dialog = ba.ReadBoolean();
	}
}