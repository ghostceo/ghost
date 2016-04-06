using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_skill_result:GameNetInfo{
	//fields
	public int skill_id = 0;
	public int skill_lv = 0;
	public ArrayList attk_result;
	public ArrayList buff_result;
	public int add_mp = 0;
	public ArrayList dead_actors;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.skill_id = ba.ReadInt();
		this.skill_lv = ba.ReadInt();
		this.attk_result = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_attack_result p = new p_attack_result();
			p.fill2c(ba);
			this.attk_result.Add(p);
		}
		this.buff_result = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_buff_result p = new p_buff_result();
			p.fill2c(ba);
			this.buff_result.Add(p);
		}
		this.add_mp = ba.ReadInt();
		this.dead_actors = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_actor p = new p_actor();
			p.fill2c(ba);
			this.dead_actors.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.skill_id);
		ba.WriteInt(this.skill_lv);
		for (int i = 0; i < attk_result.Count; i++){
		((p_attack_result)this.attk_result[i]).fill2s(ba);		}
		for (int i = 0; i < buff_result.Count; i++){
		((p_buff_result)this.buff_result[i]).fill2s(ba);		}
		ba.WriteInt(this.add_mp);
		for (int i = 0; i < dead_actors.Count; i++){
		((p_actor)this.dead_actors[i]).fill2s(ba);		}
	}
}