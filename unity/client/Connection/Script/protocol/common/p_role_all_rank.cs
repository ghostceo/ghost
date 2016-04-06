using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_all_rank:GameNetInfo{
	//fields
	public int ranking = 0;
	public string rank_name;
	public string key_name;
	public int int_key_value = 0;
	public string str_key_value;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.ranking = ba.ReadInt();
		this.rank_name = ba.ReadString();
		this.key_name = ba.ReadString();
		this.int_key_value = ba.ReadInt();
		this.str_key_value = ba.ReadString();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.ranking);
		ba.WriteString(this.rank_name);
		ba.WriteString(this.key_name);
		ba.WriteInt(this.int_key_value);
		ba.WriteString(this.str_key_value);
	}
}