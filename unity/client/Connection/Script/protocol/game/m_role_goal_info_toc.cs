using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role_goal_info_toc:IncommingBase{
	//ID
	public int protocolID = 15500;

	//fields
	public int err_code = 0;
	public string reason;
	public ArrayList goal_list;
	public bool need_guide = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.goal_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_role_goal p = new p_role_goal();
			p.fill2c(ba);
			this.goal_list.Add(p);
		}
		this.need_guide = ba.ReadBoolean();
	}
}