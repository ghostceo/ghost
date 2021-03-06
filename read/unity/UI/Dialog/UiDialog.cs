using UnityEngine;
using System.Collections;
using MVC.entrance.gate;

public class UiDialog : MonoBehaviour
{

	public string fontColor;
	UILabel lblMessage;                 //显示的文字
	eDialogSureType sureType;
	
	void Awake ()
	{
		lblMessage = transform.FindChild ("lbl_message").GetComponent<UILabel> ();
	}
	
 
//	//显示文字
//	public void Show (eDialogSureType type, string msg)
//	{
//		sureType = type;
//		gameObject.SetActive (true);
//		SetMessage (msg);
//		
//	}

	public void SetMessage (string msg)
	{
		lblMessage.text = "[" + fontColor + "]" + msg + "[-]";
	}

	//关闭窗口
	public void Close ()
	{
		UIManager.Instance.closeWaitting ();
		string uiName = null;
		if (SceneManager.Instance.currentScene == SCENE_POS.IN_CITY) {
			uiName = UiNameConst.ui_dialog;
		} else {
			uiName = UiNameConst.ui_dialog_fight;
		}
		if (sureType == eDialogSureType.eNone) {
			UIManager.Instance.closeWindow (uiName);
		} else {
			UIManager.Instance.closeWindow (uiName);
		}
	}
		
		
	//执行关闭弹出窗口的事件
	public void OnDialogCancel ()
	{
		Gate.instance.sendNotification (MsgConstant.MSG_ENABLE_MODEL_CAMERA);
		EventDispatcher.GetInstance ().OnDialogCancel (sureType);	
	}
		
		
		
	//执行确认按钮 
	public void Sure ()
	{
		EventDispatcher.GetInstance ().OnDialogSure (sureType);
		Gate.instance.sendNotification (MsgConstant.MSG_SURE_DIALOG, sureType);
		if (sureType != eDialogSureType.eApplicationExit) {
			Close ();
			Gate.instance.sendNotification (MsgConstant.MSG_ENABLE_MODEL_CAMERA);
		}
		if (sureType == eDialogSureType.eExitFight) {
            MessageManager.Instance.sendMessageReturnCity();
			UIManager.Instance.showWaitting (true); //回主城强制弹出对话框
			Global.m_bAutoFightSaved = Global.m_bAutoFight;
			Global.m_bAutoFight = false;
		}
	}
		
	public void OnCancle ()
	{
		transform.parent.parent.GetComponent<UiDialog> ().OnDialogCancel ();
		transform.parent.parent.GetComponent<UiDialog> ().Close ();
	}
		
	public void OnSure ()
	{
		transform.parent.parent.GetComponent<UiDialog> ().Sure ();
	}
}
