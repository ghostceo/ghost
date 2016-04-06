using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_chat_role:GameNetInfo{
	//fields
	public int roleid = 0;
	public string rolename;
	public int factionid = 0;
	public string faction_name;
	public int sex = 0;
	public int head = 0;
	public string sign;
	public ArrayList titles;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.roleid = ba.ReadInt();
		this.rolename = ba.ReadString();
		this.factionid = ba.ReadInt();
		this.faction_name = ba.ReadString();
		this.sex = ba.ReadInt();
		this.head = ba.ReadInt();
		this.sign = ba.ReadString();
		this.titles = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_chat_title p = new p_chat_title();
			p.fill2c(ba);
			this.titles.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.roleid);
		ba.WriteString(this.rolename);
		ba.WriteInt(this.factionid);
		ba.WriteString(this.faction_name);
		ba.WriteInt(this.sex);
		ba.WriteInt(this.head);
		ba.WriteString(this.sign);
		for (int i = 0; i < titles.Count; i++){
		((p_chat_title)this.titles[i]).fill2s(ba);		}
	}
}