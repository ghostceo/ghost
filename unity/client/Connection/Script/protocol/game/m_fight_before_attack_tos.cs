using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fight_before_attack_tos:OutgoingBase{
	//ID
	public int protocolID = 604;

	//fields
	public int skillid = 0;
	public int target_id = 0;
	public int target_type = 0;
	public ArrayList extends;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(604);
		ba.WriteInt(this.skillid);
		ba.WriteInt(this.target_id);
		ba.WriteInt(this.target_type);
		ba.WriteIntArray(this.extends);
	}
}