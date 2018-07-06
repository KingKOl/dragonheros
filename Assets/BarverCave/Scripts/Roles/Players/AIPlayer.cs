using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;
using TinyTeam.UI;

public class AIPlayer {
	private Role _Role;
	private ETCJoystick _JoyStick;
	public bool _Atking{get { return _Role.m_animcontroler._Atking;}}
	public bool _Mving{get { return _Role.m_animcontroler._Mving;}}
	private AIEnemy _TargetEnemy;
	public void update(){
		if (_Role == null)
			return;
		_Role.update ();
		//_Role.m_animcontroler.getanimstate ();
	}

	public void generate(){
		_Role = new PlayerRole ();
		_Role.init (GameResources.Instance()._ObjPlayer.GetComponent<Animator>());

		_JoyStick = GameResources.Instance()._ObjJoyStick.GetComponent<ETCJoystick>();
		_JoyStick.onMoveStart.AddListener(onmovestart);
		_JoyStick.onMoveEnd.AddListener(onmoveend);

		_Role._AEVHandler += AnimatorEventHandler;
	}

	public void moduelequip(Items _item){
		switch (_item._ModelType) {
		case ModelEnum.EqWeapon:
		case ModelEnum.EqWings:
			GameObject _obj = GameResources.loadGameObject (_item._NModel);
			if (_obj != null) {
				if (_item._ModelType == ModelEnum.EqWeapon) {
					_Role.m_animcontroler.loadanimation ((ModelEnum)_item._NType);
					_Role.m_skillcontroler.loadskill ((ModelEnum)_item._NType);
				}
				//替换模型
				_Role.m_equipment.equipon (_item._ModelType, GameObject.Instantiate (_obj) as GameObject);
			}
			break;
		default:
			
			break;
		}
	}

	private void onmovestart ()
	{
		_Role.m_animcontroler.doanim (ModelEnum.Run);
	}

	private void onmoveend ()
	{
		_Role.m_animcontroler.doanim (ModelEnum.Idle);
	}

	public void AnimatorEventHandler(ModelEnum _t){
		switch (_t) {
		case ModelEnum.AEV_ENTER:
			break;
		case ModelEnum.AEV_EFFECT:
			_Role.m_skillcontroler.skilleffect ();
			break;
		case ModelEnum.AEV_DAMAGE:
			if (_TargetEnemy != null) {
				_TargetEnemy._Role.blooding (-50);
			}
			break;
		case ModelEnum.AEV_EXIT:
			if (false){//_Role.m_skillcontroler._WeaponType == ModelEnum.WP_SHS && (ModelEnum)_Role.m_skillcontroler._curskill._NType == ModelEnum.Atk_Skill_3) {
				
			} else {
				_Role.m_animcontroler.doanim (ModelEnum.Idle);
				_Role.m_skillcontroler.skillexit ();
			}

			break;
		}
	}

	public void OnSkillPressed(SkillItem p)
	{
		//_JoyStick.activated = false;
		//如果攻击动画和跑路动画没有播放完，就不能释放其它技能
		if (_Atking || _Mving)
			return;

		//attack do
		_Role.m_skillcontroler.onskillaction (p._Items);

		_Role.m_animcontroler.doanim ((ModelEnum)p._Items._NStat);
	}

	private void onfoods(ObjItem p)
	{
		
	}

	public void onitemclick(ObjItem p)
	{
		if(p._Items._NModel >= (int)ModelEnum.Food && p._Items._NModel <= (int)ModelEnum.FoodEnd)
		{
			onfoods (p);
		}
		else if(p._Items._NModel >= (int)ModelEnum.Equip && p._Items._NModel <= (int)ModelEnum.EquipEnd)
		{
			moduelequip (p._Items);
			InventoryImpl.Instance ().equipon (p);
		}
	}

	public void GETEnemy(AIEnemy _em){
		_TargetEnemy = _em;
		if (_TargetEnemy == null) {
			UIPageMgr.Instance ().showbattleui (false);

		} else {
			UIPageMgr.Instance ().showbattleui (true);
			GameResources.Instance ()._ObjPlayer.transform.LookAt (_TargetEnemy._Role._ObjRole.transform);
		}
	}
}
