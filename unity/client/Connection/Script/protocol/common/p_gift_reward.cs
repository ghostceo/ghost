using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_gift_reward:GameNetInfo{
	//fields
	public int id = 0;
	public int min_level = 0;
	public int max_level = 0;
	public int min_jingjie = 0;
	public int max_jingjie = 0;
	public int need_vip_level = 0;
	public int num = 0;
	public int type = 0;
	public int type_id = 0;
	public bool bind = false;
	public int real_gold = 0;
	public int gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.min_level = ba.ReadInt();
		this.max_level = ba.ReadInt();
		this.min_jingjie = ba.ReadInt();
		this.max_jingjie = ba.ReadInt();
		this.need_vip_level = ba.ReadInt();
		this.num = ba.ReadInt();
		this.type = ba.ReadInt();
		this.type_id = ba.ReadInt();
		this.bind = ba.ReadBoolean();
		this.real_gold = ba.ReadInt();
		this.gold = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.min_level);
		ba.WriteInt(this.max_level);
		ba.WriteInt(this.min_jingjie);
		ba.WriteInt(this.max_jingjie);
		ba.WriteInt(this.need_vip_level);
		ba.WriteInt(this.num);
		ba.WriteInt(this.type);
		ba.WriteInt(this.type_id);
		ba.WriteBool(this.bind);
		ba.WriteInt(this.real_gold);
		ba.WriteInt(this.gold);
	}
}