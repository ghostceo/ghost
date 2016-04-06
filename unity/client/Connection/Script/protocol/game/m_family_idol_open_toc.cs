using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_idol_open_toc:IncommingBase{
	//ID
	public int protocolID = 11701;

	//fields
	public int cur_times = 0;
	public int max_times = 0;
	public ArrayList pray_logs;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.cur_times = ba.ReadInt();
		this.max_times = ba.ReadInt();
		this.pray_logs = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_pray_rec p = new p_family_pray_rec();
			p.fill2c(ba);
			this.pray_logs.Add(p);
		}
	}
}