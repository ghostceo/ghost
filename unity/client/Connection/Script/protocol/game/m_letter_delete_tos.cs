using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_letter_delete_tos:OutgoingBase{
	//ID
	public int protocolID = 2108;

	//fields
	public ArrayList letters;
	//special field
	private short __bytesLen;


	//fill method for tos
	public override void fill2s(ByteArray ba){
		ba.WriteInt(10);
		ba.WriteInt(2108);
		for (int i = 0; i < letters.Count; i++){
		((p_letter_delete)this.letters[i]).fill2s(ba);		}
	}
}