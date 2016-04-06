using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_team_mirror_report_toc:IncommingBase{
	//ID
	public int protocolID = 17903;

	//fields
	public int state = 0;
	public int fb_id = 0;
	public ArrayList rewards;
	public int time_used = 0;
	public int damage = 0;
	public ArrayList score_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.state = ba.ReadInt();
		this.fb_id = ba.ReadInt();
		this.rewards = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_prop p = new p_prop();
			p.fill2c(ba);
			this.rewards.Add(p);
		}
		this.time_used = ba.ReadInt();
		this.damage = ba.ReadInt();
		this.score_list = new ArrayList();
		ba.ReadIntArray(this.score_list);
	}
}