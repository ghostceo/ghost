using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_uplevel_toc:IncommingBase{
	//ID
	public int protocolID = 3134;

	//fields
	public bool succ = true;
	public string reason;
	public bool return_self = true;
	public int new_level = 0;
	public int money = 0;
	public int active_points = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.return_self = ba.ReadBoolean();
		this.new_level = ba.ReadInt();
		this.money = ba.ReadInt();
		this.active_points = ba.ReadInt();
	}
}