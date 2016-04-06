using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_role_choose_toc:IncommingBase{
	//ID
	public int protocolID = 404;

	//fields
	public bool succ = false;
	public string reason;
	public p_role role_details;
	public ArrayList bags;
	public p_family_info family;
	public p_main_fb_info main_fb;
	public int server_id = 0;
	public int server_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.reason = ba.ReadString();
		if(ba.ReadByte() == 1){
			this.role_details = new p_role();
			this.role_details.fill2c(ba);
		}
		this.bags = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_bag_content p = new p_bag_content();
			p.fill2c(ba);
			this.bags.Add(p);
		}
		if(ba.ReadByte() == 1){
			this.family = new p_family_info();
			this.family.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.main_fb = new p_main_fb_info();
			this.main_fb.fill2c(ba);
		}
		this.server_id = ba.ReadInt();
		this.server_time = ba.ReadInt();
	}
}