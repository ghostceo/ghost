using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_map_transfer_tos:OutgoingBase{
	//ID
	public int protocolID = 310;

	//fields
	public int mapid = 0;
	public int tx = 0;
	public int ty = 0;
	public int change_type = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(310);
		ba.WriteInt(this.mapid);
		ba.WriteInt(this.tx);
		ba.WriteInt(this.ty);
		ba.WriteInt(this.change_type);
	}
}