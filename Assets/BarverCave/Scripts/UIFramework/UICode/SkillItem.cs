using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillItem : Button {
	public Items _Items{ get; set;}

	private Image _Mask;
	private Image _Icon;
	private Text _Cost;

	private bool _Cooling;
	private float _cooltimer;

	protected void Awake(){
		_Cooling = false;
		_Icon = this.transform.GetComponent<Image>();
		_Mask = this.transform.Find ("Mask").GetComponent<Image>();
		_Cost = this.transform.Find ("Cost").GetComponent<Text>();

		this.onClick.AddListener (()=>{
			if(_Cooling)
			{
				Debug.Log("技能还在冷却中");
				return;
			}

			if(GameResources.Instance()._GameMgr._AIPlayer._Atking || GameResources.Instance()._GameMgr._AIPlayer._Mving)
			{
				Debug.Log("请等待其它技能施放完毕");
				return;
			}

			GameResources.Instance()._GameMgr._AIPlayer.OnSkillPressed(this);
			_Cooling = true;
			_cooltimer = 0;
			StartCoroutine (cooldown());
		});
	}

	/*
	void Update(){
		if (_Cooling) {
			if (_cooltimer > _Items._NCnt)
				_Cooling = false;
			else {
				_cooltimer += Time.deltaTime;
				_Mask.fillAmount = 1.0f - _cooltimer / _Items._NCnt;
			}
		}
	}
	*/

	IEnumerator cooldown(){
		while (_Cooling) {
			if (_cooltimer > _Items._NCnt)
				_Cooling = false;
			else {
				yield return 0;
				_cooltimer += Time.deltaTime;
				_Mask.fillAmount = 1.0f - _cooltimer / _Items._NCnt;
			}
		}
		yield return null;
	}

	public void reset(){
		_Cooling = false;
		_cooltimer = 0;
		_Mask.fillAmount = 0;
	}

	public void init(Items _item){
		if (_Items == null)
			_Items = new Items ();
		_Items.Clone(_item);

		flash ();
	}

	public void setsize(Vector2 _v2){
		RectTransform _rectran = this.gameObject.GetComponent<RectTransform> ();
		_rectran.localScale = Vector3.one;
		_rectran.localPosition = Vector3.zero;
		_rectran.localRotation = Quaternion.identity;
		_rectran.sizeDelta = _v2;
		_Icon.rectTransform.sizeDelta = _rectran.sizeDelta;//new Vector2 (_v2.x , _v2.y);
		_Mask.rectTransform.sizeDelta = _rectran.sizeDelta;//new Vector2 (_v2.x , _v2.y);
	}

	public void flash(){
		_Cost.text = string.Format ("{0:D2}",_Items._NCnt);
		if (_Icon != null)
			_Icon.sprite = GameResources.loadSprite (_Items._NModel.ToString ());
		else
			_Icon.gameObject.SetActive (false);

		reset ();
	}
}
