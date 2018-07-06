using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TinyTeam.UI;
using ns_predefine;

public class ObjItem : Button {
	public Items _Items{ get; set;}
	private Text _cnttxt = null;
	private Image _iconimg = null;
	private Image _frame = null;

	public ObjItem(){

	}

	public void Awake(){
		_frame = this.GetComponent<Image> ();
		foreach (Transform _tr in this.transform) {
			if (_cnttxt == null)
				_cnttxt = _tr.GetComponent<Text> ();
			if (_iconimg == null)
				_iconimg = _tr.GetComponent<Image> ();
		}
		this.onClick.AddListener (()=>{			
			if(_Items != null && (_Items._NModel >= (int)ModelEnum.Food && _Items._NModel <= (int)ModelEnum.FoodEnd) || 
				(_Items._NModel >= (int)ModelEnum.Equip && _Items._NModel <= (int)ModelEnum.EquipEnd)){

				TTUIPage.ShowPage<UIItemPage>();
				UIItemPageImpl.Instance().setinfo(this);
			}else if(_Items._NModel >= (int)ModelEnum.ActionAttack && _Items._NModel <= (int)ModelEnum.AttackEnd){
				//GameResources.Instance()._GameMgr._AIPlayer.onattackenter(this);
			}
			else{
				GameResources.Instance()._GameMgr._AIPlayer.onitemclick(this);
			}			
		});
	}
	public void gain(int n){
		_Items._NCnt += n;
		_cnttxt.text = string.Format ("{0:D2}",_Items._NCnt);
	}
	public bool consume(int n){
		_Items._NCnt -= n;
		if (_Items._NCnt == 0)
			return false;
		_cnttxt.text = string.Format ("{0:D2}",_Items._NCnt);
		return true;
	}

	public void setcnt(int ncnt){
		_Items._NCnt = ncnt;
		_cnttxt.text = string.Format ("{0:D2}",_Items._NCnt);
	}

	public void init(Items _item){
		if (_Items == null)
			_Items = new Items ();
		_Items.Clone(_item);
		flash ();
	}

	public void flash(){
		_cnttxt.text = string.Format ("{0:D2}",_Items._NCnt);
		seticon (GameResources.loadSprite (_Items._NModel.ToString ()), 
			(_Items._NQuality == (int)ModelEnum._UnKnown) ? null : GameResources.loadSprite ("ItemBG_"+_Items._NQuality));
	}

	public void seticon(Sprite _icon,Sprite _fra = null){
		if (_icon != null)
			_iconimg.sprite = _icon;
		else
			_iconimg.gameObject.SetActive (false);
		
		if (_fra != null)
			_frame.sprite = _fra;
		else
			_frame.enabled = false;
		
	}
	public void setsize(Vector2 _v2,int id = 0){
		RectTransform _rectran = this.gameObject.GetComponent<RectTransform> ();
		_rectran.localScale = Vector3.one;
		_rectran.localPosition = Vector3.zero;
		_rectran.localRotation = Quaternion.identity;
		_rectran.sizeDelta = _v2;
		//_frame.rectTransform.sizeDelta = new Vector2 (_v2.x - 8 , _v2.y - 8);
		_iconimg.rectTransform.sizeDelta = new Vector2 (_v2.x , _v2.y);
	}
}