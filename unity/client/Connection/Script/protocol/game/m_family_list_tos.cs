using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_family_list_tos:OutgoingBase{
	//ID
	public int protocolID = 3115;

	//fields
	public int page_id = 0;
	public int num_per_page = 0;
	public int search_type = 0;
	public int request_from = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3115);
		ba.WriteInt(this.page_id);
		ba.WriteInt(this.num_per_page);
		ba.WriteInt(this.search_type);
		ba.WriteInt(this.request_from);
	}
}