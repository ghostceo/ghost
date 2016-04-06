using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_xfire_rank:GameNetInfo{
	//fields
	public int xfire_item_id = 0;
	public int is_open = 0;
	public int first_role_id = 0;
	public string first_role_name;
	public int first_faction_id = 0;
	public int first_time = 0;
	public int total_number = 0;
	public int total_number_1 = 0;
	public int total_number_2 = 0;
	public int total_number_3 = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.xfire_item_id = ba.ReadInt();
		this.is_open = ba.ReadInt();
		this.first_role_id = ba.ReadInt();
		this.first_role_name = ba.ReadString();
		this.first_faction_id = ba.ReadInt();
		this.first_time = ba.ReadInt();
		this.total_number = ba.ReadInt();
		this.total_number_1 = ba.ReadInt();
		this.total_number_2 = ba.ReadInt();
		this.total_number_3 = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.xfire_item_id);
		ba.WriteInt(this.is_open);
		ba.WriteInt(this.first_role_id);
		ba.WriteString(this.first_role_name);
		ba.WriteInt(this.first_faction_id);
		ba.WriteInt(this.first_time);
		ba.WriteInt(this.total_number);
		ba.WriteInt(this.total_number_1);
		ba.WriteInt(this.total_number_2);
		ba.WriteInt(this.total_number_3);
	}
}