using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_fight_attack_toc:IncommingBase{
	//ID
	public int protocolID = 601;

	//fields
	public bool succ = true;
	public bool return_self = true;
	public string reason;
	public int src_id = 0;
	public int skillid = 0;
	public p_pos src_pos;
	public int src_type = 0;
	public ArrayList result;
	public int dir = 0;
	public p_pos dest_pos;
	public int reason_code = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.return_self = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.src_id = ba.ReadInt();
		this.skillid = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.src_pos = new p_pos();
			this.src_pos.fill2c(ba);
		}
		this.src_type = ba.ReadInt();
		this.result = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_attack_result p = new p_attack_result();
			p.fill2c(ba);
			this.result.Add(p);
		}
		this.dir = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.dest_pos = new p_pos();
			this.dest_pos.fill2c(ba);
		}
		this.reason_code = ba.ReadInt();
	}
}