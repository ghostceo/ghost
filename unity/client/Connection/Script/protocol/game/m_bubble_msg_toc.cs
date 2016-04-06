using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_bubble_msg_toc:IncommingBase{
	//ID
	public int protocolID = 3302;

	//fields
	public int actor_type = 0;
	public int actor_id = 0;
	public string actor_name;
	public int actor_sex = 0;
	public int actor_faction = 0;
	public int action_type = 0;
	public string msg;
	public int to_role_id = 0;
	public int actor_head = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.actor_type = ba.ReadInt();
		this.actor_id = ba.ReadInt();
		this.actor_name = ba.ReadString();
		this.actor_sex = ba.ReadInt();
		this.actor_faction = ba.ReadInt();
		this.action_type = ba.ReadInt();
		this.msg = ba.ReadString();
		this.to_role_id = ba.ReadInt();
		this.actor_head = ba.ReadInt();
	}
}