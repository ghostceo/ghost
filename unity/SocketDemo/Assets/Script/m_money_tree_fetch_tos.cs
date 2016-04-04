
namespace LSocket.Common
{
	using UnityEngine;
	using System.Collections;
	using LSocket.Msg;

	public class m_money_tree_fetch_tos : Message {

		public int id = 0;

		public m_money_tree_fetch_tos() {
			id = 0;
		}

		public m_money_tree_fetch_tos(int id) {
			this.id=id;
		}

		public override string  getMethodName() {
			return "money_tree_fetch";
		}
		public override string getClassName() {
			return "m_money_tree_fetch_tos";
		}
	 	public override string[][] getAttributes() {
	 		string[][] attrs = new string[1][];
	 		attrs[0][0] = "id";
	 		attrs[0][1] = "int32";
	 		Debug.Log("as");
			return attrs;
		}
		public override  int getIntValue(string s) {
			if (s == "id"){
				return id;
			}
			else {
				return 0;
			}
		}
		public override  long getLongValue(string s){
			return 0;
		}
		public override string getStringValue(string s){
			return "error";
		}
	}
}
