using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_refresh_info:GameNetInfo{
	//fields
	public int refresh_type = 0;
	public int refresh_interval = 0;
	public int refresh_start_year = 0;
	public int refresh_end_year = 0;
	public int refresh_start_month = 0;
	public int refresh_end_month = 0;
	public int refresh_start_day = 0;
	public int refresh_end_day = 0;
	public int refresh_start_weekday = 0;
	public int refresh_end_weekday = 0;
	public int refresh_start_hour = 0;
	public int refresh_end_hour = 0;
	public int refresh_start_minute = 0;
	public int refresh_end_minute = 0;
	public int active_time = 0;
	public int start_time = 0;
	public int end_time = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.refresh_type = ba.ReadInt();
		this.refresh_interval = ba.ReadInt();
		this.refresh_start_year = ba.ReadInt();
		this.refresh_end_year = ba.ReadInt();
		this.refresh_start_month = ba.ReadInt();
		this.refresh_end_month = ba.ReadInt();
		this.refresh_start_day = ba.ReadInt();
		this.refresh_end_day = ba.ReadInt();
		this.refresh_start_weekday = ba.ReadInt();
		this.refresh_end_weekday = ba.ReadInt();
		this.refresh_start_hour = ba.ReadInt();
		this.refresh_end_hour = ba.ReadInt();
		this.refresh_start_minute = ba.ReadInt();
		this.refresh_end_minute = ba.ReadInt();
		this.active_time = ba.ReadInt();
		this.start_time = ba.ReadInt();
		this.end_time = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.refresh_type);
		ba.WriteInt(this.refresh_interval);
		ba.WriteInt(this.refresh_start_year);
		ba.WriteInt(this.refresh_end_year);
		ba.WriteInt(this.refresh_start_month);
		ba.WriteInt(this.refresh_end_month);
		ba.WriteInt(this.refresh_start_day);
		ba.WriteInt(this.refresh_end_day);
		ba.WriteInt(this.refresh_start_weekday);
		ba.WriteInt(this.refresh_end_weekday);
		ba.WriteInt(this.refresh_start_hour);
		ba.WriteInt(this.refresh_end_hour);
		ba.WriteInt(this.refresh_start_minute);
		ba.WriteInt(this.refresh_end_minute);
		ba.WriteInt(this.active_time);
		ba.WriteInt(this.start_time);
		ba.WriteInt(this.end_time);
	}
}