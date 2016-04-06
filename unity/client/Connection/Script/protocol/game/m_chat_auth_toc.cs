using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_auth_toc:IncommingBase{
	//ID
	public int protocolID = 901;

	//fields
	public bool succ = true;
	public string reason;
	public ArrayList channel_list;
	public ArrayList black_list;
	public ArrayList gm_auth;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.channel_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_channel_info p = new p_channel_info();
			p.fill2c(ba);
			this.channel_list.Add(p);
		}
		this.black_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_chat_role p = new p_chat_role();
			p.fill2c(ba);
			this.black_list.Add(p);
		}
		this.gm_auth = new ArrayList();
		ba.ReadStringArray(this.gm_auth);
	}
}