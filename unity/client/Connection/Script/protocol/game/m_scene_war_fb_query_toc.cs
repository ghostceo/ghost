using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_scene_war_fb_query_toc:IncommingBase{
	//ID
	public int protocolID = 7603;

	//fields
	public bool succ = true;
	public int op_type = 0;
	public int npc_id = 0;
	public string reason;
	public int reason_code = 0;
	public bool can_employ = false;
	public ArrayList fb_links;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.op_type = ba.ReadInt();
		this.npc_id = ba.ReadInt();
		this.reason = ba.ReadString();
		this.reason_code = ba.ReadInt();
		this.can_employ = ba.ReadBoolean();
		this.fb_links = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_scene_war_fb_link p = new p_scene_war_fb_link();
			p.fill2c(ba);
			this.fb_links.Add(p);
		}
	}
}