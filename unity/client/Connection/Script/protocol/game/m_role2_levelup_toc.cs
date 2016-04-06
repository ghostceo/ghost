using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role2_levelup_toc:IncommingBase{
	//ID
	public int protocolID = 502;

	//fields
	public int err_code = 0;
	public int need_jingjie = 0;
	public int level = 0;
	public int maxhp = 0;
	public int maxmp = 0;
	public double exp = 0;
	public double next_level_exp = 0;
	public double total_add_exp = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.need_jingjie = ba.ReadInt();
		this.level = ba.ReadInt();
		this.maxhp = ba.ReadInt();
		this.maxmp = ba.ReadInt();
		this.exp = ba.ReadDouble();
		this.next_level_exp = ba.ReadDouble();
		this.total_add_exp = ba.ReadDouble();
	}
}