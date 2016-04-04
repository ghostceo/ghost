package com.unity.socket;

import java.nio.ByteBuffer;

import com.unity.socket.ConvertType;

public class Message {
    private ByteBuffer buf;
    public Message(){
        buf=ByteBuffer.allocate(0);
    }

    public ByteBuffer getBuff(){
        return  buf;
    }

    public void clear(){
        buf.clear();
    }

    public void addSize(int len){
        ByteBuffer tmpbuf=ByteBuffer.allocate(buf.capacity()+len);
        buf=null;
        buf=tmpbuf;
    }

    public void writeByte(byte b){
       addSize(1);
       buf.put(b);
    }

    public void write(byte[] b){
        addSize(b.length);
        buf.put(b);
    }

     public void writeShort(short b){
        addSize(2);
        buf.put(ConvertType.getBytes(b,true));
    }

    public void writeInt(int b){
        addSize(4);
        buf.put(ConvertType.getBytes(b,true));
    }

     public void writeLong(long b){
        addSize(8);
        buf.put(ConvertType.getBytes(b,true));
    }

    public void writeFloat(float b){
        addSize(4);
        buf.put(ConvertType.getBytes(b,true)) ;
    }

    public void writeString(String s){
        byte[] b= new byte[200];
        b=s.getBytes();
        addSize(4+b.length);
        buf.put(ConvertType.getBytes(b.length,true));
        buf.put(s.getBytes());
    }
}
