using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fight_begin_toc:IncommingBase{
	//ID
	public int protocolID = 605;

	//fields
	public int src_id = 0;
	public int src_type = 0;
	public int skillid = 0;
	public ArrayList skill_datas;
	public int target_type = 0;
	public int target_id = 0;
	public int err_code = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.src_id = ba.ReadInt();
		this.src_type = ba.ReadInt();
		this.skillid = ba.ReadInt();
		this.skill_datas = new ArrayList();
		ba.ReadIntArray(this.skill_datas);
		this.target_type = ba.ReadInt();
		this.target_id = ba.ReadInt();
		this.err_code = ba.ReadInt();
	}
}