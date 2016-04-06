using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_gongxun_persistent_rank:GameNetInfo{
	//fields
	public int key = 0;
	public int family_id = 0;
	public int total_gongxun = 0;
	public int ranking = 0;
	public int date = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.key = ba.ReadInt();
		this.family_id = ba.ReadInt();
		this.total_gongxun = ba.ReadInt();
		this.ranking = ba.ReadInt();
		this.date = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.key);
		ba.WriteInt(this.family_id);
		ba.WriteInt(this.total_gongxun);
		ba.WriteInt(this.ranking);
		ba.WriteInt(this.date);
	}
}