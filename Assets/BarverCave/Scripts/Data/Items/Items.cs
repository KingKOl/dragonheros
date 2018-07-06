using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;

public class Items {
	public string _SName;
	public string _SInfo;
	public int _NId;
	public int _NModel;
	public int[] _ValueType;
	public double[] _FValue;
	public int _NLv;
	public int _NQuality;
	public int _NForge;
	public int _NCnt;
	public int _NPrice;
	public int _NStat;
	public int _NType;

	public int _PartId{get{ return (int)Mathf.Floor (_NModel / 100) - 10; } }
	public ModelEnum _ModelType{ get { return (ModelEnum)(Mathf.Floor(_NModel / 100) * 100); } }

	public override bool Equals (object obj)
	{
		if (obj == null)
			return false;
		if (GetType () != obj.GetType ())
			return false;

		Items _ptr = (Items)obj;
		if (this._NType == _ptr._NType && 
			this._SName == _ptr._SName && 
			this._NId == _ptr._NId &&
			this._NModel == _ptr._NModel && 
			this._NQuality == _ptr._NQuality && 
			this._NForge == _ptr._NForge && 
			this._NStat == _ptr._NStat)
			return true;
		return false;
	}

	public static bool operator ==(Items l , Items r){
		return Object.Equals (l,r);
	}

	public static bool operator !=(Items l , Items r){
		return !Object.Equals (l,r);
	}

	public void Clone(Items _other){
		_NType = _other._NType;
		_SName = _other._SName;
		_SInfo = _other._SInfo;
		_NId = _other._NId;
		_NModel = _other._NModel;
		_NQuality = _other._NQuality;
		_NForge = _other._NForge;
		_NCnt = _other._NCnt;
		_NLv = _other._NLv;
		_NPrice = _other._NPrice;
		_NStat = _other._NStat;
		for (int i = 0; i < PreHeader.PROPMAX; ++i) {
			_ValueType [i] = _other._ValueType [i];
			_FValue[i] = _other._FValue[i];
		}
	}

	public Items(){
		_SName = "玄天小黄瓜";
		_SInfo = "玄灵之宝,斩灵灭仙\n凌霄不空,誓不升天";
		_NQuality = (int)ModelEnum._UnKnown;
		_ValueType = new int[PreHeader.PROPMAX];
		_FValue = new double[PreHeader.PROPMAX];
		_NModel = 100;
		_NStat = -1;
		for (int i = 0; i < PreHeader.PROPMAX; ++i) {
			_ValueType [i] = Random.Range (0,PreHeader.PROPMAX);
			_FValue[i] = Random.Range (0,PreHeader.PROPMAX);;
		}
	}
}
