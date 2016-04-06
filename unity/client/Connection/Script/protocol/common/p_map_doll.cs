using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_map_doll:GameNetInfo{
	//fields
	public int role_id = 0;
	public string role_name;
	public string doll_name;
	public int doll_type = 0;
	public int doll_kind_id = 0;
	public int level = 0;
	public int mode = 0;
	public p_pos pos;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.doll_name = ba.ReadString();
		this.doll_type = ba.ReadInt();
		this.doll_kind_id = ba.ReadInt();
		this.level = ba.ReadInt();
		this.mode = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteString(this.role_name);
		ba.WriteString(this.doll_name);
		ba.WriteInt(this.doll_type);
		ba.WriteInt(this.doll_kind_id);
		ba.WriteInt(this.level);
		ba.WriteInt(this.mode);
		this.pos.fill2s(ba);
	}
}