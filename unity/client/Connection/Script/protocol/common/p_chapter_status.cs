using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_chapter_status:GameNetInfo{
	//fields
	public int chapter_id = 0;
	public int pass_num = 0;
	public int barrier_num = 0;
	public int status = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.chapter_id = ba.ReadInt();
		this.pass_num = ba.ReadInt();
		this.barrier_num = ba.ReadInt();
		this.status = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.chapter_id);
		ba.WriteInt(this.pass_num);
		ba.WriteInt(this.barrier_num);
		ba.WriteInt(this.status);
	}
}