using UnityEngine;
using System.Collections;
using System;
using System.Text;

public class ByteArray
{
    private int MAX_BUFF_SIZE = 2048;

    protected byte[] mDataBuff;
    protected int mLength = 0;
    protected int mPosition = 0;

    public ByteArray(int bufferSize = 2046)
    {
        this.MAX_BUFF_SIZE = bufferSize;
        mDataBuff = new byte[MAX_BUFF_SIZE];
    }

    public void InitBytesArray(byte[] buff, int len)
    {
        if (len > MAX_BUFF_SIZE)
        {
            throw new Exception("InitBytesArray 初始化失败，超出字节流最大限制");
        }
        Array.Copy(buff, mDataBuff, len);
        mLength = len;
        mPosition = 0;
    }

    public bool CreateFromSocketBuff(byte[] buff, int nSize)
    {
        if (buff == null)
        {
            return false;
        }
        this.mLength = LittleEndianBitConverter.Big.ToInt32(buff, 0);
        if ((this.mLength > MAX_BUFF_SIZE) || (this.mLength <= 0))
        {
            return false;
        }
        //不包含协议包的长度数据，所以从4开始
        Array.Copy(buff, 4, this.mDataBuff, 0, this.mLength);
        mPosition = 0;
        return true;
    }
    public bool CreateFromSocketBuffWithProtocolLength(byte[] buff, int nSize)
    {
        Debug.Log("拷byte到byteArray" + mPosition);
        if (buff == null)
        {
            return false;
        }
        //这里有问题
        int buffLen = LittleEndianBitConverter.Big.ToInt32(buff, 0);
        this.mLength += nSize;
        if ((this.mLength > MAX_BUFF_SIZE) || (this.mLength <= 0))
        {
            return false;
        }
        //直接把buff里的数据拷到mDataBuff里面
        Array.Copy(buff, 0, this.mDataBuff, mPosition, nSize);
        //Array.Copy(buff, mPosition, this.mDataBuff, 0, nSize);
        //mPosition = 0;
        return true;
    }

    public bool CopyFromByteArray(ref byte[] aBuff, ref int nSize)
    {
        if (aBuff == null)
        {
            return false;
        }
        Array.Copy(this.mDataBuff, 0, aBuff, 0, this.mLength);
        nSize = mLength;
        return true;
    }

    public void WriteBool(bool value)
    {

        Array.Copy(LittleEndianBitConverter.Big.GetBytes(value), 0, mDataBuff, mPosition, 2);
        mPosition += 2;
        mLength = mPosition;
        CheckBuffSize();
    }

    public void WriteByte(int value)
    {
        mDataBuff[mPosition] = (byte)value;
        mPosition++;
        mLength = mPosition;
        CheckBuffSize();
    }

    public void WriteBytes(ByteArray bytes)
    {
        int nLen = bytes.mLength;
        Array.Copy(LittleEndianBitConverter.Big.GetBytes(nLen), 0, mDataBuff, mPosition, 2);
        mPosition += 2;
        Array.Copy(bytes.mDataBuff, 0, mDataBuff, mPosition, nLen);
        mPosition += nLen;
        mLength = mPosition;
        CheckBuffSize();
    }

    public void WriteDouble(double value)
    {
        Array.Copy(LittleEndianBitConverter.Big.GetBytes(value), 0, mDataBuff, mPosition, 8);
        mPosition += 8;
        mLength = mPosition;
        CheckBuffSize();
    }

    public void WriteFloat(float value)
    {
        Array.Copy(LittleEndianBitConverter.Big.GetBytes(value), 0, mDataBuff, mPosition, 4);
        mPosition += 4;
        mLength = mPosition;
        CheckBuffSize();
    }

    public void WriteInt(int value)
    {
        Array.Copy(LittleEndianBitConverter.Big.GetBytes(value), 0, mDataBuff, mPosition, 4);
        mPosition += 4;
        mLength = mPosition;
        CheckBuffSize();
    }

    public void WriteShort(int value)
    {
        Array.Copy(LittleEndianBitConverter.Big.GetBytes((short)value), 0, mDataBuff, mPosition, 2);
        mPosition += 2;
        mLength = mPosition;
        CheckBuffSize();
    }

    public void WriteString(string value)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(value);
        short strLength = (short)bytes.Length;
        Array.Copy(LittleEndianBitConverter.Big.GetBytes(strLength), 0, mDataBuff, mPosition, 2);
        mPosition += 2;
        Array.Copy(bytes, 0, mDataBuff, mPosition, strLength);
        mPosition += strLength;
        mLength = mPosition;
        CheckBuffSize();
    }

    //public bool ReadBoolean() 
    //{
    //    if ((mPosition + 2) > mLength)
    //    {
    //        throw new Exception("ReadBoolean读取数据失败，读取数据超出字节流范围");
    //    }
    //    bool value = LittleEndianBitConverter.Big.ToBoolean(mDataBuff, mPosition); ;
    //    mPosition+=2;
    //    return value;
    //}

    public bool ReadBoolean()
    {
        if ((mPosition + 1) > mLength)
        {
            throw new Exception("ReadBoolean读取数据失败，读取数据超出字节流范围");
        }
        byte value = (byte)mDataBuff[mPosition];
        mPosition += 1;
        return value == 1;
    }

    public byte ReadByte()
    {
        if ((mPosition + 1) > mLength)
        {
            throw new Exception("ReadByte读取数据失败，读取数据超出字节流范围");
        }
        byte value = (byte)mDataBuff[mPosition];
        mPosition++;
        return value;
    }

    public ByteArray ReadBytes()
    {
        if ((mPosition + 2) > mLength)
        {
            throw new Exception("ReadBytes[0]读取数据失败，读取数据超出字节流范围");
        }
        int length = LittleEndianBitConverter.Big.ToInt32(mDataBuff, mPosition);
        mPosition += 2;
        if ((length < 0) || (length > MAX_BUFF_SIZE))
        {
            throw new Exception("ReadBytes[1]读取数据失败，读取数据超出字节流范围");
        }
        ByteArray values = new ByteArray();
        Array.Copy(mDataBuff, mPosition, values.mDataBuff, 0, length);
        values.mPosition = 0;
        values.mLength = length;
        mPosition += length;
        return values;
    }

    public double ReadDouble()
    {
        if ((mPosition + 8) > mLength)
        {
            throw new Exception("ReadDouble读取数据失败，读取数据超出字节流范围");
        }
        double value = LittleEndianBitConverter.Big.ToDouble(mDataBuff, mPosition);
        mPosition += 8;
        return value;
    }

    public float ReadFloat()
    {
        if ((mPosition + 4) > mLength)
        {
            throw new Exception("ReadFloat读取数据失败，读取数据超出字节流范围");
        }
        float value = LittleEndianBitConverter.Big.ToSingle(mDataBuff, mPosition);
        mPosition += 4;
        return value;
    }

    public int ReadInt()
    {
        if ((mPosition + 4) > mLength)
        {
            throw new Exception("ReadInt读取数据失败，读取数据超出字节流范围");
        }
        int value = LittleEndianBitConverter.Big.ToInt32(mDataBuff, mPosition);
        mPosition += 4;
        return value;
    }
    
    public short ReadShort()
    {
        if ((mPosition + 2) > mLength)
        {
            throw new Exception("ReadShort读取数据失败，读取数据超出字节流范围");
        }
        short value = LittleEndianBitConverter.Big.ToInt16(mDataBuff, mPosition);
        mPosition += 2;
        return value;
    }

    public string ReadString()
    {
        if ((mPosition + 2) > mLength)
        {
            throw new Exception("ReadString[0]读取数据失败，读取数据超出字节流范围");
        }
        short count = LittleEndianBitConverter.Big.ToInt16(mDataBuff, mPosition);
        mPosition += 2;
        string value = Encoding.UTF8.GetString(mDataBuff, mPosition, count);
        mPosition += count;
        return value;
    }
     
    //added by wuzesen
    public void ReadBooleanArray(ArrayList list){
        short len = ReadShort();
    	for (int i = 0; i < len; i++){
    		list.Add(ReadBoolean());
        }
    }
    
    public void ReadIntArray(ArrayList list){
        short len = ReadShort();
    	for (int i = 0; i < len; i++){
            list.Add(ReadInt());
        }
    }
    
    public void ReadFloatArray(ArrayList list){
        short len = ReadShort();
    	for (int i = 0; i < len; i++){
            list.Add(ReadFloat());
        }
    }
    
    public void ReadDoubleArray(ArrayList list){
        short len = ReadShort();
    	for (int i = 0; i < len; i++){
            list.Add(ReadDouble());
        }
    }
    
    public void ReadStringArray(ArrayList list){
        short len = ReadShort();
    	for (int i = 0; i < len; i++){
            list.Add(ReadString());
        }
    }


    public void WriteBooleanArray(ArrayList list){
        WriteShort( list.Count );
        for (int i = 0; i < list.Count; i++)
        {
            WriteByte((int)list[i] );
        }
    }
    
    public void WriteIntArray(ArrayList list){
        WriteShort(list.Count);
        for (int i = 0; i < list.Count; i++)
        {
            WriteInt((int)list[i]);
        }
    }
    
    public void WriteFloatArray(ArrayList list){
        WriteShort(list.Count);
        for (int i = 0; i < list.Count; i++)
        {
            WriteFloat((float)list[i]);
        }
    }
    
    public void WriteDoubleArray(ArrayList list){
        WriteShort(list.Count);
        for (int i = 0; i < list.Count; i++)
        {
            WriteDouble((double)list[i]);
        }
    }
    
    public void WriteStringArray(ArrayList list){
        WriteShort(list.Count);
        for (int i = 0; i < list.Count; i++)
        {
            WriteString((string)list[i]);
        }
    }

    private void CheckBuffSize()
    {
        if (mPosition > MAX_BUFF_SIZE)
        {
            throw new Exception("InitBytesArray初始化失败，超出字节流最大限制");
        }
    }

    public void RemoveReaded()
    {
        if (mLength <= mPosition)
        {
            mPosition = 0;
            mLength = 0;
            mDataBuff.Initialize();
        }
        else if (mLength > mPosition)
        {
            byte[] destinationArray = new byte[MAX_BUFF_SIZE];
            Array.Copy(mDataBuff, mPosition, destinationArray, 0, mLength - mPosition);
            mDataBuff = destinationArray;
            mLength = mLength - mPosition;
            mPosition = 0;
        }
    }

    public byte[] Buff
    {
        get
        {
            return mDataBuff;
        }
    }

    public int Length
    {
        get
        {
            return mLength;
        }
    }

    public int Postion 
    {
        get
        {
            return mPosition;
        }
        set 
        {
            mPosition = value;
        }
    }
}
