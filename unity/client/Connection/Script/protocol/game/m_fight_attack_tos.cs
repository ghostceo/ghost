using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fight_attack_tos:OutgoingBase{
	//ID
	public int protocolID = 601;

	//fields
	public p_map_tile tile;
	public int skillid = 0;
	public ArrayList targets;
	public int src_type = 0;
	public int dir = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(601);
		this.tile.fill2s(ba);
		ba.WriteInt(this.skillid);
		ba.WriteIntArray(this.targets);
		ba.WriteInt(this.src_type);
		ba.WriteInt(this.dir);
	}
}