using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_use_requirement:GameNetInfo{
	//fields
	public int sex = 0;
	public int min_level = 0;
	public int max_level = 0;
	public int min_jingjie = 0;
	public int max_jingjie = 0;
	public int min_vip = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.sex = ba.ReadInt();
		this.min_level = ba.ReadInt();
		this.max_level = ba.ReadInt();
		this.min_jingjie = ba.ReadInt();
		this.max_jingjie = ba.ReadInt();
		this.min_vip = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.sex);
		ba.WriteInt(this.min_level);
		ba.WriteInt(this.max_level);
		ba.WriteInt(this.min_jingjie);
		ba.WriteInt(this.max_jingjie);
		ba.WriteInt(this.min_vip);
	}
}