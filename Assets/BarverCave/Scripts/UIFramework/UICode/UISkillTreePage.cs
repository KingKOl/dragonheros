using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;

public class UISkillTreePage : TTUIPage {

	public UISkillTreePage() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
	{
		uiPath = "UIFrame/UISkillTree";
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
