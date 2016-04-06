using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_pet_rank:GameNetInfo{
	//fields
	public int pet_id = 0;
	public string pet_type_name;
	public int role_id = 0;
	public int ranking = 0;
	public string role_name;
	public int level = 0;
	public int color = 0;
	public int understanding = 0;
	public int score = 0;
	public int faction_id = 0;
	public string title;
	public string pet_name;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pet_id = ba.ReadInt();
		this.pet_type_name = ba.ReadString();
		this.role_id = ba.ReadInt();
		this.ranking = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.level = ba.ReadInt();
		this.color = ba.ReadInt();
		this.understanding = ba.ReadInt();
		this.score = ba.ReadInt();
		this.faction_id = ba.ReadInt();
		this.title = ba.ReadString();
		this.pet_name = ba.ReadString();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.pet_id);
		ba.WriteString(this.pet_type_name);
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.ranking);
		ba.WriteString(this.role_name);
		ba.WriteInt(this.level);
		ba.WriteInt(this.color);
		ba.WriteInt(this.understanding);
		ba.WriteInt(this.score);
		ba.WriteInt(this.faction_id);
		ba.WriteString(this.title);
		ba.WriteString(this.pet_name);
	}
}