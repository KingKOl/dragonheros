using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFirm : MonoBehaviour {

	public float radian = 0; // 弧度    
	public float perRadian = 0.03f; // 每次变化的弧度   上下浮动  
	public float radius = 0.1f; // 半径    
	// Use this for initialization    
	void Start()  
	{  
	}  

	// Update is called once per frame    
	void Update()  
	{  
		radian += perRadian; // 弧度每次加0.03    
		float dy = Mathf.Sin(radian) * radius; // dy定义的是针对y轴的变量，也可以使用sin，找到一个适合的值就可以    
		transform.RotateAround (Vector3.zero,Vector3.up,80*Time.deltaTime);
		transform.position = new Vector3(transform.position.x, dy, transform.position.z);
	}    
}

