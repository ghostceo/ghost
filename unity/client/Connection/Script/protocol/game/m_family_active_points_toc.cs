using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_active_points_toc:IncommingBase{
	//ID
	public int protocolID = 3135;

	//fields
	public int new_points = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.new_points = ba.ReadInt();
	}
}