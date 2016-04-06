using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_broadcast_admin_tos:OutgoingBase{
	//ID
	public int protocolID = 2904;

	//fields
	public int id = 0;
	public int foreign_id = 0;
	public int type = 0;
	public string content;
	public int send_strategy = 0;
	public string start_date;
	public string end_date;
	public string start_time;
	public string end_time;
	public int interval = 00;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2904);
		ba.WriteInt(this.id);
		ba.WriteInt(this.foreign_id);
		ba.WriteInt(this.type);
		ba.WriteString(this.content);
		ba.WriteInt(this.send_strategy);
		ba.WriteString(this.start_date);
		ba.WriteString(this.end_date);
		ba.WriteString(this.start_time);
		ba.WriteString(this.end_time);
		ba.WriteInt(this.interval);
	}
}