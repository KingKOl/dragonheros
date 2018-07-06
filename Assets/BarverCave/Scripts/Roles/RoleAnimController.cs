using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;

public class roleanim{
	public ModelEnum _animtype; //kinds run/idle/attack/skill

	public short _layer;		//which layer 
	public string _animname;	//clip string name or animator node name
	public string _paraname;	//param name
	public int _animhash;
	public int _parahash;		//to hash

	public roleanim(string _name ,string _para ,ModelEnum _type){
		_animname = _name;
		_animtype = _type;
		_paraname = _para;

		_animhash = Animator.StringToHash (_animname);
		_parahash = Animator.StringToHash (_paraname);
	}
}

public class roleanimev{
	public roleanim _anim;

	public float _nort_enter;
	public bool _enter_did;

	public float _nort_effect;
	public bool _effect_did;

	public float _nort_damage;
	public bool _damage_did;

	public float _nort_exit;
	public bool _exit_did;

	public roleanimev(string _name ,string _para,ModelEnum _type , float _in , float _effect , float _damage , float _out){
		_anim = new roleanim (_name,_para,_type);
		_enter_did = _exit_did = _damage_did = _effect_did = false;

		_nort_enter = _in;		//00%
		_nort_effect = _effect;	//36%
		_nort_damage = _damage;	//48%
		_nort_exit = _out;		//90%
	}

	public roleanimev(roleanim _ra, float _in , float _effect , float _damage , float _out){

		_anim = new roleanim (_ra._animname,_ra._paraname,_ra._animtype);
		_enter_did = _exit_did = _damage_did = _effect_did = false;

		_nort_enter = _in;		//00%
		_nort_effect = _effect;	//36%
		_nort_damage = _damage;	//48%
		_nort_exit = _out;		//90%
	}
}

public class RoleAnimController{
	public ModelEnum _Preanim;
	public ModelEnum _WPType;
	public Animator _Animator;
	public Dictionary<ModelEnum,roleanim> _AnimParam = null;	//动画参数
	public Dictionary<int,roleanimev> _AnimEv=null;				//int参数是animname的hash  通过播放anim的名字hash判定当前播放的是哪个动画
	public bool _Mving = false;
	public bool _Atking = false;
	public RoleAnimController(){
		
	}
	public void init(Animator _animator,ModelEnum _wt = ModelEnum.WP_THS){
		_Animator = _animator;
		init_anim_all ();
		_WPType = _wt;
		loadanimation (_wt);
	}

	public virtual void init_anim_all(){
		
	}

	public virtual void loadanimation(ModelEnum _type){
		
	}

	public virtual int getanimstate(){
		return 0;
	}

	public virtual void doanim(ModelEnum _anim){
		
	}

	public void Force2Anim(ModelEnum _e){
		_Animator.Play (_AnimParam[_e]._animname);
	}
	public virtual void clearrootanim(){
		
	}
	public virtual void reset(){
		
	}
}
