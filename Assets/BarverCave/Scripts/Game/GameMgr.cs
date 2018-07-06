using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyTeam.UI;
using ns_predefine;

public class GameMgr : MonoBehaviour {
	public AIPlayer _AIPlayer = new AIPlayer();
	public GameMapMgr _MapMgr = new GameMapMgr();
	void Awake(){
		
	}
	// Use this for initialization
	void Start () {
		gamedbmgr.Instance ().open ();

		UIPageMgr.Instance().initpages ();

		_MapMgr.init ();

		_AIPlayer.generate ();
	}
	
	// Update is called once per frame
	void Update () {
		_AIPlayer.update ();
	}

	void OnDestory(){
		gamedbmgr.Instance ().close ();
	}


}
