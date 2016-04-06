using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_secret_fb:GameNetInfo{
	//fields
	public int id = 0;
	public int score = 0;
	public int score_lv = 0;
	public int time = 0;
	public int layer = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.score = ba.ReadInt();
		this.score_lv = ba.ReadInt();
		this.time = ba.ReadInt();
		this.layer = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.score);
		ba.WriteInt(this.score_lv);
		ba.WriteInt(this.time);
		ba.WriteInt(this.layer);
	}
}