using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_collect_point_base_info:GameNetInfo{
	//fields
	public int id = 0;
	public int mapid = 0;
	public int drop_type = 0;
	public p_pos pos;
	public int max_num = 0;
	public p_collect_refresh refresh;
	public int ripening_time = 0;
	public ArrayList grafts;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.mapid = ba.ReadInt();
		this.drop_type = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
		this.max_num = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.refresh = new p_collect_refresh();
			this.refresh.fill2c(ba);
		}
		this.ripening_time = ba.ReadInt();
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
		ba.WriteInt(this.mapid);
		ba.WriteInt(this.drop_type);
		this.pos.fill2s(ba);
		ba.WriteInt(this.max_num);
		this.refresh.fill2s(ba);
		ba.WriteInt(this.ripening_time);
		for (int i = 0; i < grafts.Count; i++){
		((p_collect)this.grafts[i]).fill2s(ba);		}
	}
}