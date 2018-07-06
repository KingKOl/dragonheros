using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;

public class EMRock : RoleAnimController {

	public override void loadanimation (ns_predefine.ModelEnum _type)
	{
		_WPType = _type;

		Dictionary<ModelEnum,string[]> _anim = new Dictionary<ModelEnum, string[]> (){ 
			{ModelEnum.Idle,new string[]{"Idle","Idle"}},
			{ModelEnum.Run,new string[]{"FlyFoward","Run"}},
			{ModelEnum.Die,new string[]{"Die","Die"}},
			{ModelEnum.Atk_Normal_0,new string[]{"RightPunchAttack","Right Punch Attack"}},
			{ModelEnum.Atk_Normal_1,new string[]{"LeftPunchAttack","Left Punch Attack"}},
			{ModelEnum.Atk_Skill_0,new string[]{"ShockwaveAttack","Shockwave Attack"}},
			{ModelEnum.Atk_Skill_1,new string[]{"SpinAttack-Spin","Spin Attack Loop"}},
		};
		_AnimParam = new Dictionary<ModelEnum, roleanim> ();

		foreach(ModelEnum _e in _anim.Keys){
			_AnimParam.Add (_e, new roleanim (_anim [_e] [0], _anim [_e] [1], _e));
		}

		_AnimEv = new Dictionary<int, roleanimev> (){
			//WP_THS
			{Animator.StringToHash(_AnimParam[ModelEnum.Atk_Normal_0]._animname),new roleanimev(_AnimParam[ModelEnum.Atk_Normal_0],0.02f,-1.0f,0.48f,0.94f)},
			{Animator.StringToHash(_AnimParam[ModelEnum.Atk_Normal_1]._animname),new roleanimev(_AnimParam[ModelEnum.Atk_Normal_1],0.02f,-1.0f,0.48f,0.94f)},
			{Animator.StringToHash(_AnimParam[ModelEnum.Atk_Skill_0]._animname),new roleanimev(_AnimParam[ModelEnum.Atk_Skill_0],0.0f,0.3f,0.4f,0.94f)},
			{Animator.StringToHash(_AnimParam[ModelEnum.Atk_Skill_1]._animname),new roleanimev(_AnimParam[ModelEnum.Atk_Skill_1],0.02f,-1.0f,0.58f,0.94f)},
		};
	}

	public override void doanim (ModelEnum _anim)
	{
		if (_AnimParam == null)
			return;
		
		if (_Preanim == ModelEnum.Atk_Skill_1) {
			if (_anim != ModelEnum.Atk_Skill_1)
				_Animator.SetTrigger (_AnimParam [_Preanim]._parahash);
			else
				return;
		}

		switch (_anim)
		{
		case ModelEnum.Lock:
			break;
		case ModelEnum.Idle:
		case ModelEnum.Run:
			_Animator.SetBool (_AnimParam[ModelEnum.Idle]._parahash,_anim == ModelEnum.Idle ? true : false);
			break;
		case ModelEnum.Atk_Normal_0:
		case ModelEnum.Atk_Normal_1:
		case ModelEnum.Atk_Skill_0:
		case ModelEnum.Atk_Skill_1:
		case ModelEnum.Die:
			_Animator.SetBool (_AnimParam[ModelEnum.Idle]._parahash,true);
			_Animator.SetTrigger(_AnimParam[_anim]._parahash);
			break;
		}

		_Preanim = _anim;
	}

	public override void reset ()
	{

	}
}
