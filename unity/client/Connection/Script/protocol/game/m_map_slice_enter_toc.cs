using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_map_slice_enter_toc:IncommingBase{
	//ID
	public int protocolID = 309;

	//fields
	public ArrayList roles;
	public ArrayList monsters;
	public ArrayList dropthings;
	public ArrayList dolls;
	public ArrayList grafts;
	public ArrayList ybcs;
	public bool return_self = true;
	public ArrayList server_npcs;
	public ArrayList pets;
	public ArrayList trap_list;
	public ArrayList units;
	public ArrayList del_roles;
	public ArrayList del_monsters;
	public ArrayList del_dropthings;
	public ArrayList del_dolls;
	public ArrayList del_grafts;
	public ArrayList del_ybcs;
	public ArrayList del_server_npcs;
	public ArrayList del_pets;
	public ArrayList del_trap_list;
	public ArrayList del_units;
	public int enter_type = 0;
	public p_pos src_pos;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.roles = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_role p = new p_map_role();
			p.fill2c(ba);
			this.roles.Add(p);
		}
		this.monsters = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_monster p = new p_map_monster();
			p.fill2c(ba);
			this.monsters.Add(p);
		}
		this.dropthings = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_dropthing p = new p_map_dropthing();
			p.fill2c(ba);
			this.dropthings.Add(p);
		}
		this.dolls = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_doll p = new p_map_doll();
			p.fill2c(ba);
			this.dolls.Add(p);
		}
		this.grafts = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_collect p = new p_map_collect();
			p.fill2c(ba);
			this.grafts.Add(p);
		}
		this.ybcs = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_ybc p = new p_map_ybc();
			p.fill2c(ba);
			this.ybcs.Add(p);
		}
		this.return_self = ba.ReadBoolean();
		this.server_npcs = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_server_npc p = new p_map_server_npc();
			p.fill2c(ba);
			this.server_npcs.Add(p);
		}
		this.pets = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_pet p = new p_map_pet();
			p.fill2c(ba);
			this.pets.Add(p);
		}
		this.trap_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_trap p = new p_map_trap();
			p.fill2c(ba);
			this.trap_list.Add(p);
		}
		this.units = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_unit p = new p_map_unit();
			p.fill2c(ba);
			this.units.Add(p);
		}
		this.del_roles = new ArrayList();
		ba.ReadIntArray(this.del_roles);
		this.del_monsters = new ArrayList();
		ba.ReadIntArray(this.del_monsters);
		this.del_dropthings = new ArrayList();
		ba.ReadIntArray(this.del_dropthings);
		this.del_dolls = new ArrayList();
		ba.ReadIntArray(this.del_dolls);
		this.del_grafts = new ArrayList();
		ba.ReadIntArray(this.del_grafts);
		this.del_ybcs = new ArrayList();
		ba.ReadIntArray(this.del_ybcs);
		this.del_server_npcs = new ArrayList();
		ba.ReadIntArray(this.del_server_npcs);
		this.del_pets = new ArrayList();
		ba.ReadIntArray(this.del_pets);
		this.del_trap_list = new ArrayList();
		ba.ReadIntArray(this.del_trap_list);
		this.del_units = new ArrayList();
		ba.ReadIntArray(this.del_units);
		this.enter_type = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.src_pos = new p_pos();
			this.src_pos.fill2c(ba);
		}
	}
}