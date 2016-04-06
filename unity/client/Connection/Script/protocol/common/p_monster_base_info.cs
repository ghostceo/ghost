using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_monster_base_info:GameNetInfo{
	//fields
	public int typeid = 0;
	public string monstername;
	public int rarity = 0;
	public int level = 0;
	public int category = 0;
	public p_sec_attr sec_attr;
	public int sanyuan = 0;
	public int level_suppress = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.typeid = ba.ReadInt();
		this.monstername = ba.ReadString();
		this.rarity = ba.ReadInt();
		this.level = ba.ReadInt();
		this.category = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.sec_attr = new p_sec_attr();
			this.sec_attr.fill2c(ba);
		}
		this.sanyuan = ba.ReadInt();
		this.level_suppress = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.typeid);
		ba.WriteString(this.monstername);
		ba.WriteInt(this.rarity);
		ba.WriteInt(this.level);
		ba.WriteInt(this.category);
		this.sec_attr.fill2s(ba);
		ba.WriteInt(this.sanyuan);
		ba.WriteInt(this.level_suppress);
	}
}