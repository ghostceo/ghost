using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_fmlmatch_fight:GameNetInfo{
	//fields
	public p_fmlmatch_role left_role;
	public p_fmlmatch_role right_role;
	public int result = 0;
	public int state = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.left_role = new p_fmlmatch_role();
			this.left_role.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.right_role = new p_fmlmatch_role();
			this.right_role.fill2c(ba);
		}
		this.result = ba.ReadInt();
		this.state = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		this.left_role.fill2s(ba);
		this.right_role.fill2s(ba);
		ba.WriteInt(this.result);
		ba.WriteInt(this.state);
	}
}