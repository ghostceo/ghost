using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_activity_schedule_info_toc:IncommingBase{
	//ID
	public int protocolID = 5617;

	//fields
	public int error_code = 0;
	public string reason;
	public int id = 0;
	public p_activity_rank my_rank;
	public ArrayList near_ranks;
	public int start_time = 0;
	public int end_time = 0;
	public int qualified_score = 0;
	public int status = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.error_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.id = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.my_rank = new p_activity_rank();
			this.my_rank.fill2c(ba);
		}
		this.near_ranks = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_activity_rank p = new p_activity_rank();
			p.fill2c(ba);
			this.near_ranks.Add(p);
		}
		this.start_time = ba.ReadInt();
		this.end_time = ba.ReadInt();
		this.qualified_score = ba.ReadInt();
		this.status = ba.ReadInt();
	}
}