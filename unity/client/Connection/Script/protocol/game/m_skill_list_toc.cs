using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_skill_list_toc:IncommingBase{
	//ID
	public int protocolID = 2801;

	//fields
	public int open_num = 0;
	public ArrayList pve_skills;
	public ArrayList pvp_skills;
	public ArrayList open_skills;
	public ArrayList next_skills;
	public int pve_strategy = 0;
	public int pvp_strategy = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.open_num = ba.ReadInt();
		this.pve_skills = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_role_skill p = new p_role_skill();
			p.fill2c(ba);
			this.pve_skills.Add(p);
		}
		this.pvp_skills = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_role_skill p = new p_role_skill();
			p.fill2c(ba);
			this.pvp_skills.Add(p);
		}
		this.open_skills = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_role_skill p = new p_role_skill();
			p.fill2c(ba);
			this.open_skills.Add(p);
		}
		this.next_skills = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_role_skill p = new p_role_skill();
			p.fill2c(ba);
			this.next_skills.Add(p);
		}
		this.pve_strategy = ba.ReadInt();
		this.pvp_strategy = ba.ReadInt();
	}
}