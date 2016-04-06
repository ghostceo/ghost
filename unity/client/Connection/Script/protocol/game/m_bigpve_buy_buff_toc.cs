using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_bigpve_buy_buff_toc:IncommingBase{
	//ID
	public int protocolID = 10606;

	//fields
	public int type = 0;
	public int err_code = 0;
	public string reason;
	public int next_buff_id = 0;
	public int cost_money = 0;
	public int voucher_num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.next_buff_id = ba.ReadInt();
		this.cost_money = ba.ReadInt();
		this.voucher_num = ba.ReadInt();
	}
}