using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_room_info:GameNetInfo{
	//fields
	public int owner = 0;
	public int room_id = 0;
	public ArrayList members;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.owner = ba.ReadInt();
		this.room_id = ba.ReadInt();
		this.members = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_room_member p = new p_room_member();
			p.fill2c(ba);
			this.members.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.owner);
		ba.WriteInt(this.room_id);
		for (int i = 0; i < members.Count; i++){
		((p_room_member)this.members[i]).fill2s(ba);		}
	}
}