using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_qq_token:GameNetInfo{
	//fields
	public string pf;
	public string pfkey;
	public string pay_token;
	public string access_token;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.pf = ba.ReadString();
		this.pfkey = ba.ReadString();
		this.pay_token = ba.ReadString();
		this.access_token = ba.ReadString();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteString(this.pf);
		ba.WriteString(this.pfkey);
		ba.WriteString(this.pay_token);
		ba.WriteString(this.access_token);
	}
}