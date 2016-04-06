using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fmlmatch_info_toc:IncommingBase{
	//ID
	public int protocolID = 20401;

	//fields
	public ArrayList family_ranks;
	public ArrayList role_ranks;
	public p_fmlmatch_family_rank my_family_rank;
	public p_fmlmatch_role_rank my_role_rank;
	public int family_level_limit = 0;
	public int role_ftpower_limit = 0;
	public int start_time = 0;
	public int count_down_secs = 0;
	public int count_down_state = 0;
	public p_fmlmatch_fight my_fight;
	public ArrayList fight_list;
	public int cur_round = 0;
	public int open_time = 0;
	public bool is_open = false;
	public int role_state = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.family_ranks = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_fmlmatch_family_rank p = new p_fmlmatch_family_rank();
			p.fill2c(ba);
			this.family_ranks.Add(p);
		}
		this.role_ranks = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_fmlmatch_role_rank p = new p_fmlmatch_role_rank();
			p.fill2c(ba);
			this.role_ranks.Add(p);
		}
		if(ba.ReadByte() == 1){
			this.my_family_rank = new p_fmlmatch_family_rank();
			this.my_family_rank.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.my_role_rank = new p_fmlmatch_role_rank();
			this.my_role_rank.fill2c(ba);
		}
		this.family_level_limit = ba.ReadInt();
		this.role_ftpower_limit = ba.ReadInt();
		this.start_time = ba.ReadInt();
		this.count_down_secs = ba.ReadInt();
		this.count_down_state = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.my_fight = new p_fmlmatch_fight();
			this.my_fight.fill2c(ba);
		}
		this.fight_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_fmlmatch_fight p = new p_fmlmatch_fight();
			p.fill2c(ba);
			this.fight_list.Add(p);
		}
		this.cur_round = ba.ReadInt();
		this.open_time = ba.ReadInt();
		this.is_open = ba.ReadBoolean();
		this.role_state = ba.ReadInt();
	}
}