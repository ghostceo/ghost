using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_room_list_toc:IncommingBase{
	//ID
	public int protocolID = 17101;

	//fields
	public int room_type = 0;
	public int page_num = 0;
	public int total_page = 0;
	public ArrayList rooms;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.room_type = ba.ReadInt();
		this.page_num = ba.ReadInt();
		this.total_page = ba.ReadInt();
		this.rooms = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_room_info p = new p_room_info();
			p.fill2c(ba);
			this.rooms.Add(p);
		}
	}
}