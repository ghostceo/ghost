using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_role_goal:GameNetInfo{
	//fields
	public int goal_id = 0;
	public ArrayList conditions;
	public int status = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.goal_id = ba.ReadInt();
		this.conditions = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goal_condition p = new p_goal_condition();
			p.fill2c(ba);
			this.conditions.Add(p);
		}
		this.status = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.goal_id);
		for (int i = 0; i < conditions.Count; i++){
		((p_goal_condition)this.conditions[i]).fill2s(ba);		}
		ba.WriteInt(this.status);
	}
}