using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_sys_config:GameNetInfo{
	//fields
	public bool back_sound = true;
	public bool game_sound = true;
	public bool show_player = true;
	public bool auto_sell_white_equip = false;
	public bool auto_sell_green_equip = false;
	public bool auto_sell_blue_equip = false;
	public bool auto_sell_purple_equip = false;
	public bool auto_sanyuan = false;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.back_sound = ba.ReadBoolean();
		this.game_sound = ba.ReadBoolean();
		this.show_player = ba.ReadBoolean();
		this.auto_sell_white_equip = ba.ReadBoolean();
		this.auto_sell_green_equip = ba.ReadBoolean();
		this.auto_sell_blue_equip = ba.ReadBoolean();
		this.auto_sell_purple_equip = ba.ReadBoolean();
		this.auto_sanyuan = ba.ReadBoolean();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteBool(this.back_sound);
		ba.WriteBool(this.game_sound);
		ba.WriteBool(this.show_player);
		ba.WriteBool(this.auto_sell_white_equip);
		ba.WriteBool(this.auto_sell_green_equip);
		ba.WriteBool(this.auto_sell_blue_equip);
		ba.WriteBool(this.auto_sell_purple_equip);
		ba.WriteBool(this.auto_sanyuan);
	}
}