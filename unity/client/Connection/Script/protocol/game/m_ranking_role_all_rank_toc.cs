using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_ranking_role_all_rank_toc:IncommingBase{
	//ID
	public int protocolID = 4111;

	//fields
	public ArrayList role_all_ranks;
	public int role_id = 0;
	public string role_name;
	public bool is_self = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_all_ranks = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_role_all_rank p = new p_role_all_rank();
			p.fill2c(ba);
			this.role_all_ranks.Add(p);
		}
		this.role_id = ba.ReadInt();
		this.role_name = ba.ReadString();
		this.is_self = ba.ReadBoolean();
	}
}