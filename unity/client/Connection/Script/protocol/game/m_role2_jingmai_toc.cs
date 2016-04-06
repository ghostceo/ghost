using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_jingmai_toc:IncommingBase{
	//ID
	public int protocolID = 567;

	//fields
	public int type = 0;
	public int petcard_score = 0;
	public ArrayList level_list;
	public int err_code = 0;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.petcard_score = ba.ReadInt();
		this.level_list = new ArrayList();
		ba.ReadIntArray(this.level_list);
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
	}
}