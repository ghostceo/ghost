using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_treasbox_show_toc:IncommingBase{
	//ID
	public int protocolID = 11801;

	//fields
	public int err_code = 0;
	public string reason;
	public int op_type = 0;
	public int has_goods_num = 0;
	public bool is_open = true;
	public int has_gold = 0;
	public ArrayList productions;
	public ArrayList box_list;
	public int remain_cnt = 0;
	public int free_remain_cnt = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.op_type = ba.ReadInt();
		this.has_goods_num = ba.ReadInt();
		this.is_open = ba.ReadBoolean();
		this.has_gold = ba.ReadInt();
		this.productions = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.productions.Add(p);
		}
		this.box_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.box_list.Add(p);
		}
		this.remain_cnt = ba.ReadInt();
		this.free_remain_cnt = ba.ReadInt();
	}
}