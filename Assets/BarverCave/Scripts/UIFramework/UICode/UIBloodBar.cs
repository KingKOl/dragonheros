using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBloodBar {
	private Image _ObjBar;

	private Image _Blood;
	private Image _Blue;
	private Text _Level;
	private Text _Name;

	private bool _active = true;

	public float BLOOD{get{ return _Blood.fillAmount; }set{ _Blood.fillAmount = value;}}
	public float BLUE{get{ return _Blue.fillAmount; }set{ _Blue.fillAmount = value;}}
	public string NAME{get{ return _Name.text; }set{ _Name.text = value;}}
	public string LEVEL{get{ return _Level.text; }set{ _Level.text = value;}}

	public UIBloodBar(){
		init ();
	}

	// Use this for initialization
	public void init () {

		GameObject _Obj = GameObject.Instantiate(GameResources.loadGameObject (1)) as GameObject ;
		_ObjBar = _Obj.GetComponent<Image> ();
		_ObjBar.rectTransform.SetParent (GameResources.Instance ()._ObjUIPanel.transform);
		_ObjBar.rectTransform.localScale = Vector3.one;
		_ObjBar.rectTransform.anchoredPosition = new Vector2(0,-40);

		foreach (Transform _tr in _ObjBar.transform) {
			if (_tr.name == "Blood") {
				_Blood = _tr.GetComponent<Image> ();
			}
			else if (_tr.name == "Blue") {
				_Blue = _tr.GetComponent<Image> ();
			}
			else if (_tr.name == "Name") {
				_Name = _tr.GetComponent<Text> ();
			}
			else if (_tr.name == "Lv") {
				_Level = _tr.GetComponent<Text> ();
			}
		}

		show (false);
	}

	public void show(bool _b){
		if (_b == _active)
			return;
		_ObjBar.gameObject.SetActive (_b);
		_active = _b;
	}
}
