using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_deposit_look:GameNetInfo{
	//fields
	public string role_name;
	public int money = 0;
	public int get_money = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_name = ba.ReadString();
		this.money = ba.ReadInt();
		this.get_money = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteString(this.role_name);
		ba.WriteInt(this.money);
		ba.WriteInt(this.get_money);
	}
}