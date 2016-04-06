using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_family_info:GameNetInfo{
	//fields
	public int family_id = 0;
	public string family_name;
	public int faction_id = 0;
	public int level = 0;
	public int create_role_id = 0;
	public string create_role_name;
	public int owner_role_id = 0;
	public string owner_role_name;
	public ArrayList second_owners;
	public int cur_members = 0;
	public int active_points = 0;
	public int money = 0;
	public ArrayList request_list;
	public ArrayList invite_list;
	public string public_notice;
	public string private_notice;
	public ArrayList members;
	public bool enable_map = false;
	public bool kill_uplevel_boss = false;
	public bool uplevel_boss_called = false;
	public int gongxun = 0;
	public int hour = 0;
	public int minute = 0;
	public int seconds = 0;
	public int interiormanager = 0;
	public int leftprotector = 0;
	public int rightprotector = 0;
	public int is_auto_agree = 0;
	public int badge = 0;
	public int max_member = 0;
	public int min_level = 0;
	public int min_fight_power = 0;
	public ArrayList elder;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.family_id = ba.ReadInt();
		this.family_name = ba.ReadString();
		this.faction_id = ba.ReadInt();
		this.level = ba.ReadInt();
		this.create_role_id = ba.ReadInt();
		this.create_role_name = ba.ReadString();
		this.owner_role_id = ba.ReadInt();
		this.owner_role_name = ba.ReadString();
		this.second_owners = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_second_owner p = new p_family_second_owner();
			p.fill2c(ba);
			this.second_owners.Add(p);
		}
		this.cur_members = ba.ReadInt();
		this.active_points = ba.ReadInt();
		this.money = ba.ReadInt();
		this.request_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_request p = new p_family_request();
			p.fill2c(ba);
			this.request_list.Add(p);
		}
		this.invite_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_invite p = new p_family_invite();
			p.fill2c(ba);
			this.invite_list.Add(p);
		}
		this.public_notice = ba.ReadString();
		this.private_notice = ba.ReadString();
		this.members = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_member_info p = new p_family_member_info();
			p.fill2c(ba);
			this.members.Add(p);
		}
		this.enable_map = ba.ReadBoolean();
		this.kill_uplevel_boss = ba.ReadBoolean();
		this.uplevel_boss_called = ba.ReadBoolean();
		this.gongxun = ba.ReadInt();
		this.hour = ba.ReadInt();
		this.minute = ba.ReadInt();
		this.seconds = ba.ReadInt();
		this.interiormanager = ba.ReadInt();
		this.leftprotector = ba.ReadInt();
		this.rightprotector = ba.ReadInt();
		this.is_auto_agree = ba.ReadInt();
		this.badge = ba.ReadInt();
		this.max_member = ba.ReadInt();
		this.min_level = ba.ReadInt();
		this.min_fight_power = ba.ReadInt();
		this.elder = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_family_elder p = new p_family_elder();
			p.fill2c(ba);
			this.elder.Add(p);
		}
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.family_id);
		ba.WriteString(this.family_name);
		ba.WriteInt(this.faction_id);
		ba.WriteInt(this.level);
		ba.WriteInt(this.create_role_id);
		ba.WriteString(this.create_role_name);
		ba.WriteInt(this.owner_role_id);
		ba.WriteString(this.owner_role_name);
		for (int i = 0; i < second_owners.Count; i++){
		((p_family_second_owner)this.second_owners[i]).fill2s(ba);		}
		ba.WriteInt(this.cur_members);
		ba.WriteInt(this.active_points);
		ba.WriteInt(this.money);
		for (int i = 0; i < request_list.Count; i++){
		((p_family_request)this.request_list[i]).fill2s(ba);		}
		for (int i = 0; i < invite_list.Count; i++){
		((p_family_invite)this.invite_list[i]).fill2s(ba);		}
		ba.WriteString(this.public_notice);
		ba.WriteString(this.private_notice);
		for (int i = 0; i < members.Count; i++){
		((p_family_member_info)this.members[i]).fill2s(ba);		}
		ba.WriteBool(this.enable_map);
		ba.WriteBool(this.kill_uplevel_boss);
		ba.WriteBool(this.uplevel_boss_called);
		ba.WriteInt(this.gongxun);
		ba.WriteInt(this.hour);
		ba.WriteInt(this.minute);
		ba.WriteInt(this.seconds);
		ba.WriteInt(this.interiormanager);
		ba.WriteInt(this.leftprotector);
		ba.WriteInt(this.rightprotector);
		ba.WriteInt(this.is_auto_agree);
		ba.WriteInt(this.badge);
		ba.WriteInt(this.max_member);
		ba.WriteInt(this.min_level);
		ba.WriteInt(this.min_fight_power);
		for (int i = 0; i < elder.Count; i++){
		((p_family_elder)this.elder[i]).fill2s(ba);		}
	}
}