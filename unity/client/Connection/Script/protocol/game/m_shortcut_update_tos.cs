using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_shortcut_update_tos:OutgoingBase{
	//ID
	public int protocolID = 3202;

	//fields
	public ArrayList shortcut_list;
	public int selected = 0;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(3202);
		for (int i = 0; i < shortcut_list.Count; i++){
		((p_shortcut)this.shortcut_list[i]).fill2s(ba);		}
		ba.WriteInt(this.selected);
	}
}