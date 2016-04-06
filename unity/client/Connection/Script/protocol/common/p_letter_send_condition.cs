using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_letter_send_condition:GameNetInfo{
	//fields
	public ArrayList receiver;
	public ArrayList time;
	public ArrayList grade;
	public int sex = 0;
	public int factionid = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.receiver = new ArrayList();
		ba.ReadStringArray(this.receiver);
		this.time = new ArrayList();
		ba.ReadIntArray(this.time);
		this.grade = new ArrayList();
		ba.ReadIntArray(this.grade);
		this.sex = ba.ReadInt();
		this.factionid = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteStringArray(this.receiver);
		ba.WriteIntArray(this.time);
		ba.WriteIntArray(this.grade);
		ba.WriteInt(this.sex);
		ba.WriteInt(this.factionid);
	}
}