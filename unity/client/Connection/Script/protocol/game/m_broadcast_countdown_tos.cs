using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_broadcast_countdown_tos:OutgoingBase{
	//ID
	public int protocolID = 2902;

	//fields
	public int type = 0;
	public int sub_type = 0;
	public int id = 0;
	public string content;
	public int countdown_time = 0;
	public int current_countdown_time = 0;
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
		ba.WriteInt(2902);
		ba.WriteInt(this.type);
		ba.WriteInt(this.sub_type);
		ba.WriteInt(this.id);
		ba.WriteString(this.content);
		ba.WriteInt(this.countdown_time);
		ba.WriteInt(this.current_countdown_time);
		ba.WriteIntArray(this.role_list);
		ba.WriteBool(this.is_world);
		ba.WriteInt(this.country_id);
		ba.WriteInt(this.famliy_id);
		ba.WriteInt(this.team_id);
	}
}