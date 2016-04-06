using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_payment_info_toc:IncommingBase{
	//ID
	public int protocolID = 19901;

	//fields
	public bool is_payed = false;
	public bool is_fetched_first = false;
	public ArrayList recommend_pays;
	public int all_pay_gold = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.is_payed = ba.ReadBoolean();
		this.is_fetched_first = ba.ReadBoolean();
		this.recommend_pays = new ArrayList();
		ba.ReadIntArray(this.recommend_pays);
		this.all_pay_gold = ba.ReadInt();
	}
}