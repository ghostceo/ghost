using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_time_activity:GameNetInfo{
	//fields
	public int type = 0;
	public int start_time = 0;
	public int end_time = 0;
	public int open_status = 0;
	public ArrayList activity_status;
	public bool is_new_open = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = ba.ReadInt();
		this.start_time = ba.ReadInt();
		this.end_time = ba.ReadInt();
		this.open_status = ba.ReadInt();
		this.activity_status = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_activity_status p = new p_activity_status();
			p.fill2c(ba);
			this.activity_status.Add(p);
		}
		this.is_new_open = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.type);
		ba.WriteInt(this.start_time);
		ba.WriteInt(this.end_time);
		ba.WriteInt(this.open_status);
		for (int i = 0; i < activity_status.Count; i++){
		((p_activity_status)this.activity_status[i]).fill2s(ba);		}
		ba.WriteBool(this.is_new_open);
	}
}