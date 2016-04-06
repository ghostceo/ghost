using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_collect_point:GameNetInfo{
	//fields
	public int id = 0;
	public int typeid = 0;
	public int state = 0;
	public p_pos pos;
	public int start_time = 0;
	public int ripening_time = 0;
	public int end_time = 0;
	public p_collect_refresh refresh;
	public ArrayList id_list;
	public int drop_type = 0;
	public int max_num = 0;
	public ArrayList grafts;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.typeid = ba.ReadInt();
		this.state = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
		this.start_time = ba.ReadInt();
		this.ripening_time = ba.ReadInt();
		this.end_time = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.refresh = new p_collect_refresh();
			this.refresh.fill2c(ba);
		}
		this.id_list = new ArrayList();
		ba.ReadIntArray(this.id_list);
		this.drop_type = ba.ReadInt();
		this.max_num = ba.ReadInt();
		this.grafts = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_collect p = new p_collect();
			p.fill2c(ba);
			this.grafts.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteInt(this.typeid);
		ba.WriteInt(this.state);
		this.pos.fill2s(ba);
		ba.WriteInt(this.start_time);
		ba.WriteInt(this.ripening_time);
		ba.WriteInt(this.end_time);
		this.refresh.fill2s(ba);
		ba.WriteIntArray(this.id_list);
		ba.WriteInt(this.drop_type);
		ba.WriteInt(this.max_num);
		for (int i = 0; i < grafts.Count; i++){
		((p_collect)this.grafts[i]).fill2s(ba);		}
	}
}