using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;

public class AIEnemy {

	public Role _Role;
	private float _Timer = 0;
	private int _Counter = 0;
	private float _CheckTimer = 0;

	private bool _Targeting = false;
	private bool _Dead = false;
	private bool _Hunted = false;	//找到敌人后此标记变为true，为了玩家远离怪物时技能面板隐藏
	private BonusChest _bonus;
	public void update(){
		
		if (_Role == null)
			return;

		Logic ();

		_Role.update ();
	}

	public void generate(ModelEnum _t = ModelEnum.Enemy_Cactus){
		_Role = new EnemyRole (_t);
		_Role.init (null);
		_Role.gotostate (ModelEnum.Idle);
		_Role._AEVHandler += AnimatorEventHandler;
	}

	public void Logic(){
		if (_bonus != null) {
			_bonus.update ();
		}

		if (_Role.m_property.BAlive) {
			if (((EnemyRole)_Role).targeting ()) {
				_Hunted = true;
				_Targeting = true;
				_Role._EnemyBloodBar.show (true);
				_Role._ObjRole.transform.LookAt (GameResources.Instance()._ObjPlayer.transform);
				GameResources.Instance ()._GameMgr._AIPlayer.GETEnemy (this);
			} else {
				_Targeting = false;
				if (_Hunted) {
					_Role.gotostate (ModelEnum.Idle);
					Debug.Log("123123");
					//_Role.m_animcontroler.Force2Anim (ModelEnum.Idle);
					_Role._EnemyBloodBar.show (false);
					GameResources.Instance ()._GameMgr._AIPlayer.GETEnemy (null);
				}
				_Hunted = false;
			}
		}

		if (_CheckTimer > 1.0f) {

			if (!_Role.m_property.BAlive) {
				if (!_Dead) {
					_bonus = new BonusChest ();
					_Role.gotostate (ModelEnum.Die);
					_Role.m_animcontroler.Force2Anim (ModelEnum.Die);
					_Role._EnemyBloodBar.show (false);
					_bonus.show (_Role._ObjRole.transform.position);
					GameObject.DestroyObject (_Role._ObjRole,0.5f);
					GameResources.Instance ()._GameMgr._AIPlayer.GETEnemy (null);
				}
				_Dead = true;
			} else {
				if (_Targeting) {
					_Role.gotostate (ModelEnum.Atk_Skill_1);
				}
			}
			_CheckTimer = 0;
		}

		_CheckTimer += Time.deltaTime;
	}

	public void AnimatorEventHandler(ModelEnum _t){
		switch (_t) {
		case ModelEnum.AEV_ENTER:
			break;
		case ModelEnum.AEV_EFFECT:
			break;
		case ModelEnum.AEV_DAMAGE:
			break;
		case ModelEnum.AEV_EXIT:
			break;
		}
	}
}
