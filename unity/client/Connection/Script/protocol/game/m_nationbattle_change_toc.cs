using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_nationbattle_change_toc:IncommingBase{
	//ID
	public int protocolID = 9106;

	//fields
	public int change_type = 0;
	public ArrayList new_value;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.change_type = ba.ReadInt();
		this.new_value = new ArrayList();
		ba.ReadIntArray(this.new_value);
	}
}