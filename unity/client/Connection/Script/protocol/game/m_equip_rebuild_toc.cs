using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_rebuild_toc:IncommingBase{
	//ID
	public int protocolID = 831;

	//fields
	public int type = 0;
	public int score = 0;
	public ArrayList new_gains;
	public int return_item = 0;
	public int return_silver = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.score = ba.ReadInt();
		this.new_gains = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_k_v p = new p_k_v();
			p.fill2c(ba);
			this.new_gains.Add(p);
		}
		this.return_item = ba.ReadInt();
		this.return_silver = ba.ReadInt();
	}
}