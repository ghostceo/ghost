using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_friend_info_toc:IncommingBase{
	//ID
	public int protocolID = 1008;

	//fields
	public bool succ = true;
	public p_role_ext friend_info;
	public string reason;
	public ArrayList equips;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		if(ba.ReadByte() == 1){
			this.friend_info = new p_role_ext();
			this.friend_info.fill2c(ba);
		}
		this.reason = ba.ReadString();
		this.equips = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.equips.Add(p);
		}
	}
}