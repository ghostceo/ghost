using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_conlogin_reward:GameNetInfo{
	//fields
	public int id = 0;
	public int type = 0;
	public int type_id = 0;
	public int min_level = 0;
	public int max_level = 0;
	public int min_jingjie = 0;
	public int max_jingjie = 0;
	public bool need_payed = false;
	public int num = 0;
	public int silver = 0;
	public int gold = 0;
	public bool bind = false;
	public int need_vip_level = 0;
	public ArrayList rewards;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.type = ba.ReadInt();
		this.type_id = ba.ReadInt();
		this.min_level = ba.ReadInt();
		this.max_level = ba.ReadInt();
		this.min_jingjie = ba.ReadInt();
		this.max_jingjie = ba.ReadInt();
		this.need_payed = ba.ReadBoolean();
		this.num = ba.ReadInt();
		this.silver = ba.ReadInt();
		this.gold = ba.ReadInt();
		this.bind = ba.ReadBoolean();
		this.need_vip_level = ba.ReadInt();
		this.rewards = new ArrayList();
		ba.ReadIntArray(this.rewards);
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.type);
		ba.WriteInt(this.type_id);
		ba.WriteInt(this.min_level);
		ba.WriteInt(this.max_level);
		ba.WriteInt(this.min_jingjie);
		ba.WriteInt(this.max_jingjie);
		ba.WriteBool(this.need_payed);
		ba.WriteInt(this.num);
		ba.WriteInt(this.silver);
		ba.WriteInt(this.gold);
		ba.WriteBool(this.bind);
		ba.WriteInt(this.need_vip_level);
		ba.WriteIntArray(this.rewards);
	}
}