using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_map_enter_toc:IncommingBase{
	//ID
	public int protocolID = 301;

	//fields
	public bool succ = true;
	public bool return_self = true;
	public string reason;
	public ArrayList roles;
	public ArrayList monsters;
	public ArrayList dropthings;
	public ArrayList dolls;
	public ArrayList grafts;
	public ArrayList ybcs;
	public p_role_pos pos;
	public ArrayList server_npcs;
	public p_map_role role_map_info;
	public ArrayList pets;
	public ArrayList trap_list;
	public ArrayList units;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.return_self = ba.ReadBoolean();
		this.reason = ba.ReadString();
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
		if(ba.ReadByte() == 1){
			this.pos = new p_role_pos();
			this.pos.fill2c(ba);
		}
		this.server_npcs = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_server_npc p = new p_map_server_npc();
			p.fill2c(ba);
			this.server_npcs.Add(p);
		}
		if(ba.ReadByte() == 1){
			this.role_map_info = new p_map_role();
			this.role_map_info.fill2c(ba);
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
	}
}