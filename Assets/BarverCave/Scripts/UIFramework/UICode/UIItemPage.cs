using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using ns_predefine;
using System.Text;

public class UIItemPage : TTUIPage {
	
	public UIItemPage() : base(UIType.PopUp, UIMode.DoNothing, UICollider.None)
	{
		uiPath = "UIFrame/UIItemProp";
	}

	public override void Awake(GameObject go)
	{
		UIItemPageImpl.Instance()._Name = this.transform.Find ("Name").GetComponent<Text>();
		UIItemPageImpl.Instance()._Desc = this.transform.Find ("Desc").GetComponent<Text>();
		UIItemPageImpl.Instance()._Prop = this.transform.Find ("Prop").GetComponent<Text>();
		UIItemPageImpl.Instance()._Cnt = this.transform.Find ("Cnt").GetComponent<Text>();
		UIItemPageImpl.Instance()._Frm = this.transform.Find ("frm").GetComponent<Image>();
		UIItemPageImpl.Instance()._Icon = this.transform.Find ("icon").GetComponent<Image>();

		UIItemPageImpl.Instance ()._Btn2 = this.transform.Find ("btn2").GetComponent<Button> ();
		UIItemPageImpl.Instance ()._Btn1 = this.transform.Find ("btn1").GetComponent<Button> ();
		UIItemPageImpl.Instance ()._Btn0 = this.transform.Find ("btn0").GetComponent<Button> ();
			
		UIItemPageImpl.Instance ().init ();
	}		
}
