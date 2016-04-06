using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_ranking:GameNetInfo{
	//fields
	public int rank_id = 0;
	public int rank_row = 0;
	public int rank_column = 0;
	public string rank_first_name;
	public string rank_second_name;
	public int capacity = 0;
	public ArrayList elements;
	public int refresh_type = 0;
	public int refresh_interval = 0;
	public p_title rank_title;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.rank_id = ba.ReadInt();
		this.rank_row = ba.ReadInt();
		this.rank_column = ba.ReadInt();
		this.rank_first_name = ba.ReadString();
		this.rank_second_name = ba.ReadString();
		this.capacity = ba.ReadInt();
		this.elements = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_rank_element p = new p_rank_element();
			p.fill2c(ba);
			this.elements.Add(p);
		}
		this.refresh_type = ba.ReadInt();
		this.refresh_interval = ba.ReadInt();
		if(ba.ReadByte() == 1){
			this.rank_title = new p_title();
			this.rank_title.fill2c(ba);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.rank_id);
		ba.WriteInt(this.rank_row);
		ba.WriteInt(this.rank_column);
		ba.WriteString(this.rank_first_name);
		ba.WriteString(this.rank_second_name);
		ba.WriteInt(this.capacity);
		for (int i = 0; i < elements.Count; i++){
		((p_rank_element)this.elements[i]).fill2s(ba);		}
		ba.WriteInt(this.refresh_type);
		ba.WriteInt(this.refresh_interval);
		this.rank_title.fill2s(ba);
	}
}