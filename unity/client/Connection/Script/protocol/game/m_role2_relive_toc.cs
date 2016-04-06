using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_relive_toc:IncommingBase{
	//ID
	public int protocolID = 507;

	//fields
	public bool succ = true;
	public bool return_self = true;
	public string reason;
	public p_role_fight role_fight;
	public p_role_pos role_pos;
	public p_map_role map_role;
	public bool map_changed = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.return_self = ba.ReadBoolean();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.role_fight = new p_role_fight();
			this.role_fight.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.role_pos = new p_role_pos();
			this.role_pos.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.map_role = new p_map_role();
			this.map_role.fill2c(ba);
		}
		this.map_changed = ba.ReadBoolean();
	}
}