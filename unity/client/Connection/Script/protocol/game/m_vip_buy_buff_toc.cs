using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_vip_buy_buff_toc:IncommingBase{
	//ID
	public int protocolID = 7412;

	//fields
	public int op_type = 0;
	public int err_code = 0;
	public string reason;
	public int free_buff_times = 0;
	public int buff_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.op_type = ba.ReadInt();
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.free_buff_times = ba.ReadInt();
		this.buff_id = ba.ReadInt();
	}
}