using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_boss_attack_toc:IncommingBase{
	//ID
	public int protocolID = 3185;

	//fields
	public string boss_name;
	public int max_hp = 0;
	public int cur_hp = 0;
	public string attack_name;
	public int damage = 0;
	public bool is_kill = false;
	public int boss_id = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.boss_name = ba.ReadString();
		this.max_hp = ba.ReadInt();
		this.cur_hp = ba.ReadInt();
		this.attack_name = ba.ReadString();
		this.damage = ba.ReadInt();
		this.is_kill = ba.ReadBoolean();
		this.boss_id = ba.ReadInt();
	}
}