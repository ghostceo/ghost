using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_system_setting_toc:IncommingBase{
	//ID
	public int protocolID = 3607;

	//fields
	public bool is_debug = false;
	public bool is_open_pay = false;
	public bool is_show_frame = false;
	public bool is_report_err = false;
	public int log_level = 0;
	public string payment_link;
	public string website_url;
	public string forum_url;
	public string service_qq1;
	public string service_qq2;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.is_debug = ba.ReadBoolean();
		this.is_open_pay = ba.ReadBoolean();
		this.is_show_frame = ba.ReadBoolean();
		this.is_report_err = ba.ReadBoolean();
		this.log_level = ba.ReadInt();
		this.payment_link = ba.ReadString();
		this.website_url = ba.ReadString();
		this.forum_url = ba.ReadString();
		this.service_qq1 = ba.ReadString();
		this.service_qq2 = ba.ReadString();
	}
}