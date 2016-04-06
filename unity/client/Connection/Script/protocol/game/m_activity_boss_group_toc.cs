using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_boss_group_toc:IncommingBase{
	//ID
	public int protocolID = 5610;

	//fields
	public int err_code = 0;
	public string reason;
	public int op_type = 0;
	public int boss_id = 0;
	public ArrayList boss_group_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.op_type = ba.ReadInt();
		this.boss_id = ba.ReadInt();
		this.boss_group_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_boss_group p = new p_boss_group();
			p.fill2c(ba);
			this.boss_group_list.Add(p);
		}
	}
}