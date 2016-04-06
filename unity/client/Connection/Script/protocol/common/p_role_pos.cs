using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_pos:GameNetInfo{
	//fields
	public int role_id = 0;
	public int map_id = 0;
	public p_pos pos;
	public string map_process_name;
	public string old_map_process_name;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.role_id = ba.ReadInt();
		this.map_id = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.pos = new p_pos();
			this.pos.fill2c(ba);
		}
		this.map_process_name = ba.ReadString();
		this.old_map_process_name = ba.ReadString();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.role_id);
		ba.WriteInt(this.map_id);
		this.pos.fill2s(ba);
		ba.WriteString(this.map_process_name);
		ba.WriteString(this.old_map_process_name);
	}
}