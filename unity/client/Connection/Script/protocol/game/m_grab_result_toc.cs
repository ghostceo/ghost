using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_grab_result_toc:IncommingBase{
	//ID
	public int protocolID = 11005;

	//fields
	public int mirror_id = 0;
	public bool is_win = false;
	public int weiwang = 0;
	public int silver = 0;
	public p_prop wanted_item;
	public p_prop grab_item;
	public bool can_fast_fight = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.mirror_id = ba.ReadInt();
		this.is_win = ba.ReadBoolean();
		this.weiwang = ba.ReadInt();
		this.silver = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.wanted_item = new p_prop();
			this.wanted_item.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.grab_item = new p_prop();
			this.grab_item.fill2c(ba);
		}
		this.can_fast_fight = ba.ReadBoolean();
	}
}