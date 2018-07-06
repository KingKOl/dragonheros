using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;
using TinyTeam.UI;

public class UIPageMgr : Singleton<UIPageMgr>  {
	private bool _battleshow = false;
	private UIPageMgr(){
	}

	public void initpages(){
		TTUIPage.ShowPage<UIMainBar> ();

		TTUIPage.ShowPage<UIMainFramePage> ();
		TTUIPage.ClosePage<UIMainFramePage> ();

		UISkillPage.Instance ().show (false);
	}

	public void showbattleui(bool _b){
		if (_b == _battleshow)
			return;
		if (_b) {
			UISkillPage.Instance ().show (true);
			TTUIPage.ClosePage<UIMainBar> ();
		} else {
			UISkillPage.Instance ().show (false);
			TTUIPage.ShowPage<UIMainBar> ();
		}
		_battleshow = _b;
	}
}
