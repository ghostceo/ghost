using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_nationbattle_info_toc:IncommingBase{
	//ID
	public int protocolID = 9104;

	//fields
	public int change_type = 1;
	public ArrayList union_nation;
	public ArrayList union_scores;
	public int fb_start_time = 0;
	public int fb_end_time = 0;
	public int my_score = 0;
	public int my_kill_num = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.change_type = ba.ReadInt();
		this.union_nation = new ArrayList();
		ba.ReadIntArray(this.union_nation);
		this.union_scores = new ArrayList();
		ba.ReadIntArray(this.union_scores);
		this.fb_start_time = ba.ReadInt();
		this.fb_end_time = ba.ReadInt();
		this.my_score = ba.ReadInt();
		this.my_kill_num = ba.ReadInt();
	}
}