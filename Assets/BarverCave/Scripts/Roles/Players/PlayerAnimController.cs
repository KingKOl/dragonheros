using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;

public class PlayerAnimController : RoleAnimController{
	private Dictionary<ModelEnum,Dictionary<ModelEnum,roleanim>> _preloaded;

	public override void loadanimation(ModelEnum _type)
	{
		clearrootanim ();
		_WPType = _type;
		switch(_WPType){
		case ModelEnum.WP_THS:
			_Animator.SetBool ("THS",true);
			break;
		case ModelEnum.WP_SHS:
		case ModelEnum.WP_BOW:
			_Animator.SetBool ("SHS",true);
			break;
		case ModelEnum.WP_STAFF:
			_Animator.SetBool ("STAFF",true);
			break;
		case ModelEnum.WP_SPEAR:
			_Animator.SetBool ("SPEAR",true);
			break;
		}
		_AnimParam = _preloaded[_WPType];
		doanim (ModelEnum.Idle);
	}

	public override void init_anim_all(){
		_AnimEv = new Dictionary<int, roleanimev> ();
		////THS
		Dictionary<ModelEnum,string[]> _thsanim = new Dictionary<ModelEnum, string[]> (){ 
			{ModelEnum.Idle,new string[]{"TH Sword Idle","IDLE"}},
			{ModelEnum.Run,new string[]{"TH Sword Run Without Root Motion","IDLE"}},
			{ModelEnum.Die,new string[]{"TH Sword Die","Die"}},
			{ModelEnum.Atk_Normal_0,new string[]{"TH Sword Melee Attack 01","THSMeleeAttack01"}},
			{ModelEnum.Atk_Normal_1,new string[]{"TH Sword Melee Attack 02","THSMeleeAttack02"}},
			{ModelEnum.Atk_Skill_0,new string[]{"TH Sword Cast Spell","THSCastSpell"}},
			{ModelEnum.Atk_Skill_1,new string[]{"TH Sword Cast Spell","THSCastSpell"}},
		};
		Dictionary<ModelEnum , roleanim> _ths = new Dictionary<ModelEnum, roleanim> ();

		foreach(ModelEnum _e in _thsanim.Keys){
			_ths.Add (_e, new roleanim (_thsanim [_e] [0], _thsanim [_e] [1], _e));
		}

		_AnimEv.Add (Animator.StringToHash(_ths[ModelEnum.Atk_Normal_0]._animname),new roleanimev(_ths[ModelEnum.Atk_Normal_0],0.02f,-1.0f,0.48f,0.94f));
		_AnimEv.Add (Animator.StringToHash(_ths[ModelEnum.Atk_Normal_1]._animname),new roleanimev(_ths[ModelEnum.Atk_Normal_1],0.02f,-1.0f,0.48f,0.94f));
		_AnimEv.Add (Animator.StringToHash(_ths[ModelEnum.Atk_Skill_1]._animname),new roleanimev(_ths[ModelEnum.Atk_Skill_1],0.0f,0.3f,0.4f,0.94f));

		////SHS
		Dictionary<ModelEnum,string[]> _shsanim = new Dictionary<ModelEnum, string[]> (){ 
			{ModelEnum.Idle,new string[]{"Idle","IDLE"}},
			{ModelEnum.Run,new string[]{"Run","IDLE"}},
			{ModelEnum.Die,new string[]{"Die","Die"}},
			{ModelEnum.Atk_Normal_0,new string[]{"Melee Right Attack 03","SHSMeleeRAttack03"}},
			{ModelEnum.Atk_Normal_1,new string[]{"Melee Right Attack 02","SHSMeleeRAttack02"}},
			{ModelEnum.Atk_Skill_0,new string[]{"Cast Spell","SHSCastSpell"}},
			{ModelEnum.Atk_Skill_1,new string[]{"Jump Right Attack 01","SHSJumpRAttack01"}},
		};
		Dictionary<ModelEnum , roleanim> _shs = new Dictionary<ModelEnum, roleanim> ();

		foreach(ModelEnum _e in _shsanim.Keys){
			_shs.Add (_e, new roleanim (_shsanim [_e] [0], _shsanim [_e] [1], _e));
		}

		_AnimEv.Add (Animator.StringToHash(_shs[ModelEnum.Atk_Normal_0]._animname),new roleanimev(_shs[ModelEnum.Atk_Normal_0],0.02f,-1.0f,0.48f,0.94f));
		_AnimEv.Add (Animator.StringToHash(_shs[ModelEnum.Atk_Normal_1]._animname),new roleanimev(_shs[ModelEnum.Atk_Normal_1],0.02f,-1.0f,0.48f,0.94f));
		_AnimEv.Add (Animator.StringToHash(_shs[ModelEnum.Atk_Skill_0]._animname),new roleanimev(_shs[ModelEnum.Atk_Skill_0],0.0f,0.3f,0.4f,0.94f));
		_AnimEv.Add (Animator.StringToHash(_shs[ModelEnum.Atk_Skill_1]._animname),new roleanimev(_shs[ModelEnum.Atk_Skill_1],0.0f,0.3f,0.4f,0.94f));

		////BOW
		Dictionary<ModelEnum,string[]> _bowanim = new Dictionary<ModelEnum, string[]> (){ 
			{ModelEnum.Idle,new string[]{"Idle","IDLE"}},
			{ModelEnum.Run,new string[]{"Run","IDLE"}},
			{ModelEnum.Die,new string[]{"Die","Die"}},
			{ModelEnum.Atk_Normal_0,new string[]{"LongBow Shoot Attack 01","BOWATTACK"}},
			{ModelEnum.Atk_Normal_1,new string[]{"LongBow Shoot Attack 01","BOWATTACK"}},
			{ModelEnum.Atk_Skill_0,new string[]{"LongBow Shoot Attack 01","BOWATTACK"}},
			{ModelEnum.Atk_Skill_1,new string[]{"LongBow Shoot Attack 01","BOWAIMATTACK"}},
		};
		Dictionary<ModelEnum , roleanim> _bow = new Dictionary<ModelEnum, roleanim> ();

		foreach(ModelEnum _e in _bowanim.Keys){
			_bow.Add (_e, new roleanim (_bowanim [_e] [0], _bowanim [_e] [1], _e));
		}

		_AnimEv.Add (Animator.StringToHash (_bow [ModelEnum.Atk_Normal_0]._animname), new roleanimev (_bow [ModelEnum.Atk_Normal_0], 0.02f, -1.0f, 0.48f, 0.94f));

		////STAFF
		Dictionary<ModelEnum,string[]> _staffanim = new Dictionary<ModelEnum, string[]> (){ 
			{ModelEnum.Idle,new string[]{"Fly Idle","IDLE"}},
			{ModelEnum.Run,new string[]{"Fly Forward","IDLE"}},
			{ModelEnum.Die,new string[]{"Fly Die","Die"}},
			{ModelEnum.Atk_Normal_0,new string[]{"Fly Right Punch Attack","STAFFRPunchAttack"}},
			{ModelEnum.Atk_Normal_1,new string[]{"Fly Melee Right Attack 02","STAFFMeleeRAttack02"}},
			{ModelEnum.Atk_Skill_0,new string[]{"Fly Cast Spell 01","STAFFCastSpell01"}},
			{ModelEnum.Atk_Skill_1,new string[]{"Fly Cast Spell 02","STAFFCastSpell02"}},
		};
		Dictionary<ModelEnum , roleanim> _staff = new Dictionary<ModelEnum, roleanim> ();

		foreach(ModelEnum _e in _staffanim.Keys){
			_staff.Add (_e, new roleanim (_staffanim [_e] [0], _staffanim [_e] [1], _e));
		}

		_AnimEv.Add (Animator.StringToHash(_staff[ModelEnum.Atk_Normal_0]._animname),new roleanimev(_staff[ModelEnum.Atk_Normal_0],0.02f,-1.0f,0.48f,0.94f));
		_AnimEv.Add (Animator.StringToHash(_staff[ModelEnum.Atk_Normal_1]._animname),new roleanimev(_staff[ModelEnum.Atk_Normal_1],0.02f,-1.0f,0.48f,0.94f));
		_AnimEv.Add (Animator.StringToHash(_staff[ModelEnum.Atk_Skill_0]._animname),new roleanimev(_staff[ModelEnum.Atk_Skill_0],0.0f,0.3f,0.4f,0.94f));
		_AnimEv.Add (Animator.StringToHash(_staff[ModelEnum.Atk_Skill_1]._animname),new roleanimev(_staff[ModelEnum.Atk_Skill_1],0.0f,0.3f,0.4f,0.94f));

		////SPEAR
		Dictionary<ModelEnum,string[]> _spearanim = new Dictionary<ModelEnum, string[]> (){ 
			{ModelEnum.Idle,new string[]{"Spear Idle","IDLE"}},
			{ModelEnum.Run,new string[]{"Spear Run","IDLE"}},
			{ModelEnum.Die,new string[]{"Spear Die","Die"}},
			{ModelEnum.Atk_Normal_0,new string[]{"Spear Melee Attack 01","SPEARMeleeAttack01"}},
			{ModelEnum.Atk_Normal_1,new string[]{"Spear Melee Attack 01","SPEARMeleeAttack01"}},
			{ModelEnum.Atk_Skill_0,new string[]{"Spear Melee Attack 02","SPEARMeleeAttack02"}},
			{ModelEnum.Atk_Skill_1,new string[]{"Spear Cast Spell 01","SPEARCastSpell01"}},
		};
		Dictionary<ModelEnum , roleanim> _spear = new Dictionary<ModelEnum, roleanim> ();

		foreach(ModelEnum _e in _spearanim.Keys){
			_spear.Add (_e, new roleanim (_spearanim [_e] [0], _spearanim [_e] [1], _e));
		}

		_AnimEv.Add (Animator.StringToHash(_spear[ModelEnum.Atk_Normal_0]._animname),new roleanimev(_spear[ModelEnum.Atk_Normal_0],0.02f,-1.0f,0.48f,0.94f));
		_AnimEv.Add (Animator.StringToHash(_spear[ModelEnum.Atk_Skill_0]._animname),new roleanimev(_spear[ModelEnum.Atk_Skill_0],0.0f,0.3f,0.4f,0.94f));
		_AnimEv.Add (Animator.StringToHash(_spear[ModelEnum.Atk_Skill_1]._animname),new roleanimev(_spear[ModelEnum.Atk_Skill_1],0.0f,0.3f,0.4f,0.94f));

		_preloaded = new Dictionary<ModelEnum, Dictionary<ModelEnum, roleanim>> () {
			{ ModelEnum.WP_THS,_ths },
			{ ModelEnum.WP_SHS,_shs },
			{ ModelEnum.WP_BOW,_bow },
			{ ModelEnum.WP_STAFF,_staff },
			{ ModelEnum.WP_SPEAR,_spear },
		};
	}

	public override void clearrootanim(){
		_Animator.SetBool ("THS",false);
		_Animator.SetBool ("SHS",false);
		_Animator.SetBool ("STAFF",false);
		_Animator.SetBool ("SPEAR",false);
	}

	public override void doanim (ModelEnum _anim)
	{
		if (_AnimParam == null)
			return;
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
	}

	public override void reset ()
	{

	}
}
