using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_best_tower_fb_info_toc:IncommingBase{
	//ID
	public int protocolID = 19401;

	//fields
	public double role_id = 0;
	public string role_name;
	public int best_level = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadDouble();
		this.role_name = ba.ReadString();
		this.best_level = ba.ReadInt();
	}
}