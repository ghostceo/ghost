using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_query_toc:IncommingBase{
	//ID
	public int protocolID = 1715;

	//fields
	public int op_type = 0;
	public bool succ = true;
	public string reason;
	public int reason_code = 0;
	public ArrayList nearby_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.op_type = ba.ReadInt();
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.reason_code = ba.ReadInt();
		this.nearby_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_team_nearby p = new p_team_nearby();
			p.fill2c(ba);
			this.nearby_list.Add(p);
		}
	}
}