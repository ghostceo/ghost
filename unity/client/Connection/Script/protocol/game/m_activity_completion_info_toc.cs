using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_completion_info_toc:IncommingBase{
	//ID
	public int protocolID = 5629;

	//fields
	public int err_code = 0;
	public string reason;
	public int cur_activity = 0;
	public ArrayList record_list;
	public ArrayList activity_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.cur_activity = ba.ReadInt();
		this.record_list = new ArrayList();
		ba.ReadIntArray(this.record_list);
		this.activity_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_activity_completion_new p = new p_activity_completion_new();
			p.fill2c(ba);
			this.activity_list.Add(p);
		}
	}
}