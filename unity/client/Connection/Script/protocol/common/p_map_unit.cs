using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_map_unit:GameNetInfo{
	//fields
	public int unit_id = 0;
	public int unit_type = 0;
	public int typeid = 0;
	public double hp = 0;
	public double max_hp = 0;
	public p_pos pos;
	public int state = 0;
	public int radius = 0;
	public ArrayList datas;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.unit_id = ba.ReadInt();
		this.unit_type = ba.ReadInt();
		this.typeid = ba.ReadInt();
		this.hp = ba.ReadDouble();
		this.max_hp = ba.ReadDouble();
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
		this.state = ba.ReadInt();
		this.radius = ba.ReadInt();
		this.datas = new ArrayList();
		ba.ReadIntArray(this.datas);
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.unit_id);
		ba.WriteInt(this.unit_type);
		ba.WriteInt(this.typeid);
		ba.WriteDouble(this.hp);
		ba.WriteDouble(this.max_hp);
		this.pos.fill2s(ba);
		ba.WriteInt(this.state);
		ba.WriteInt(this.radius);
		ba.WriteIntArray(this.datas);
	}
}