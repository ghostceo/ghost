using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_skill:GameNetInfo{
	//fields
	public int id = 0;
	public string name;
	public int target_type = 0;
	public int attack_type = 0;
	public int max_level = 0;
	public ArrayList delay_hits;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.name = ba.ReadString();
		this.target_type = ba.ReadInt();
		this.attack_type = ba.ReadInt();
		this.max_level = ba.ReadInt();
		this.delay_hits = new ArrayList();
		ba.ReadIntArray(this.delay_hits);
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteString(this.name);
		ba.WriteInt(this.target_type);
		ba.WriteInt(this.attack_type);
		ba.WriteInt(this.max_level);
		ba.WriteIntArray(this.delay_hits);
	}
}