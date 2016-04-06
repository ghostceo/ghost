using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_letter_info:GameNetInfo{
	//fields
	public int id = 0;
	public string sender;
	public string receiver;
	public string title;
	public int send_time = 0;
	public int type = 0;
	public ArrayList goods_list;
	public ArrayList goods_take;
	public int state = 0;
	public string letter_content;
	public int table = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.id = ba.ReadInt();
		this.sender = ba.ReadString();
		this.receiver = ba.ReadString();
		this.title = ba.ReadString();
		this.send_time = ba.ReadInt();
		this.type = ba.ReadInt();
		this.goods_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.goods_list.Add(p);
		}
		this.goods_take = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_goods p = new p_goods();
			p.fill2c(ba);
			this.goods_take.Add(p);
		}
		this.state = ba.ReadInt();
		this.letter_content = ba.ReadString();
		this.table = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.id);
		ba.WriteString(this.sender);
		ba.WriteString(this.receiver);
		ba.WriteString(this.title);
		ba.WriteInt(this.send_time);
		ba.WriteInt(this.type);
		for (int i = 0; i < goods_list.Count; i++){
		((p_goods)this.goods_list[i]).fill2s(ba);		}
		for (int i = 0; i < goods_take.Count; i++){
		((p_goods)this.goods_take[i]).fill2s(ba);		}
		ba.WriteInt(this.state);
		ba.WriteString(this.letter_content);
		ba.WriteInt(this.table);
	}
}