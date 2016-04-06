using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Collections;
using System.Net;
using System.Net.Sockets;

public class MsgPacket
{
    public List<byte> buffer = null;
    public int begin = 0;

    public MsgPacket(List<byte> buffer)
    {
        this.buffer = buffer;
        this.begin = 0;
    }

    public byte readByte()
    {
        byte[] data = this.buffer.GetRange(this.begin, 1).ToArray();
        this.begin += 1;

        return MsgPacketUtil.readByte(data);
    }

    public short readShort()
    {
        byte[] data = this.buffer.GetRange(this.begin, 2).ToArray();
        this.begin += 2;

        return MsgPacketUtil.readShort(data);
    }

    public int readInt()
    {
        byte[] data = this.buffer.GetRange(this.begin, 4).ToArray();
        this.begin += 4;

        return MsgPacketUtil.readInt(data);
    }

    public long readLong()
    {
        byte[] data = this.buffer.GetRange(this.begin, 8).ToArray();
        this.begin += 8;

        return MsgPacketUtil.readLong(data);
    }

    public float readFloat()
    {
        byte[] data = this.buffer.GetRange(this.begin, 4).ToArray();
        this.begin += 4;

        return MsgPacketUtil.readFloat(data);
    }
    public double readDouble()
    {
        byte[] data = this.buffer.GetRange(this.begin, 8).ToArray();
        this.begin += 8;

        return MsgPacketUtil.readDouble(data);
    }

    public string readString()
    {
        int str_head_len = 2;
        byte[] data = this.buffer.GetRange(this.begin, str_head_len).ToArray();
        this.begin += str_head_len;
        int len = MsgPacketUtil.readInt(data);

        data = this.buffer.GetRange(this.begin, len).ToArray();
        this.begin += len;

        return MsgPacketUtil.readString(data);
    }

    public string readRpcName()
    {

        this.readInt(); //int zeroValue = 
        this.readByte(); //byte form = 
        return this.readString();
    }
}