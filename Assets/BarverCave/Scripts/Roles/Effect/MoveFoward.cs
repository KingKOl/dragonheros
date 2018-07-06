using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour {
	public Vector3 _rotate = Vector3.zero;
	public Vector3 _position = Vector3.zero;
	public float _speed = 1.1f;
	private bool _start = false;

	public void move(Vector3 _pos , Vector3 _rte ,float _s = 1.1f){
		_rotate = _rte;
		_position = _pos;
		this.transform.localPosition = _position;
		this.transform.localEulerAngles = _rotate;
		_speed = _s;
		_start = true;
		this.transform.SetParent (null);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_start)
			this.transform.Translate (Vector3.forward*_speed*Time.deltaTime,Space.Self);
	}
}
