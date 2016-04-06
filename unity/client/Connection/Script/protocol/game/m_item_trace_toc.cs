using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_item_trace_toc:IncommingBase{
	//ID
	public int protocolID = 1105;

	//fields
	public bool succ = true;
	public string reason;
	public int goods_id = 0;
	public int goods_num = 0;
	public string target_name;
	public int target_mapid = 0;
	public int target_tx = 0;
	public int target_ty = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.goods_id = ba.ReadInt();
		this.goods_num = ba.ReadInt();
		this.target_name = ba.ReadString();
		this.target_mapid = ba.ReadInt();
		this.target_tx = ba.ReadInt();
		this.target_ty = ba.ReadInt();
	}
}