using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_map_update_role_toc:IncommingBase{
	//ID
	public int protocolID = 315;

	//fields
	public int role_id = 0;
	public ArrayList update_list;
	public p_skin skin;
	public ArrayList state_buffs;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.update_list = new ArrayList();
		ba.ReadIntArray(this.update_list);
		if(ba.ReadByte() == 1){
			this.skin = new p_skin();
			this.skin.fill2c(ba);
		}
		this.state_buffs = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_actor_buf p = new p_actor_buf();
			p.fill2c(ba);
			this.state_buffs.Add(p);
		}
	}
}