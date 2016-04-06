using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_mount_info:GameNetInfo{
	//fields
	public int id = 0;
	public int typeid = 0;
	public int state = 0;
	public int level = 0;
	public int huanhuaid = 0;
	public int typeid1 = 0;
	public int time = 0;
	public int luck_point = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.typeid = ba.ReadInt();
		this.state = ba.ReadInt();
		this.level = ba.ReadInt();
		this.huanhuaid = ba.ReadInt();
		this.typeid1 = ba.ReadInt();
		this.time = ba.ReadInt();
		this.luck_point = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.typeid);
		ba.WriteInt(this.state);
		ba.WriteInt(this.level);
		ba.WriteInt(this.huanhuaid);
		ba.WriteInt(this.typeid1);
		ba.WriteInt(this.time);
		ba.WriteInt(this.luck_point);
	}
}