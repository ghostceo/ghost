using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_letter_accept_goods_toc:IncommingBase{
	//ID
	public int protocolID = 2110;

	//fields
	public bool succ = false;
	public int letter_id = 0;
	public ArrayList accept_list;
	public ArrayList goods_take;
	public string reason;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.letter_id = ba.ReadInt();
		this.accept_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_reward_prop p = new p_reward_prop();
			p.fill2c(ba);
			this.accept_list.Add(p);
		}
		this.goods_take = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.goods_take.Add(p);
		}
		this.reason = ba.ReadString();
	}
}