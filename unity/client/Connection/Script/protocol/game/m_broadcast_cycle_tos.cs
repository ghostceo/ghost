using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_broadcast_cycle_tos:OutgoingBase{
	//ID
	public int protocolID = 2903;

	//fields
	public int type = 0;
	public int sub_type = 0;
	public string content;
	public int send_type = 0;
	public int start_time = 0;
	public int end_time = 0;
	public int interval = 0;
	public ArrayList role_list;
	public bool is_world = false;
	public int country_id = 0;
	public int famliy_id = 0;
	public int team_id = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2903);
		ba.WriteInt(this.type);
		ba.WriteInt(this.sub_type);
		ba.WriteString(this.content);
		ba.WriteInt(this.send_type);
		ba.WriteInt(this.start_time);
		ba.WriteInt(this.end_time);
		ba.WriteInt(this.interval);
		ba.WriteIntArray(this.role_list);
		ba.WriteBool(this.is_world);
		ba.WriteInt(this.country_id);
		ba.WriteInt(this.famliy_id);
		ba.WriteInt(this.team_id);
	}
}