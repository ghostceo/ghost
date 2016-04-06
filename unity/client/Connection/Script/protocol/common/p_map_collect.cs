using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_map_collect:GameNetInfo{
	//fields
	public int id = 0;
	public int typeid = 0;
	public string name;
	public int degree = 0;
	public int times = 0;
	public int tool_typeid = 0;
	public int point_id = 0;
	public p_pos pos;
	public ArrayList roles;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.typeid = ba.ReadInt();
		this.name = ba.ReadString();
		this.degree = ba.ReadInt();
		this.times = ba.ReadInt();
		this.tool_typeid = ba.ReadInt();
		this.point_id = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
		this.roles = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_collect_role p = new p_collect_role();
			p.fill2c(ba);
			this.roles.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.typeid);
		ba.WriteString(this.name);
		ba.WriteInt(this.degree);
		ba.WriteInt(this.times);
		ba.WriteInt(this.tool_typeid);
		ba.WriteInt(this.point_id);
		this.pos.fill2s(ba);
		for (int i = 0; i < roles.Count; i++){
		((p_collect_role)this.roles[i]).fill2s(ba);		}
	}
}