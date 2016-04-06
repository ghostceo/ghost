
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TypeConvert
{
	/// <summary>
	/// 处理2进制数据，到对应数值转换的方便函数集。
	/// 可用 BitConverter来，不用这个
	/// BitConverter.IsLittleEndian
	/// BitConverter.ToInt32
	/// </summary>
	
	private static TypeConvert _instance = null;

    public static TypeConvert getInstance()
    {
        if(_instance == null)
        {
            _instance = new TypeConvert();
        }
        return _instance;
    }
   
    /// <summary>
	///  对象属性   begin
	/// </summary>
	
    /// <summary>
	///  对象属性   end
	/// </summary>	
	 
    private TypeConvert(){	
	  	/// <summary>
		///  构造函数
		/// </summary>
	}
	  
	public static byte[] getBytes (byte s, bool asc)
	{
		byte[] buf = new byte[1];
		if (asc) {
			buf [0] = (byte)(s & 0x00ff);
			s >>= 8;
		} else {
			buf [0] = (byte)(s & 0x00ff);
			s >>= 8;
		}
		return buf;
	}

	public static byte[] getBytes (short s, bool asc)
	{
		byte[] buf = new byte[2];
		if (asc) 
		{
			for (int i = buf.Length - 1; i >= 0; i--) 
			{
				buf [i] = (byte)(s & 0x00ff);
				s >>= 8;
			}
		} else {
			for (int i = 0; i < buf.Length; i++) 
			{

				buf [i] = (byte)(s & 0x00ff);
				s >>= 8;
			}
		}
		return buf;
	}

	public static byte[] getBytes (int s, bool asc)
	{
		byte[] buf = new byte[4];
		if (asc)
		{
			for (int i = buf.Length - 1; i >= 0; i--) 
			{
				buf [i] = (byte)(s & 0x000000ff);
				s >>= 8;
			}
		}
		else
		{
			for (int i = 0; i < buf.Length; i++) 
			{
				buf [i] = (byte)(s & 0x000000ff);
				s >>= 8;
			}
		}
		return buf;
	}

	public static byte[] getBytes (long s, bool asc)
	{
		byte[] buf = new byte[8];
		if (asc)
			for (int i = buf.Length - 1; i >= 0; i--) {
				buf [i] = (byte)(s & 0x00000000000000ff);
				s >>= 8;
			}
		else
			for (int i = 0; i < buf.Length; i++) {
				buf [i] = (byte)(s & 0x00000000000000ff);
				s >>= 8;
			}
		return buf;
	}

	public static byte getByte (byte[] buf, bool asc)
	{
		if (buf == null) {
			//throw new IllegalArgumentException("byte array is null!");  
		}
		if (buf.Length > 1) {
			//throw new IllegalArgumentException("byte array size > 2 !");  
		}
		byte r = 0;
		if (asc) {
			r <<= 8;
			r |= (byte)(buf [0] & 0x00ff);
		} else {
			r <<= 8;
			r |= (byte)(buf [0] & 0x00ff);
		}
		return r;
	}

	public static short getShort (byte[] buf, bool asc)
	{
		if (buf == null) {
			//throw new IllegalArgumentException("byte array is null!");  
		}
		if (buf.Length > 2) {
			//throw new IllegalArgumentException("byte array size > 2 !");  
		}
		short r = 0;
		if (asc)
			for (int i = buf.Length - 1; i >= 0; i--) {
				r <<= 8;
				r |= (short)(buf [i] & 0x00ff);
			}
		else
			for (int i = 0; i < buf.Length; i++) {
				r <<= 8;
				r |= (short)(buf [i] & 0x00ff);
			}
		return r;
	}

	public static int getInt (byte[] buf, bool asc)
	{
		if (buf == null) {
			// throw new IllegalArgumentException("byte array is null!");  
		}
		if (buf.Length > 4) {
			//throw new IllegalArgumentException("byte array size > 4 !");  
		}
		int r = 0;
		if (asc)
			for (int i = buf.Length - 1; i >= 0; i--) {
				r <<= 8;
				r |= (buf [i] & 0x000000ff);
			}
		else
			for (int i = 0; i < buf.Length; i++) {
				r <<= 8;
				r |= (buf [i] & 0x000000ff);
			}
		return r;
	}

	public static long getLong (byte[] buf, bool asc)
	{
		if (buf == null) {
			//throw new IllegalArgumentException("byte array is null!");  
		}
		if (buf.Length > 8) {
			//throw new IllegalArgumentException("byte array size > 8 !");  
		}
		long r = 0;
		if (asc)
			for (int i = buf.Length - 1; i >= 0; i--) {
				//r <<= 8;
				//r |= (buf [i] & 0x00000000000000ff);
			}
		else
			for (int i = 0; i < buf.Length; i++) {
				//r <<= 8;
				//r |= (buf [i] & 0x00000000000000ff);
			}
		return r;
	}

}