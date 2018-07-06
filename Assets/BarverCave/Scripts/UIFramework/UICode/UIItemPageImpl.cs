using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ns_predefine;
using TinyTeam.UI;

public class UIItemPageImpl : Singleton<UIItemPageImpl> {
	public Text _Name;
	public Text _Desc;
	public Text _Prop;
	public Text _Cnt;
	public Image _Frm;
	public Image _Icon;
	public Button _Btn0;
	public Button _Btn1;
	public Button _Btn2;

	public ObjItem _Target;

	private UIItemPageImpl(){
		
	}

	public void setinfo(ObjItem _item){
		_Target = _item;
		_Name.text = string.Format("{0}{1}</color>",PreHeader.COLORStr[(ModelEnum)_Target._Items._NQuality],_Target._Items._SName);
		_Desc.text = _Target._Items._SInfo;
		_Cnt.text = string.Format ("强化等级 {0}\n持有数量 {1}",_Target._Items._NLv,_Target._Items._NCnt);
		//_propstring = PreHeader.COLORStr [_Target._Items._NQuality];
		string _propstring = "";
		for(int i = 0 ; i < PreHeader.PROPMAX ; ++ i)
			if(_Target._Items._FValue[i] > 0.2)
				_propstring = string.Format("{0}{1} {2}\n",_propstring,PreHeader.PROPTStr[_Target._Items._ValueType[i]],_Target._Items._FValue[i]);
		//_propstring = string.Format("{0}</color>",_propstring);

		_Prop.text = _propstring;

		_Icon.sprite = GameResources.loadSprite (_Target._Items._NModel.ToString ());
		_Frm.sprite = GameResources.loadSprite ("ItemBG_"+_Target._Items._NQuality);
	}

	public void init(){
		_Btn0.onClick.AddListener (()=>{
			GameResources.Instance()._GameMgr._AIPlayer.onitemclick(_Target);
			TTUIPage.ClosePage<UIItemPage>();
		});
		_Btn1.onClick.AddListener (()=>{
			TTUIPage.ClosePage<UIItemPage>();
		});
		_Btn2.onClick.AddListener (()=>{
			TTUIPage.ClosePage<UIItemPage>();
		});
	}
}
