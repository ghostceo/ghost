using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_item_use_special_toc:IncommingBase{
	//ID
	public int protocolID = 1107;

	//fields
	public int item_id = 0;
	public bool succ = true;
	public string reason;
	public int reason_code = 0;
	public int use_status = 0;
	public int total_progress = 0;
	public int use_effect = 0;
	public ArrayList effects;
	public ArrayList new_goods_list;
	public string progress_desc;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.item_id = ba.ReadInt();
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		this.reason_code = ba.ReadInt();
		this.use_status = ba.ReadInt();
		this.total_progress = ba.ReadInt();
		this.use_effect = ba.ReadInt();
		this.effects = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_item_effect p = new p_item_effect();
			p.fill2c(ba);
			this.effects.Add(p);
		}
		this.new_goods_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.new_goods_list.Add(p);
		}
		this.progress_desc = ba.ReadString();
	}
}