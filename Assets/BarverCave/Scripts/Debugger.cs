using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using ns_predefine;
using TinyTeam.UI;

public class Debugger : MonoBehaviour {
	public Button closedb;
	public Button opendrop;
	public Button skill;
	public Transform _swordfirm;
	int count = 0;
	// Use this for initialization
	void Start () {
		if(closedb != null)
			closedb.onClick.AddListener (()=>{
				gamedbmgr.Instance().close();
			});
		if(opendrop != null)
			opendrop.onClick.AddListener (()=>{
				//TTUIPage.ShowPage<UIDropPage>();
			});
		if(skill != null)
			skill.onClick.AddListener (()=>{
				if(count++ % 2 == 0){
					
				}
				else{
					
				}
			});
    }

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			if(_swordfirm != null)
				((Transform)GameObject.Instantiate (_swordfirm)).gameObject.AddComponent<MoveFoward>();
		}
	}
}
