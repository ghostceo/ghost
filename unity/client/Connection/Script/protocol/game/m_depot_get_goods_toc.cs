using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_depot_get_goods_toc:IncommingBase{
	//ID
	public int protocolID = 2701;

	//fields
	public bool succ = true;
	public string reason;
	public int depot_num = 0;
	public int overlap_num = 0;
	public ArrayList depots;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.depot_num = ba.ReadInt();
		this.overlap_num = ba.ReadInt();
		this.depots = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_depot_bag p = new p_depot_bag();
			p.fill2c(ba);
			this.depots.Add(p);
		}
	}
}