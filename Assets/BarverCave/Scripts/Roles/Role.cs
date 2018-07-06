using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;

public class Role {
	public GameObject _ObjRole;
	public RoleProperty m_property;
	public RoleAnimController m_animcontroler;
	public RoleEquipment m_equipment;
	public RoleSkillController m_skillcontroler;
	public ModelEnum m_rolestate = ModelEnum.Idle;
	public ModelEnum m_roletype = ModelEnum.Enemy_Bat;
	//public TBCMsg m_rolemsgfsm;
	public int m_attacktaghash= Animator.StringToHash("AttackAnim");
	public int m_normaltaghash= Animator.StringToHash("NormalAnim");
	public int m_runingtaghash= Animator.StringToHash("RuningAnim");

	public AnimEventHandler _AEVHandler = null;
	public UIBloodBar _EnemyBloodBar;

	public Role(){
		
	}
	public virtual void init(Animator _animator){
		
	}
	public virtual void eat (TBCMsg msg = null)
	{
		switch (msg._Type) {
		case ModelEnum.HPFood:
			m_property.NHp += (int)msg._fValue;
			break;
		case ModelEnum.MAXHPFood:
			m_property.NMaxHp += (int)msg._fValue;
			break;
		case ModelEnum.MPFood:
			m_property.NMp += (int)msg._fValue;
			break;
		case ModelEnum.MAXMPFood:
			m_property.NMaxMp += (int)msg._fValue;
			break;
		case ModelEnum.DEFFood:
			m_property.NDef += (int)msg._fValue;
			break;
		case ModelEnum.DPSFood:
			m_property.NDps += (int)msg._fValue;
			break;
		case ModelEnum.LVFood:
			m_property.NLv += (int)msg._fValue;
			break;
		case ModelEnum.SPDFood:
			m_property.NSpd += (int)msg._fValue;
			break;
		default:
			break;
		}
	}

	public virtual void gotostate (ModelEnum _state)
	{
		m_animcontroler.doanim (_state);
	}

	public virtual void blooding (int _val)
	{
		m_property.NHp += _val;
		if (_EnemyBloodBar != null) {
			_EnemyBloodBar.BLOOD = m_property.BloodAmount ();
		}
	}

	public virtual void update(){

		aiupdate ();
	}

	public virtual void aiupdate(){
		if (m_animcontroler._Animator != null) {
			AnimatorStateInfo _asi = m_animcontroler._Animator.GetCurrentAnimatorStateInfo (0);
			if (_asi.tagHash == m_attacktaghash) {
				//m_animcontroler._Animator.speed = 1.0f;
				//进入和特效还是攻击生效都应该在90%之内完成
				if (_asi.normalizedTime < 0.9f) {
					if (_asi.normalizedTime >= m_animcontroler._AnimEv [_asi.shortNameHash]._nort_enter) {
						if (!m_animcontroler._AnimEv [_asi.shortNameHash]._enter_did) {
							m_animcontroler._AnimEv [_asi.shortNameHash]._enter_did = true;

							if (_AEVHandler != null)
								_AEVHandler (ModelEnum.AEV_ENTER);
						}
					}
					if (_asi.normalizedTime >= m_animcontroler._AnimEv [_asi.shortNameHash]._nort_damage) {
						if (!m_animcontroler._AnimEv [_asi.shortNameHash]._damage_did) {
							m_animcontroler._AnimEv [_asi.shortNameHash]._damage_did = true;

							if (_AEVHandler != null)
								_AEVHandler (ModelEnum.AEV_DAMAGE);
						}
					}
					if (_asi.normalizedTime >= m_animcontroler._AnimEv [_asi.shortNameHash]._nort_effect) {
						if (!m_animcontroler._AnimEv [_asi.shortNameHash]._effect_did) {
							m_animcontroler._AnimEv [_asi.shortNameHash]._effect_did = true;

							if (_AEVHandler != null)
								_AEVHandler (ModelEnum.AEV_EFFECT);
						}
					}
				} else {
					if (_asi.normalizedTime >= m_animcontroler._AnimEv [_asi.shortNameHash]._nort_exit) {
						m_animcontroler._AnimEv [_asi.shortNameHash]._enter_did = false;
						m_animcontroler._AnimEv [_asi.shortNameHash]._damage_did = false;
						m_animcontroler._AnimEv [_asi.shortNameHash]._effect_did = false;

						if (_AEVHandler != null)
							_AEVHandler (ModelEnum.AEV_EXIT);
					}
				}
				m_animcontroler._Atking = true;

			} else {
				m_animcontroler._Atking = false;
				m_animcontroler._Mving = (_asi.tagHash == m_runingtaghash);
			}
		}
	}
}
