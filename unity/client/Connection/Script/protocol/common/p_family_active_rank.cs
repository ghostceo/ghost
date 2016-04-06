using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_active_rank:GameNetInfo{
	//fields
	public int family_id = 0;
	public string family_name;
	public string owner_role_name;
	public int level = 0;
	public int ranking = 0;
	public int member_count = 0;
	public int active = 0;
	public int faction_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.family_id = ba.ReadInt();
		this.family_name = ba.ReadString();
		this.owner_role_name = ba.ReadString();
		this.level = ba.ReadInt();
		this.ranking = ba.ReadInt();
		this.member_count = ba.ReadInt();
		this.active = ba.ReadInt();
		this.faction_id = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.family_id);
		ba.WriteString(this.family_name);
		ba.WriteString(this.owner_role_name);
		ba.WriteInt(this.level);
		ba.WriteInt(this.ranking);
		ba.WriteInt(this.member_count);
		ba.WriteInt(this.active);
		ba.WriteInt(this.faction_id);
	}
}