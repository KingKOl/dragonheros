using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	
	private AIEnemy[] _ai;
	// Use this for initialization
	void Start () {
		_ai = new AIEnemy[20];
		for (int i = 0; i < _ai.Length; ++i) {
			Debug.Log (i);
			_ai[i] = new AIEnemy ();
			_ai[i].generate ((ns_predefine.ModelEnum)(2300+10 * (i % 11)));	
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < _ai.Length; ++i) {
			_ai[i].update ();
		}
	}
}
