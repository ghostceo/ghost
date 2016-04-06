using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_grab_open_toc:IncommingBase{
	//ID
	public int protocolID = 11001;

	//fields
	public p_grab_role role;
	public ArrayList mirrors;
	public int end_activity_protect = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.role = new p_grab_role();
			this.role.fill2c(ba);
		}
		this.mirrors = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_rnkm_mirror p = new p_rnkm_mirror();
			p.fill2c(ba);
			this.mirrors.Add(p);
		}
		this.end_activity_protect = ba.ReadInt();
	}
}