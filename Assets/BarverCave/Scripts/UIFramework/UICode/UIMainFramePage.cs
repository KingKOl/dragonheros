using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using UnityEngine.UI;

public class UIMainFramePage : TTUIPage {
	public UIMainFramePage() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
	{
		uiPath = "UIFrame/UIMainFrame";
	}

	public override void Awake(GameObject go)
	{
		ShowPage<UIItemPage>();
		ClosePage<UIItemPage>();
		Button _close = this.transform.GetComponentInChildren<Button> ();
		_close.onClick.AddListener (()=>{			
			ClosePage<UIMainFramePage>();		
			ShowPage<UIMainBar>();
			ClosePage<UIItemPage>();
			GameResources.Instance()._ObjJoyStick.SetActive(true);
		});

		GameResources.Instance()._InventoryPanel = this.transform.Find ("inventory/_right_panel/Scroll View/Viewport/PanelItems");
		GameResources.Instance()._EquipmentPanel = this.transform.Find ("inventory/_left_panel/equiped");
		for (int i = 0; i < 10; ++i)
			GameResources.Instance()._EquipSolt.Add (this.transform.Find ("inventory/_left_panel/equiped/s_" + i));
	}
}
