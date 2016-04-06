using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_open_activity_rank_toc:IncommingBase{
	//ID
	public int protocolID = 5635;

	//fields
	public int err_code = 0;
	public string reason;
	public int type = 0;
	public ArrayList rank_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.type = ba.ReadInt();
		this.rank_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_open_activity_rank p = new p_open_activity_rank();
			p.fill2c(ba);
			this.rank_list.Add(p);
		}
	}
}