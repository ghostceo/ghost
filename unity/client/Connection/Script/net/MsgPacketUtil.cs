
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.IO;

public class MsgPacketUtil{
   
	private static MsgPacketUtil _instance = null;

    public static MsgPacketUtil getInstance()
    {
        if(_instance == null)
        {
            _instance = new MsgPacketUtil();
        }
        return _instance;
    }
	
    /// <summary>
	///  对象属性   begin
	/// </summary>
	
    /// <summary>
	///  对象属性   end
	/// </summary>	
	   	   
    private MsgPacketUtil(){	
	  	/// <summary>
		///  构造函数
		/// </summary>
	}
		   	   
   public static void write(List<byte> buffer,byte val)
   {
       byte[] bytes = TypeConvert.getBytes(val, true); //true bigend,false little end
       buffer.AddRange(bytes);
   }
	
	public static void write(List<byte> buffer, short val)
	{
		byte[] bytes = TypeConvert.getBytes(val, true);
		buffer.AddRange(bytes);
	}
		
	public static void write( List<byte> buffer,int val)
    {
        byte[] bytes = TypeConvert.getBytes(val, true); //true bigend,false little end
        buffer.AddRange(bytes);
    }

	public static void write(List<byte> buffer,float val)
    {
       //need to make BitConverter to be little ending
  
       byte[] bytes = BitConverter.GetBytes(val);
	   buffer.AddRange(bytes);
	}
    public static void write(List<byte> buffer,double val)
    {
       //need to make BitConverter to be little ending
  
       byte[] bytes = BitConverter.GetBytes(val);
	   buffer.AddRange(bytes);
	}
		
    public static void write( List<byte> buffer,string val)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(val);
        buffer.AddRange(TypeConvert.getBytes((short) bytes.GetLength(0), true)); //true bigend,false little end
        buffer.AddRange(bytes);
    }
	
	public static byte readByte(byte[] bytes)
    {
        return  TypeConvert.getByte(bytes, false); //true bigend,false little end //but here diffrent with write,why?
    }
	
	public static short readShort(byte[] bytes)
    {
        return  TypeConvert.getShort(bytes, false); //true bigend,false little end //but here diffrent with write,why?
    }
	
	public static int readInt(byte[] bytes)
    {
        return  TypeConvert.getInt(bytes, false); //true bigend,false little end //but here diffrent with write,why?
    }

    public static long readLong(byte[] bytes)
    {
        return TypeConvert.getLong (bytes, false); //true bigend,false little end //but here diffrent with write,why?
    }
	public static float readFloat(byte[] bytes)
    {
       float myFloat = System.BitConverter.ToSingle(bytes, 0);
	   return myFloat;
    }
    public static double readDouble(byte[] bytes)
    {
        double myDouble = System.BitConverter.ToDouble(bytes, 0);
        return myDouble;
    }
    
	public static string readString(byte[] bytes)
    {
		return Encoding.UTF8.GetString(bytes);
    }
	
	public static List<byte> packProtocol(List<byte> buffer, short protocol) {
		List<byte> all = new List<byte>();
        		
		int total_length = buffer.Count; // 协议
		MsgPacketUtil.write(all, total_length); //pack count
		MsgPacketUtil.write(all, protocol);
		all.AddRange(buffer);
		
        return all;
	}
}
