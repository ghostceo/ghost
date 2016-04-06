using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_member_recommend_toc:IncommingBase{
	//ID
	public int protocolID = 1713;

	//fields
	public bool succ = true;
	public ArrayList member_info;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.member_info = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_recommend_member_info p = new p_recommend_member_info();
			p.fill2c(ba);
			this.member_info.Add(p);
		}
		this.reason = ba.ReadString();
	}
}