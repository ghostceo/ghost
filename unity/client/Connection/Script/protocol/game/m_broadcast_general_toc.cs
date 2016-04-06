using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_broadcast_general_toc:IncommingBase{
	//ID
	public int protocolID = 2901;

	//fields
	public ArrayList type;
	public int sub_type = 0;
	public string content;
	public ArrayList ext_info_list;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.type = new ArrayList();
		ba.ReadIntArray(this.type);
		this.sub_type = ba.ReadInt();
		this.content = ba.ReadString();
		this.ext_info_list = new ArrayList();
		ba.ReadStringArray(this.ext_info_list);
	}
}