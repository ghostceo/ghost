using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_set_interior_manager_toc:IncommingBase{
	//ID
	public int protocolID = 3170;

	//fields
	public bool succ = true;
	public string reason;
	public bool return_self = true;
	public int role_id = 0;
	public string role_name;
	public int oldrole_id = 0;
	public string oldrole_name;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.return_self = ba.ReadBoolean();
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.oldrole_id = ba.ReadInt();
		this.oldrole_name = ba.ReadString();
	}
}