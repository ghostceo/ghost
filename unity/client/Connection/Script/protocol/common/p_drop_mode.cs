using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_drop_mode:GameNetInfo{
	//fields
	public int mode_id = 0;
	public int bind_rate = 0;
	public ArrayList bind_colour;
	public ArrayList unbind_colour;
	public ArrayList bind_quality;
	public ArrayList unbind_quality;
	public ArrayList bind_hole;
	public ArrayList unbind_hole;
	public int use_bind = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.mode_id = ba.ReadInt();
		this.bind_rate = ba.ReadInt();
		this.bind_colour = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_drop_colour_mode p = new p_drop_colour_mode();
			p.fill2c(ba);
			this.bind_colour.Add(p);
		}
		this.unbind_colour = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_drop_colour_mode p = new p_drop_colour_mode();
			p.fill2c(ba);
			this.unbind_colour.Add(p);
		}
		this.bind_quality = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_drop_quality_mode p = new p_drop_quality_mode();
			p.fill2c(ba);
			this.bind_quality.Add(p);
		}
		this.unbind_quality = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_drop_quality_mode p = new p_drop_quality_mode();
			p.fill2c(ba);
			this.unbind_quality.Add(p);
		}
		this.bind_hole = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_drop_hole_mode p = new p_drop_hole_mode();
			p.fill2c(ba);
			this.bind_hole.Add(p);
		}
		this.unbind_hole = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_drop_hole_mode p = new p_drop_hole_mode();
			p.fill2c(ba);
			this.unbind_hole.Add(p);
		}
		this.use_bind = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.mode_id);
		ba.WriteInt(this.bind_rate);
		for (int i = 0; i < bind_colour.Count; i++){
		((p_drop_colour_mode)this.bind_colour[i]).fill2s(ba);		}
		for (int i = 0; i < unbind_colour.Count; i++){
		((p_drop_colour_mode)this.unbind_colour[i]).fill2s(ba);		}
		for (int i = 0; i < bind_quality.Count; i++){
		((p_drop_quality_mode)this.bind_quality[i]).fill2s(ba);		}
		for (int i = 0; i < unbind_quality.Count; i++){
		((p_drop_quality_mode)this.unbind_quality[i]).fill2s(ba);		}
		for (int i = 0; i < bind_hole.Count; i++){
		((p_drop_hole_mode)this.bind_hole[i]).fill2s(ba);		}
		for (int i = 0; i < unbind_hole.Count; i++){
		((p_drop_hole_mode)this.unbind_hole[i]).fill2s(ba);		}
		ba.WriteInt(this.use_bind);
	}
}