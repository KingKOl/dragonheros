using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;

public class UIMainPage : TTUIPage {

	public UIMainPage() : base(UIType.Fixed, UIMode.HideOther, UICollider.None)
	{
		uiPath = "UIFrame/UIMain";
	}

	public override void Awake(GameObject go)
	{
		/*
		this.transform.Find("btn_skill").GetComponent<Button>().onClick.AddListener(() =>
			{
				ShowPage<UISkillPage>();
			});

		this.transform.Find("btn_battle").GetComponent<Button>().onClick.AddListener(() =>
			{
				ShowPage<UIBattle>();
			});
			*/
	}
}
