using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_deposit_log:GameNetInfo{
	//fields
	public ArrayList bet_roles;
	public int deposit_money = 0;
	public int get_money = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.bet_roles = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_bet_role p = new p_bet_role();
			p.fill2c(ba);
			this.bet_roles.Add(p);
		}
		this.deposit_money = ba.ReadInt();
		this.get_money = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		for (int i = 0; i < bet_roles.Count; i++){
		((p_bet_role)this.bet_roles[i]).fill2s(ba);		}
		ba.WriteInt(this.deposit_money);
		ba.WriteInt(this.get_money);
	}
}