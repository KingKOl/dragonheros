using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRole : Role {
	public bool _Dead {get{ return m_property.NHp < 1;}}

	public EnemyRole(ns_predefine.ModelEnum _t){
		m_roletype = _t;
	}

	public override void init(Animator _animator){

		switch (m_roletype) {
		case ns_predefine.ModelEnum.Enemy_Bat:
			m_animcontroler = new EMBat ();
			break;
		case ns_predefine.ModelEnum.Enemy_Cactus:
			m_animcontroler = new EMCactus ();
			break;
		case ns_predefine.ModelEnum.Enemy_DeadKnight:
			m_animcontroler = new EMDeadKnight ();
			break;
		case ns_predefine.ModelEnum.Enemy_Dragon:
			m_animcontroler = new EMDragon ();
			break;
		case ns_predefine.ModelEnum.Enemy_Dragon_Fly:
			m_animcontroler = new EMDragonFly ();
			break;
		case ns_predefine.ModelEnum.Enemy_Ghost:
			m_animcontroler = new EMGhost ();
			break;
		case ns_predefine.ModelEnum.Enemy_Plant:
			m_animcontroler = new EMPlant ();
			break;
		case ns_predefine.ModelEnum.Enemy_Rock:
			m_animcontroler = new EMRock ();
			break;
		case ns_predefine.ModelEnum.Enemy_SKArcher:
			m_animcontroler = new EMSKArcher ();
			break;
		case ns_predefine.ModelEnum.Enemy_SKKnight:
			m_animcontroler = new EMSKKnight ();
			break;
		case ns_predefine.ModelEnum.Enemy_SKMage:
			m_animcontroler = new EMSKMage ();
			break;
		}
		_ObjRole = GameObject.Instantiate(GameResources.loadGameObject ((int)m_roletype + 1)) as GameObject;
		_ObjRole.transform.position = GameResources.Instance ()._GameMgr._MapMgr.getspwanpoint ();
		m_animcontroler.init (_ObjRole.GetComponent<Animator>());

		m_property = new RoleProperty ();
		m_property.SName = m_roletype.ToString ();
		_EnemyBloodBar = new UIBloodBar ();
		_EnemyBloodBar.NAME = m_property.SName.Replace("Enemy_","");
		_EnemyBloodBar.BLOOD = (float)m_property.NHp / (float)m_property.NMaxHp;
	}
	public bool targeting(){
		return Vector3.Distance (_ObjRole.transform.position, GameResources.Instance ()._ObjPlayer.transform.position) < m_property._AtkRange;
	}

	public override void update(){
		aiupdate ();
	}
}
