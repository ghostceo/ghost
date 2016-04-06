using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_qq_buy_gold_tos:OutgoingBase{
	//ID
	public int protocolID = 9602;

	//fields
	public int result_code = 0;
	public int pay_channel = 0;
	public int pay_state = 0;
	public int provider_state = 0;
	public int save_num = 0;
	public string result_msg;
	public string extend_info;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(9602);
		ba.WriteInt(this.result_code);
		ba.WriteInt(this.pay_channel);
		ba.WriteInt(this.pay_state);
		ba.WriteInt(this.provider_state);
		ba.WriteInt(this.save_num);
		ba.WriteString(this.result_msg);
		ba.WriteString(this.extend_info);
	}
}