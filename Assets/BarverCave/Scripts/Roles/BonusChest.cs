using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;

public class BonusChest {
	private GameObject _ObjChest;
	private UIDropPage _DropPage;
	public BonusChest(){
		_ObjChest = GameObject.Instantiate (GameResources.loadGameObject(2)) as GameObject;
		_ObjChest.SetActive (false);
		_DropPage = new UIDropPage ();
	}
	// Use this for initialization
	public void show (Vector3 _loc) {
		_ObjChest.transform.position = _loc;
		_ObjChest.SetActive (true);
	}

	public void update(){
		if (Vector3.Distance (_ObjChest.transform.position, GameResources.Instance ()._ObjPlayer.transform.position) < 3) {
			if(_DropPage._autoshown)
				_DropPage.reloaddrop ();
		} else {
			_DropPage._autoshown = true;
			_DropPage.hide ();
		}
	}
}
