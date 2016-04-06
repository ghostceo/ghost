using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_panel_toc:IncommingBase{
	//ID
	public int protocolID = 3121;

	//fields
	public ArrayList invites;
	public ArrayList family_list;
	public ArrayList requests;
	public int total_page = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.invites = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_invite_info p = new p_family_invite_info();
			p.fill2c(ba);
			this.invites.Add(p);
		}
		this.family_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_summary p = new p_family_summary();
			p.fill2c(ba);
			this.family_list.Add(p);
		}
		this.requests = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_request_info p = new p_family_request_info();
			p.fill2c(ba);
			this.requests.Add(p);
		}
		this.total_page = ba.ReadInt();
	}
}