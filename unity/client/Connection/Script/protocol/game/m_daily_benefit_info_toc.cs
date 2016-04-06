using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_daily_benefit_info_toc:IncommingBase{
	//ID
	public int protocolID = 18801;

	//fields
	public int err_code = 0;
	public string reason;
	public ArrayList info_list;
	public p_daily_benefit_expback scene_exp;
	public p_daily_benefit_expback bigpve_exp;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.err_code = ba.ReadInt();
		this.reason = ba.ReadString();
		this.info_list = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_daily_benefit_info p = new p_daily_benefit_info();
			p.fill2c(ba);
			this.info_list.Add(p);
		}
		if(ba.ReadByte() == 1){
			this.scene_exp = new p_daily_benefit_expback();
			this.scene_exp.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.bigpve_exp = new p_daily_benefit_expback();
			this.bigpve_exp.fill2c(ba);
		}
	}
}