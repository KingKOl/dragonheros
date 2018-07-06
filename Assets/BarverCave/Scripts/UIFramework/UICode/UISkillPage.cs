using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ns_predefine;


public class UISkillPage : Singleton<UISkillPage>  {
	private Image _SkillWin;
	private Vector2 _ShowPos;
	private Vector2 _HidePos;

	private UISkillPage()
	{
		_ShowPos = new Vector2 (-70,0);
		_HidePos = new Vector2 (-70,9999);

		GameObject _page = GameObject.Instantiate(GameResources.loadGameObject(4)) as GameObject;
		_SkillWin = _page.GetComponent<Image> ();
		_SkillWin.rectTransform.SetParent (GameResources.Instance()._ObjUIPanel.transform);
		_SkillWin.rectTransform.localScale = Vector3.one;
		_SkillWin.rectTransform.anchoredPosition = _ShowPos;

		GameResources.Instance ()._SkillPanel = _SkillWin.gameObject.transform;
	}

	public void show(bool _b = true){
		_SkillWin.rectTransform.anchoredPosition = _b ? _ShowPos : _HidePos;
	}
}
