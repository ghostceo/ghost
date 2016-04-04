
namespace LSocket.Msg
{
	using System;
	using UnityEngine;
	using System.Collections.Generic;
	using System.Data;
	using LSocket.Test;
	using LSocket.erl;
	using LSocket.Type;
	using System.Text;

	public abstract class Message
	{

		private string name;
		private int id;


		public abstract string getMethodName();

		public abstract string getClassName();
				
		public abstract string[][] getAttributes();

		public abstract int getIntValue(string s);

		public abstract long getLongValue(string s);

		public abstract string getStringValue(string s);
				
 		public byte[] encode(short Unique,byte ModelID, short MethedID,Message vo)
			{	
				List<byte> packtmp = new List<byte>();
				byte[] unique = TypeConvert.getBytes(Unique,true);
				byte[] modelid = TypeConvert.getBytes(ModelID,true);
				byte[] methedid = TypeConvert.getBytes(MethedID,true);
				packtmp.AddRange(unique);
				packtmp.AddRange(modelid);
				packtmp.AddRange(methedid);
				return pack(vo,packtmp);
			}
				
		/**
		 * 编码数据包
		 */
		public byte[] pack(Message vo,List<byte> packtmp)
			{
				byte[] head = TypeConvert.getBytes(ErlangTy.TUPLE,true);
				packtmp.AddRange(head);
				if (vo == null)
				{
					byte[] unde = TypeConvert.getBytes(ErlangTy.UNDEFINE,true);
					packtmp.AddRange(unde);
					byte[] bodys = Encoding.UTF8.GetBytes("undefined");
					packtmp.AddRange(bodys);
				} else {
				int lenT = vo.getAttributes().Length;
				// int len  = 0;
			    int i    = 0;
				// int j    = 0;
				string subtype;
				if (lenT > 255)
					{
						byte[] max = TypeConvert.getBytes(ErlangTy.MAX,true);
						packtmp.AddRange(max);
						byte[] lenTs = TypeConvert.getBytes((byte)(lenT+1),true);
						packtmp.AddRange(lenTs);
					}
					else
					{
						byte[] min = TypeConvert.getBytes(ErlangTy.MIN,true);
						packtmp.AddRange(min);
						byte[] lenTs = TypeConvert.getBytes((byte)(lenT+1),true);
						packtmp.AddRange(lenTs);
					}
					byte[] tato = TypeConvert.getBytes(ErlangTy.TATOM,true);
					packtmp.AddRange(tato);
					string classname = vo.getClassName();
					short namelen = (short)classname.Length;
					byte[] namelens = TypeConvert.getBytes(namelen,true);
					packtmp.AddRange(namelens);
					byte[] name = Encoding.UTF8.GetBytes(classname);
               		packtmp.AddRange(name);
					for (i=0; i < lenT; i++)
					{
						subtype = vo.getAttributes()[i][1];
						string typename = vo.getAttributes()[i][0];
						if (subtype == "int32")
						{
							byte[] tint = TypeConvert.getBytes(ErlangTy.INT32,true);
							packtmp.AddRange(tint);
							byte[] tints = TypeConvert.getBytes(vo.getIntValue(typename),true);
							packtmp.AddRange(tints);
						}
						else if (subtype == "double" || subtype == "Number" || subtype == "number")
						{
							byte[] tdou = TypeConvert.getBytes(ErlangTy.DOUBLE,true);
							packtmp.AddRange(tdou);
							byte[] tdous = TypeConvert.getBytes(vo.getLongValue(typename),true);
							packtmp.AddRange(tdous);
						}
						else if (subtype == "string")
						{
							byte[] tstr = TypeConvert.getBytes(ErlangTy.TSTRING,true);
							packtmp.AddRange(tstr);
							string substr = vo.getStringValue(typename);
							short sublen = (short)substr.Length;
							byte[] sublens = TypeConvert.getBytes(sublen,true);
							packtmp.AddRange(sublens);
 							byte[] tstrss = Encoding.UTF8.GetBytes(substr);
							packtmp.AddRange(tstrss);
						}
						else if (subtype == "bool" || subtype == "boolean")
						{
							byte[] tbool = TypeConvert.getBytes(ErlangTy.INT32,true);
							packtmp.AddRange(tbool);
							byte[] tbools = TypeConvert.getBytes(vo.getIntValue(typename),true);
							packtmp.AddRange(tbools);
						}
						// else if (subtype == "array")
						// {
						// 	len=(vo.getAttributes()[i][2] as Array).Length;
						// 	if (len > 0)
						// 	{
						// 		result.WriteByte(108);
						// 		result.WriteInt(len);
						// 		string subTypes = vo.getAttributes()[i][2];
						// 		for (j=0; j < len; j++)
						// 		{
						// 			if (subTypes == "int32")
						// 			{
						// 				result.WriteByte(98); // 不做优化
						// 				result.WriteInt(vo.getAttributes()[i][2][j]);
						// 			}
						// 			else if (subTypes == "double" || subTypes == "Number" || subTypes == "number")
						// 			{
						// 				result.WriteByte(70);
						// 				result.WriteDouble(vo.getAttributes()[i][2][j]);
						// 			}
						// 			else if (subTypes == "string")
						// 			{
						// 				result.WriteByte(107);
						// 				result.WriteUTF(vo.getAttributes()[i][2][j]);
						// 			}
						// 			else if (subTypes == "bool" || subTypes == "boolean")
						// 			{
						// 				result.WriteByte(100);
						// 				if (vo.getAttributes()[i][2][j]=="true")
						// 				{
						// 					result.writeUTF("true");
						// 				}
						// 				else
						// 				{
						// 					result.writeUTF("false");
						// 				}
						// 			}
						// 			else
						// 			{
						// 				pack(vo.getAttributes[i][2][j], result);
						// 			}
						// 		}
						// 	}
						// 	result.WriteByte(106);
						// }
						// else if (subtype == "bytes")
						// {
						// 	byte[] tbyte = TypeConvert.getBytes(ErlangTy.BYTE,true);
						// 	pack.AddRange(tbyte);
						// 	byte[] tttByt = vo.getAttributes[i][2];
						// 	result.WriteInt(tttByte.Length);
						// 	result.WriteBytes(tttByte, result.position, tttByte.Length);
						// }
					}
				}
					ByteBuffer msg = ByteBuffer.Allocate(packtmp.Count);
            		foreach( byte submsg in packtmp )
            		{
                		msg.WriteByte(submsg);
            		}
					return msg.buf;
			}
				
		/**
		 * 解码数据包
		 */
	// 	public Message unpack(array result)
	// 		{
	// 			//			var ttttt:int = getTimer();
	// 			if (result[0] == getClassName())
	// 			{
	// 				vo=this;
	// 			}
	// 			else
	// 			{
	// 				var vo:Message;
	// 				var voClass:Class=getDefine(result[0]);
	// 				vo=new voClass;
	// 			}
	// 			var j:int=0;
	// 			var attrs:Array=vo.getAttributes();
	// 			for (var i:int=1; i < result.length; i++)
	// 			{
	// 				var type:String=attrs[i - 1][1].toString().toLowerCase();
	// 				if (type == 'int')
	// 				{
	// 					vo[attrs[i - 1][0]]=int(result[i]);
	// 				}
	// 				else if (type == 'bytes')
	// 				{
	// 					var tmpByteArray21:ByteArray=new ByteArray;
	// 					tmpByteArray21.writeUTFBytes(attrs[i - 1][1]);
	// 					vo[attrs[i - 1][0]]=tmpByteArray2;
	// 				}
	// 				else if (type == 'double' || type == 'number')
	// 				{
	// 					vo[attrs[i - 1][0]]=Number(result[i]);
	// 				}
	// 				else if (type == 'string')
	// 				{
	// 					if (result[i] == 'undefined')
	// 					{
	// 						vo[attrs[i - 1][0]]=null;
	// 					}
	// 					else
	// 					{
	// 						var tmpByteArray:ByteArray=new ByteArray;
	// 						if ((result[i] as Array) != null)
	// 						{
	// 							var tLen:int=(result[i] as Array).length;
	// 							for (var k:int=0; k < tLen; k++)
	// 							{
	// 								tmpByteArray.writeByte(result[i][k]);
	// 							}
	// 							tmpByteArray.position=0;
	// 							vo[attrs[i - 1][0]]=tmpByteArray.readUTFBytes(tLen);
	// 						}
	// 						else
	// 						{
	// 							vo[attrs[i - 1][0]]=result[i].toString();
	// 						}
	// 					}
	// 				}
	// 				else if (type == 'bool' || type == 'boolean')
	// 				{
	// 					vo[attrs[i - 1][0]]=(result[i] == "true") ? true : false;
	// 				}
	// 				else if (type == 'array')
	// 				{
	// 					var t:Array=new Array();
	// 					if (result[i] == 'undefined')
	// 					{
	// 					}
	// 					else
	// 					{
	// 						var subType:String=attrs[i - 1][2].toString().toLowerCase();
	// 						if (subType == 'int')
	// 						{
	// 							if (result[i] != 'undefined')
	// 							{
	// 								for (j=0; j < result[i].length; j++)
	// 								{
	// 									t.push(int(result[i][j]));
	// 								}
	// 							}
	// 						}
	// 						else if (subType == 'double' || type == 'Number')
	// 						{
	// 							for (j=0; j < result[i].length; j++)
	// 							{
	// 								t.push(Number(result[i][j]));
	// 							}
	// 						}
	// 						else if (subType == 'string')
	// 						{
	// 							for (j=0; j < result[i].length; j++)
	// 							{
	// 								if (result[i] == 'undefined')
	// 								{
	// 									t.push(null);
	// 								}
	// 								else
	// 								{
	// 									var tmpByteArray2:ByteArray=new ByteArray;
	// 									if ((result[i][j] as Array) != null)
	// 									{
	// 										var tLen2:int=(result[i][j] as Array).length;
	// 										for (var q:int=0; q < tLen2; q++)
	// 										{
	// 											tmpByteArray2.writeByte(result[i][j][q]);
	// 										}
	// 										tmpByteArray2.position=0;
	// 										t.push(tmpByteArray2.readUTFBytes(tLen2));
	// 									}
	// 									else
	// 									{
	// 										t.push(result[i][j].toString());
	// 									}
	// 								}
	// 							}
	// 						}
	// 						else if (subType == 'bool' || subType == 'boolean')
	// 						{
	// 							for (j=0; j < result[i].length; j++)
	// 							{
	// 								t.push((result[i][j] == "true") ? true : false);
	// 							}
	// 						}
	// 						else if (subType == 'tuple')
	// 						{
	// 							for (j=0; j < result[i].length; j++)
	// 							{
	// 								if (result[i][j][1] is Array)
	// 								{
	// 									var byte:ByteArray = new ByteArray();
	// 									var arr:Array = result[i][j][1];
	// 									for( var m:int=0; m<arr.length; m++ )
	// 									{
	// 										byte.writeByte( arr[m] );
	// 									}
	// 									byte.position = 0;
	// 									t[result[i][j][0]] = byte.readUTFBytes(byte.length);
	// 								}else{
	// 									t[result[i][j][0]] = result[i][j][1];
	// 								}
	// 							}
	// 						}
	// 						else
	// 						{
	// 							if (result[i] != 'undefined')
	// 							{
	// 								for (j=0; j < result[i].length; j++)
	// 								{
	// 									t.push(unpack(result[i][j]));
	// 								}
	// 							}
	// 						}
	// 					}
	// 					vo[attrs[i - 1][0]]=t;
	// 				}
	// 				else
	// 				{
	// 					if (result[i] == 'undefined')
	// 					{
	// 						vo[attrs[i - 1][0]]=null;
	// 					}
	// 					else
	// 					{
	// 						vo[attrs[i - 1][0]]=unpack(result[i]);
	// 					}
	// 				}
	// 			}
	// 			//			var timepast:int = getTimer()-ttttt;
	// 			//			if(timepast>0)
	// 			//			{
	// 			return vo;
	// 		}
				
	// 	public static Class getDefine(string type)
	// 		{
	// 			var d:Dictionary=MessageDefines.defines;
	// 			var clzz:Class;
	// 			try
	// 			{
	// 				clzz=getDefinitionByName(d[type]) as Class;
	// 			}
	// 			catch (e:Error)
	// 			{
	// 				throw new Error("找不到类型:" + type, type);
	// 			}
	// 			return clzz;
	// 		}
				
	// 	public void decode(ByteArray input)
	// 		{
	// 			input.readByte(); // Erlang ETF Distribution Header 131
	// 			var result:Array=new Array;
	// 			result=decodeErlangTerm(input);
	// 			unpack(result);
	// 		}
				
	// 	protected  decodeErlangTerm(ByteArray input)
	// 		{
	// 			var flag:int=input.readUnsignedByte();
	// 			var i:int;
	// 			var len:int;
	// 			switch (flag)
	// 			{
	// 			case 97: // small int
	// 				return input.readUnsignedByte();
	// 			case 98: // int
	// 				return input.readInt();
	// 			case 99: // string format float
	// 			var tmp:ByteArray=new ByteArray;
	// 				input.readBytes(tmp, 0, 31);
	// 				//tmp.readBytes(input, input.position, 31);
	// 				// 暂时直接用字符串展示
	// 				return Number(tmp.toString());
	// 			case 115:
	// 				len=input.readUnsignedByte();
	// 				var t:ByteArray=new ByteArray;
	// 				t.readBytes(input, input.position, len);
	// 				return t.toString();
	// 			case 109:
	// 			var len2:int=input.readUnsignedInt();
	// 				return input.readUTFBytes(len2);
	// 			case 107:
	// 				len=input.readUnsignedShort();
	// 				var tmpArray4:Array=new Array;
	// 				for (i=0; i < len; i++)
	// 				{
	// 					tmpArray4.push(input.readUnsignedByte());
	// 				}
	// 				return tmpArray4;
	// 			case 108:
	// 				len=input.readUnsignedInt();
	// 				var tmpArray3:Array=new Array;
	// 				for (i=0; i < len; i++)
	// 				{
	// 					tmpArray3.push(this.decodeErlangTerm(input));
	// 				}
	// 				input.readByte();
	// 				return tmpArray3;
	// 			case 106: // nil 
	// 				return new Array;
	// 			case 104: // small tuple
	// 				len=input.readUnsignedByte();
	// 				var tmpArray:Array=new Array;
	// 				for (i=0; i < len; i++)
	// 				{
	// 					tmpArray.push(this.decodeErlangTerm(input));
	// 				}
	// 				return tmpArray;
	// 			case 105: // large tuple
	// 				len=input.readUnsignedInt();
	// 				var tmpArray2:Array=new Array;
	// 				for (i=0; i < len; i++)
	// 				{
	// 					tmpArray2.push(this.decodeErlangTerm(input));
	// 				}
	// 				return tmpArray2;
	// 			case 100: // atom 当做字符串对待
	// 				return input.readUTF();
	// 			case 110: // small bignums
	// 				len=input.readUnsignedByte();
	// 				var f:int=input.readUnsignedByte(); // 0 整数 1 负数
	// 				var r:Number=0;
	// 				var temp2:int=0;
	// 				for (i=0; i < len; i++)
	// 				{
	// 					temp2=input.readUnsignedByte();
	// 					r+=temp2 * Math.pow(256, i);
	// 				}
	// 				if (f == 1)
	// 				{
	// 					r=-r;
	// 				}
	// 				return r;
	// 			case 111: // large bignums
	// 				len=input.readUnsignedByte();
	// 				var f2:int=input.readUnsignedByte(); // 0 整数 1 负数
	// 				var r2:Number=0;
	// 				var temp4:int=0;
	// 				for (i=0; i < len; i++)
	// 				{
	// 					temp4=input.readUnsignedByte();
	// 					r2+=temp4 * Math.pow(256, i);
	// 				}
	// 				if (f2 == 1)
	// 				{
	// 					r2=-r2;
	// 				}
	// 				return r2;
	// 			default: // 其他类型统统不支持！！！
	// 				throw new Error("未知类型:", flag);
	// 				return null;
	// 			}
	// 			return null;
	// 		}
				
	}
	
	// class Statistics
	// {
	// 	public var name:String;
	// 	public var num:int = 0;
	// 	public var time:int = 0;
	// }
	// }
}

