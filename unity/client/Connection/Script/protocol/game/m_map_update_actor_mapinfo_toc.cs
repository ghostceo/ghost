using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_map_update_actor_mapinfo_toc:IncommingBase{
	//ID
	public int protocolID = 306;

	//fields
	public int actor_id = 0;
	public int actor_type = 0;
	public p_map_role role_info;
	public p_map_monster monster_info;
	public p_map_server_npc server_npc;
	public p_map_ybc ybc_info;
	public p_map_pet pet_info;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.actor_id = ba.ReadInt();
		this.actor_type = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.role_info = new p_map_role();
			this.role_info.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.monster_info = new p_map_monster();
			this.monster_info.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.server_npc = new p_map_server_npc();
			this.server_npc.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.ybc_info = new p_map_ybc();
			this.ybc_info.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.pet_info = new p_map_pet();
			this.pet_info.fill2c(ba);
		}
	}
}