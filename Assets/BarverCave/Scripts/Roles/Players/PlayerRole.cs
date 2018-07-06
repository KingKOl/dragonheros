using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;

public class PlayerRole : Role {
	public override void init(Animator _animator){
		base.init (_animator);

		m_property = new RoleProperty ();
		m_equipment = new RoleEquipment ();
		m_equipment.init (GameResources.Instance()._ObjPlayer.transform);

		m_skillcontroler = new PlayerSkillController ();
		m_skillcontroler.init ();

		m_animcontroler = new PlayerAnimController ();
		m_animcontroler.init (_animator);

		InventoryImpl.Instance ().init ();
	}
}
