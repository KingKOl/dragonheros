using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;

public class atk{
	public SkillItem _atkitem;
	public bool _aquired;
	public bool _haseffect;
	public bool _isskill;
	public atk(){
		_haseffect = true;
		_atkitem = gamedbmgr.Instance ()._skillitem_generate (new Items());
	}
}

public class RoleSkillController {
	public bool _atking = false;
	public Items _curskill = null;
	public ModelEnum _WeaponType = ModelEnum.WP_THS;
	public Dictionary<ModelEnum,atk> _atks;
	public void init(ModelEnum _wt = ModelEnum.WP_THS){
		_curskill = new Items ();

		initattacks ();

		loadskill (_wt);
	}
	private void initattacks(){
		_atks = new Dictionary<ModelEnum, atk> ();
		_atks.Add (ModelEnum.Atk_Skill_0,new atk());
		_atks.Add (ModelEnum.Atk_Skill_1,new atk());
		_atks.Add (ModelEnum.Atk_Skill_2,new atk());
		_atks.Add (ModelEnum.Atk_Skill_3,new atk());
		_atks.Add (ModelEnum.Atk_Skill_4,new atk());
	}

	public virtual void loadskill(ModelEnum _type){
		
	}

	public void onskillaction(Items _item){
		if (_atking)
			return;
		_curskill.Clone (_item);
	}

	public virtual void skilleffect(){

	}

	public virtual void skillexit(){

	}
}
