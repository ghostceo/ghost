using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_chat_postchat_toc:IncommingBase{
	//ID
	public int protocolID = 921;

	//fields
	public string game;
	public int server_id = 0;
	public string key;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.game = ba.ReadString();
		this.server_id = ba.ReadInt();
		this.key = ba.ReadString();
	}
}