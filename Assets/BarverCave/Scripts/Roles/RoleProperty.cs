using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleProperty {
	//逻辑
	public bool BAlive{get{return NHp > 0;}set{}}		//是否活着
	public bool BMovable{get;set;}		//是否可以移动
	public bool BControl{get;set;}		//是否是否可以接受控制

	//属性
	public int NId{get;set;}			//编号
	public int NLv{get;set;}			//等级
	public int NHp{get;set;}			//生命值
	public int NMaxHp{get;set;}			//生命值上限
	public int NMp{get;set;}			//生命值（能量值）
	public int NMaxMp{get;set;}			//魔法值（能量值）上限
	public int NDps{get;set;}			//输出值
	public int NDef{get;set;}			//防御值
	public int NSpd{get;set;}			//移动速度
	public int NAtkSpd{get;set;}
	public int NExp{get;set;}			//经验值
	public string SName{get;set;}		//名字

	public float _AtkRange;

	public RoleProperty()
	{
		SName = "no name";
		BControl = BMovable = BAlive = true;
		NLv = NId = NDps = NDef = NSpd = NExp = 0;
		NAtkSpd = 1;
		NSpd = 1;
		NMaxHp = NMaxMp = NMp = NHp = 100;
		_AtkRange = 2;
	}

	public float BloodAmount(){
		return (float)NHp / (float)NMaxHp;
	}
}
