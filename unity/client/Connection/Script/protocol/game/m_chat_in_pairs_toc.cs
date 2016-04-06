using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_in_pairs_toc:IncommingBase{
	//ID
	public int protocolID = 903;

	//fields
	public bool succ = true;
	public int show_type = 1;
	public string reason;
	public string msg;
	public p_chat_role from_role_info;
	public p_chat_role to_role_info;
	public int tstamp = 0;
	public int error_code = 0;
	public int to_role_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.show_type = ba.ReadInt();
		this.reason = ba.ReadString();
		this.msg = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.from_role_info = new p_chat_role();
			this.from_role_info.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.to_role_info = new p_chat_role();
			this.to_role_info.fill2c(ba);
		}
		this.tstamp = ba.ReadInt();
		this.error_code = ba.ReadInt();
		this.to_role_id = ba.ReadInt();
	}
}