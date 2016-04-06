using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_stone_eat_tos:OutgoingBase{
	//ID
	public int protocolID = 20202;

	//fields
	public int id = 0;
	public int equip_id = 0;
	public int stone_id = 0;
	public int stone_typeid = 0;
	public ArrayList eat_stones;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(20202);
		ba.WriteInt(this.id);
		ba.WriteInt(this.equip_id);
		ba.WriteInt(this.stone_id);
		ba.WriteInt(this.stone_typeid);
		for (int i = 0; i < eat_stones.Count; i++){
		((p_stone_eat)this.eat_stones[i]).fill2s(ba);		}
	}
}