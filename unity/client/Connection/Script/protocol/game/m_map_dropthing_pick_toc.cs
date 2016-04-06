using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_map_dropthing_pick_toc:IncommingBase{
	//ID
	public int protocolID = 305;

	//fields
	public bool succ = true;
	public string reason;
	public int pick_type = 0;
	public int add_money = 0;
	public int money = 0;
	public int dropthingid = 0;
	public p_goods goods;
	public int num = 0;
	public int money_type = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.pick_type = ba.ReadInt();
		this.add_money = ba.ReadInt();
		this.money = ba.ReadInt();
		this.dropthingid = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.goods = new p_goods();
			this.goods.fill2c(ba);
		}
		this.num = ba.ReadInt();
		this.money_type = ba.ReadInt();
	}
}