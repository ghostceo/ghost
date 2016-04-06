using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role:GameNetInfo{
	//fields
	public p_role_base role_base;
	public p_role_fight role_fight;
	public p_role_pos role_pos;
	public p_role_attr role_attr;
	public p_role_ext role_ext;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.role_base = new p_role_base();
			this.role_base.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.role_fight = new p_role_fight();
			this.role_fight.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.role_pos = new p_role_pos();
			this.role_pos.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.role_attr = new p_role_attr();
			this.role_attr.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.role_ext = new p_role_ext();
			this.role_ext.fill2c(ba);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		this.role_base.fill2s(ba);
		this.role_fight.fill2s(ba);
		this.role_pos.fill2s(ba);
		this.role_attr.fill2s(ba);
		this.role_ext.fill2s(ba);
	}
}