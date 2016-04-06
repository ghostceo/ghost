using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class m_super_mission_opt_toc:IncommingBase{
	//ID
	public int protocolID = 18501;

	//fields
	public bool succ = true;
	public int op_type = 0;
	public int err_code = 0;
	public int task_id = 0;
	public int new_task_state = 0;
	//special field
	private short __bytesLen;

	//fill method for toc
	public override void fill2c(ByteArray ba){
		this.succ = ba.ReadBoolean();
		this.op_type = ba.ReadInt();
		this.err_code = ba.ReadInt();
		this.task_id = ba.ReadInt();
		this.new_task_state = ba.ReadInt();
	}
}