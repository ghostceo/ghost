using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_broadcast_general_tos:OutgoingBase{
	//ID
	public int protocolID = 2901;

	//fields
	public int type = 0;
	public int sub_type = 0;
	public string content;
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
		ba.WriteInt(2901);
		ba.WriteInt(this.type);
		ba.WriteInt(this.sub_type);
		ba.WriteString(this.content);
		ba.WriteIntArray(this.role_list);
		ba.WriteBool(this.is_world);
		ba.WriteInt(this.country_id);
		ba.WriteInt(this.famliy_id);
		ba.WriteInt(this.team_id);
	}
}