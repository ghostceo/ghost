using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fight_begin_tos:OutgoingBase{
	//ID
	public int protocolID = 605;

	//fields
	public int skillid = 0;
	public int skill_dir = 0;
	public int target_type = 0;
	public int target_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(605);
		ba.WriteInt(this.skillid);
		ba.WriteInt(this.skill_dir);
		ba.WriteInt(this.target_type);
		ba.WriteInt(this.target_id);
	}
}