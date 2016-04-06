using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_rnkm_score_deal_toc:IncommingBase{
	//ID
	public int protocolID = 11217;

	//fields
	public int op_type = 0;
	public int deal_id = 0;
	public ArrayList dealed_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.op_type = ba.ReadInt();
		this.deal_id = ba.ReadInt();
		this.dealed_list = new ArrayList();
		ba.ReadIntArray(this.dealed_list);
	}
}