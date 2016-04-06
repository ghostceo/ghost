using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_equip_share_info_toc:IncommingBase{
	//ID
	public int protocolID = 837;

	//fields
	public p_role_snapshot sharer;
	public int next_can_remove_time = 0;
	public ArrayList requester_list;
	public bool is_first_share = false;
	public p_goods first_share_shenqi;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.sharer = new p_role_snapshot();
			this.sharer.fill2c(ba);
		}
		this.next_can_remove_time = ba.ReadInt();
		this.requester_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_role_snapshot p = new p_role_snapshot();
			p.fill2c(ba);
			this.requester_list.Add(p);
		}
		this.is_first_share = ba.ReadBoolean();
		if(ba.ReadByte() == 1){
			this.first_share_shenqi = new p_goods();
			this.first_share_shenqi.fill2c(ba);
		}
	}
}