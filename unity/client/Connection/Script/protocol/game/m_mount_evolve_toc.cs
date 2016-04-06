using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_mount_evolve_toc:IncommingBase{
	//ID
	public int protocolID = 16709;

	//fields
	public p_mount_info mount;
	public p_mount_info new_mount;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		if(ba.ReadByte() == 1){
			this.mount = new p_mount_info();
			this.mount.fill2c(ba);
		}
		if(ba.ReadByte() == 1){
			this.new_mount = new p_mount_info();
			this.new_mount.fill2c(ba);
		}
	}
}