using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;

public class PlayerSkillController : RoleSkillController {
	
	public override void loadskill(ModelEnum _type){
		_WeaponType = _type;

		switch (_type) {
		case ModelEnum.WP_THS:
			loaddjskill ();
			break;
		
		case ModelEnum.WP_STAFF:
			loadfzskill ();
			break;

		case ModelEnum.WP_SHS:
			loaddsskill ();
			break;
		default:
			break;
		}	
		foreach (var val in _atks.Values)
			val._atkitem.flash ();
	}
	#region djskill
	private void loaddjskill(){

		ModelEnum _type = ModelEnum.ActionAttack;
		_type = ModelEnum.Atk_Skill_0;
		_atks [_type]._atkitem._Items._NModel = 100;	//图标id
		_atks [_type]._atkitem._Items._NType = (int)_type;	//代表当前是哪个技能
		_atks [_type]._atkitem._Items._NStat = (int)ModelEnum.Atk_Normal_0;	//代表当前要播放哪个动画（即处于哪个状态）	
		_atks [_type]._atkitem._Items._NCnt = 1;	//代表当前技能CD	

		_type = ModelEnum.Atk_Skill_1;
		_atks [_type]._atkitem._Items._NModel = 120;
		_atks [_type]._atkitem._Items._NType = (int)_type;
		_atks [_type]._atkitem._Items._NStat = (int)ModelEnum.Atk_Normal_1;	//代表当前要播放哪个动画（即处于哪个状态）	
		_atks [_type]._atkitem._Items._NCnt = 2;	//代表当前技能CD	

		_type = ModelEnum.Atk_Skill_2;
		_atks [_type]._atkitem._Items._NModel = 140;
		_atks [_type]._atkitem._Items._NType = (int)_type;
		_atks [_type]._atkitem._Items._NStat = (int)ModelEnum.Atk_Normal_0;	//代表当前要播放哪个动画（即处于哪个状态）	
		_atks [_type]._atkitem._Items._NCnt = 3;	//代表当前技能CD	

		_type = ModelEnum.Atk_Skill_3;
		_atks [_type]._atkitem._Items._NModel = 160;
		_atks [_type]._atkitem._Items._NType = (int)_type;
		_atks [_type]._atkitem._Items._NStat = (int)ModelEnum.Atk_Skill_0;	//代表当前要播放哪个动画（即处于哪个状态）	
		_atks [_type]._atkitem._Items._NCnt = 4;	//代表当前技能CD	

		_type = ModelEnum.Atk_Skill_4;
		_atks [_type]._atkitem._Items._NModel = 180;
		_atks [_type]._atkitem._Items._NType = (int)_type;
		_atks [_type]._atkitem._Items._NStat = (int)ModelEnum.Atk_Skill_1;	//代表当前要播放哪个动画（即处于哪个状态）	
		_atks [_type]._atkitem._Items._NCnt = 5;	//代表当前技能CD	
	}
	#endregion

	private void loadfzskill(){
		ModelEnum _type = ModelEnum.ActionAttack;

		_type = ModelEnum.Atk_Skill_0;
		_atks [_type]._atkitem._Items._NModel = 105;
		_atks [_type]._atkitem._Items._NType = (int)_type;	//代表当前是哪个技能
		_atks [_type]._atkitem._Items._NStat = (int)ModelEnum.Atk_Normal_0;	//代表当前要播放哪个动画（即处于哪个状态）	
		_atks [_type]._atkitem._Items._NCnt = 1;	//代表当前技能CD	

		_type = ModelEnum.Atk_Skill_1;
		_atks [_type]._atkitem._Items._NModel = 125;
		_atks [_type]._atkitem._Items._NType = (int)_type;	//代表当前是哪个技能
		_atks [_type]._atkitem._Items._NStat = (int)ModelEnum.Atk_Normal_1;	//代表当前要播放哪个动画（即处于哪个状态）	
		_atks [_type]._atkitem._Items._NCnt = 1;	//代表当前技能CD	


		_type = ModelEnum.Atk_Skill_2;
		_atks [_type]._atkitem._Items._NModel = 145;
		_atks [_type]._atkitem._Items._NType = (int)_type;	//代表当前是哪个技能
		_atks [_type]._atkitem._Items._NStat = (int)ModelEnum.Atk_Normal_1;	//代表当前要播放哪个动画（即处于哪个状态）	
		_atks [_type]._atkitem._Items._NCnt = 5;	//代表当前技能CD	

		_type = ModelEnum.Atk_Skill_3;
		_atks [_type]._atkitem._Items._NModel = 165;
		_atks [_type]._atkitem._Items._NType = (int)_type;	//代表当前是哪个技能
		_atks [_type]._atkitem._Items._NStat = (int)ModelEnum.Atk_Skill_0;	//代表当前要播放哪个动画（即处于哪个状态）	
		_atks [_type]._atkitem._Items._NCnt = 5;	//代表当前技能CD	

		_type = ModelEnum.Atk_Skill_4;
		_atks [_type]._atkitem._Items._NModel = 185;
		_atks [_type]._atkitem._Items._NType = (int)_type;	//代表当前是哪个技能
		_atks [_type]._atkitem._Items._NStat = (int)ModelEnum.Atk_Skill_1;	//代表当前要播放哪个动画（即处于哪个状态）	
		_atks [_type]._atkitem._Items._NCnt = 5;	//代表当前技能CD	
	}

	private void loaddsskill(){
		ModelEnum _type = ModelEnum.ActionAttack;

		_type = ModelEnum.Atk_Skill_0;
		_atks [_type]._atkitem._Items._NModel = 110;
		_atks [_type]._atkitem._Items._NType = (int)_type;	//代表当前是哪个技能
		_atks [_type]._atkitem._Items._NStat = (int)ModelEnum.Atk_Normal_0;	//代表当前要播放哪个动画（即处于哪个状态）	
		_atks [_type]._atkitem._Items._NCnt = 1;	//代表当前技能CD	

		_type = ModelEnum.Atk_Skill_1;
		_atks [_type]._atkitem._Items._NModel = 130;
		_atks [_type]._atkitem._Items._NType = (int)_type;	//代表当前是哪个技能
		_atks [_type]._atkitem._Items._NStat = (int)ModelEnum.Atk_Normal_1;	//代表当前要播放哪个动画（即处于哪个状态）	
		_atks [_type]._atkitem._Items._NCnt = 1;	//代表当前技能CD	

		_type = ModelEnum.Atk_Skill_2;
		_atks [_type]._atkitem._Items._NModel = 150;
		_atks [_type]._atkitem._Items._NType = (int)_type;	//代表当前是哪个技能
		_atks [_type]._atkitem._Items._NStat = (int)ModelEnum.Atk_Normal_0;	//代表当前要播放哪个动画（即处于哪个状态）	
		_atks [_type]._atkitem._Items._NCnt = 1;	//代表当前技能CD	

		_type = ModelEnum.Atk_Skill_3;
		_atks [_type]._atkitem._Items._NModel = 170;
		_atks [_type]._atkitem._Items._NType = (int)_type;	//代表当前是哪个技能
		_atks [_type]._atkitem._Items._NStat = (int)ModelEnum.Atk_Skill_0;	//代表当前要播放哪个动画（即处于哪个状态）	
		_atks [_type]._atkitem._Items._NCnt = 1;	//代表当前技能CD	

		_type = ModelEnum.Atk_Skill_4;
		_atks [_type]._atkitem._Items._NModel = 190;
		_atks [_type]._atkitem._Items._NType = (int)_type;	//代表当前是哪个技能
		_atks [_type]._atkitem._Items._NStat = (int)ModelEnum.Atk_Skill_1;	//代表当前要播放哪个动画（即处于哪个状态）	
		_atks [_type]._atkitem._Items._NCnt = 1;	//代表当前技能CD	
	}

	public override void skilleffect(){
		ModelEnum _t = (ModelEnum)_curskill._NType;
		if (!_atks [_t]._haseffect)
			return;
		
		GameObject _item = GameObject.Instantiate (GameResources.loadGameObject (_atks[_t]._atkitem._Items._NModel),GameResources.Instance ()._ObjPlayer.transform) as GameObject;
		_item.transform.localPosition = Vector3.zero;
		_item.transform.localEulerAngles = Vector3.zero;
		_item.transform.localScale = Vector3.one;

		switch (_WeaponType) {
		case ModelEnum.WP_THS:
			
			switch (_t) {
			case ModelEnum.Atk_Skill_0:
				MoveFoward _mf0 = _item.AddComponent<MoveFoward> ();
				_mf0.move (new Vector3(0,1,1),new Vector3(0,0,24),18f);
				break;
			case ModelEnum.Atk_Skill_1:
				MoveFoward _mf1 = _item.AddComponent<MoveFoward> ();
				_mf1.move (new Vector3(0,1,1),new Vector3(0,0,24),18f);
				break;
			case ModelEnum.Atk_Skill_2:
				MoveFoward _mf = _item.AddComponent<MoveFoward> ();
				_mf.move (new Vector3(0,1,1),new Vector3(0,0,24),18f);
				break;
			case ModelEnum.Atk_Skill_3:
				_item.transform.localPosition = new Vector3(0,0.6f,0);
				break;
			case ModelEnum.Atk_Skill_4:
				_item.transform.localPosition = new Vector3(0,0,0);
				_item.transform.localScale = Vector3.one;
				_item.transform.SetParent (null);
				break;
			}

			break;
		case ModelEnum.WP_SHS:

			switch (_t) {
			case ModelEnum.Atk_Skill_0:
				MoveFoward _mf0 = _item.AddComponent<MoveFoward> ();
				_mf0.move (new Vector3(0,1,1),new Vector3(0,0,90),18f);
				break;
			case ModelEnum.Atk_Skill_1:
				MoveFoward _mf1 = _item.AddComponent<MoveFoward> ();
				_mf1.move (new Vector3(0,1,1),new Vector3(0,0,90),18f);
				break;
			case ModelEnum.Atk_Skill_2:
				MoveFoward _mf = _item.AddComponent<MoveFoward> ();
				_mf.move (new Vector3(0,1,1),new Vector3(0,0,90),18f);
				break;
			case ModelEnum.Atk_Skill_3:
				_item.transform.localPosition = new Vector3(0,0.6f,0);
				break;
			case ModelEnum.Atk_Skill_4:
				_item.transform.localPosition = new Vector3(0,0,2);
				_item.transform.localScale = Vector3.one;
				_item.transform.SetParent (null);
				break;
			}

			break;
		case ModelEnum.WP_STAFF:
			
			switch (_t) {
			case ModelEnum.Atk_Skill_0:
				MoveFoward _mf0 = _item.AddComponent<MoveFoward> ();
				_mf0.move (new Vector3 (0, 1, 1.5f), Vector3.zero, 8f);
				break;
			case ModelEnum.Atk_Skill_1:
				MoveFoward _mf = _item.AddComponent<MoveFoward> ();
				_mf.move (new Vector3(0,1,1.5f),Vector3.zero,8f);
				break;
			case ModelEnum.Atk_Skill_2:
				_item.transform.localPosition = new Vector3(0,1.5f,3.3f);
				_item.transform.SetParent (null);
				break;
			case ModelEnum.Atk_Skill_3:
				_item.transform.localPosition = new Vector3(0,1.0f,1.5f);
				_item.transform.SetParent (null);
				break;
			case ModelEnum.Atk_Skill_4:
				_item.transform.localPosition = new Vector3(0,0.8f,2);
				_item.transform.SetParent (null);
				break;
			}

			break;
		default:
			break;
		}
	}
}
