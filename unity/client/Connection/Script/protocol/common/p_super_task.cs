using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_super_task:GameNetInfo{
	//fields
	public int task_id = 0;
	public int task_type = 0;
	public int task_status = 0;
	public int task_progress = 0;
	public int max_value = 0;
	public int vip_limit = 0;
	public int item_id = 0;
	public ArrayList prop_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.task_id = ba.ReadInt();
		this.task_type = ba.ReadInt();
		this.task_status = ba.ReadInt();
		this.task_progress = ba.ReadInt();
		this.max_value = ba.ReadInt();
		this.vip_limit = ba.ReadInt();
		this.item_id = ba.ReadInt();
		this.prop_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_super_prop p = new p_super_prop();
			p.fill2c(ba);
			this.prop_list.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.task_id);
		ba.WriteInt(this.task_type);
		ba.WriteInt(this.task_status);
		ba.WriteInt(this.task_progress);
		ba.WriteInt(this.max_value);
		ba.WriteInt(this.vip_limit);
		ba.WriteInt(this.item_id);
		for (int i = 0; i < prop_list.Count; i++){
		((p_super_prop)this.prop_list[i]).fill2s(ba);		}
	}
}