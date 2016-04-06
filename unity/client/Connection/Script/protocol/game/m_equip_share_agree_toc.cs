using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_share_agree_toc:IncommingBase{
	//ID
	public int protocolID = 842;

	//fields
	public int sharer_id1 = 0;
	public string sharer_name1;
	public int sharer_id2 = 0;
	public string sharer_name2;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.sharer_id1 = ba.ReadInt();
		this.sharer_name1 = ba.ReadString();
		this.sharer_id2 = ba.ReadInt();
		this.sharer_name2 = ba.ReadString();
	}
}