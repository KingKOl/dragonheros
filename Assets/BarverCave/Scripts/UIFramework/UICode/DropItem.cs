using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItem : Button {
	//private Image _Bg;
	private Image _Frame;
	private Image _Icon;
	private Text _Name;
	private Text _Cnt;
	private Items _Data;
	public DropItem(){

	}

	public void Init(Items _data){
		_Data = new Items ();
		_Data.Clone (_data);

		seticon (GameResources.loadSprite (_Data._NModel.ToString ()),GameResources.loadSprite ("ItemBG_"+_Data._NQuality));
		_Name.text = _Data._SName;
		_Cnt.text = string.Format ("数量: {0}",_Data._NCnt);
	}

	public void Awake(){
		//_Bg = this.transform.GetComponent<Image> ();
		_Frame = this.transform.Find ("Frame").GetComponent<Image>();
		_Icon = this.transform.Find ("Icon").GetComponent<Image>();
		_Name = this.transform.Find ("Name").GetComponent<Text>();
		_Cnt = this.transform.Find ("Cnt").GetComponent<Text>();

		this.onClick.AddListener (()=>{

			gamedbmgr.Instance().add2inv(_Data);

			Destroy(this.gameObject);
		});
	}

	public void seticon(Sprite _icon,Sprite _fra = null){
		if (_icon != null)
			_Icon.sprite = _icon;
		else
			_Icon.gameObject.SetActive (false);

		if (_fra != null)
			_Frame.sprite = _fra;
		else
			_Frame.enabled = false;

	}
}
