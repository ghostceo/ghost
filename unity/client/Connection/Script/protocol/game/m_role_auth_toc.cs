using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role_auth_toc:IncommingBase{
	//ID
	public int protocolID = 401;

	//fields
	public int err_code = 0;
	public string reason;
	public ArrayList role_infos;
	public string name;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.role_infos = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_role_info p = new p_role_info();
			p.fill2c(ba);
			this.role_infos.Add(p);
		}
		this.name = ba.ReadString();
	}
}