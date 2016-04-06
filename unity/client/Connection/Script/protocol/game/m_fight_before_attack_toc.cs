using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fight_before_attack_toc:IncommingBase{
	//ID
	public int protocolID = 604;

	//fields
	public int role_id = 0;
	public int target_id = 0;
	public int target_type = 0;
	public int skillid = 0;
	public ArrayList extends;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.target_id = ba.ReadInt();
		this.target_type = ba.ReadInt();
		this.skillid = ba.ReadInt();
		this.extends = new ArrayList();
		ba.ReadIntArray(this.extends);
	}
}