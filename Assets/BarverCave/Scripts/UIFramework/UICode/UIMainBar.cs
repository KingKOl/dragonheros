using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;
using System;
using ns_predefine;

public class UIMainBar : TTUIPage {
	private Button _MainPage;
	public UIMainBar() : base(UIType.Fixed, UIMode.DoNothing, UICollider.None)
	{
		uiPath = "UIFrame/UIMainBar";
	}

	public override void Awake(GameObject go)
	{
		_MainPage = this.transform.GetComponent<Button> ();
		_MainPage.onClick.AddListener (()=>{
			ShowPage<UIMainFramePage>() ;
			GameResources.Instance()._ObjJoyStick.SetActive(false);
			ClosePage<UIMainBar>();
		});
	}
}
