using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_map_dropthing:GameNetInfo{
	//fields
	public int id = 0;
	public bool ismoney = false;
	public bool bind = false;
	public int num = 0;
	public ArrayList roles;
	public p_pos pos;
	public int money = 0;
	public int goodsid = 0;
	public int colour = 0;
	public int goodstype = 0;
	public int goodstypeid = 0;
	public p_drop_property drop_property;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.ismoney = ba.ReadBoolean();
		this.bind = ba.ReadBoolean();
		this.num = ba.ReadInt();
		this.roles = new ArrayList();
		ba.ReadIntArray(this.roles);
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
		this.money = ba.ReadInt();
		this.goodsid = ba.ReadInt();
		this.colour = ba.ReadInt();
		this.goodstype = ba.ReadInt();
		this.goodstypeid = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.drop_property = new p_drop_property();
			this.drop_property.fill2c(ba);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteBool(this.ismoney);
		ba.WriteBool(this.bind);
		ba.WriteInt(this.num);
		ba.WriteIntArray(this.roles);
		this.pos.fill2s(ba);
		ba.WriteInt(this.money);
		ba.WriteInt(this.goodsid);
		ba.WriteInt(this.colour);
		ba.WriteInt(this.goodstype);
		ba.WriteInt(this.goodstypeid);
		this.drop_property.fill2s(ba);
	}
}