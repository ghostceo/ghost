using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class p_walk_path:GameNetInfo{
	//fields
	public int bpx = 0;
	public int bpy = 0;
	public ArrayList path;
	public int epx = 0;
	public int epy = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.bpx = ba.ReadInt();
		this.bpy = ba.ReadInt();
		this.path = new ArrayList();
		__bytesLen = ba.ReadShort();
		for (int i = 0; i < __bytesLen; i++){
			ba.ReadByte();
			p_map_tile p = new p_map_tile();
			p.fill2c(ba);
			this.path.Add(p);
		}
		this.epx = ba.ReadInt();
		this.epy = ba.ReadInt();
	}
	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(this.bpx);
		ba.WriteInt(this.bpy);
		for (int i = 0; i < path.Count; i++){
		((p_map_tile)this.path[i]).fill2s(ba);		}
		ba.WriteInt(this.epx);
		ba.WriteInt(this.epy);
	}
}