using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;

public class EquipNode
{
	public bool _BObject;
	public string _BoneNodeName;
	public Transform _BoneNode;
	public GameObject _Equiped;
	public EquipNode(){
		_BObject = false;
		_BoneNodeName = "";
		_BoneNode = null;
		_Equiped = null;
	}

	public EquipNode(string _name){
		_BObject = false;
		_BoneNodeName = _name;
		_BoneNode = null;
		_Equiped = null;
	}
}

public class RoleEquipment{
	public Dictionary<ModelEnum,EquipNode> _equipnodes;

	public void init(Transform _roletrans)
	{
		_equipnodes = new Dictionary<ModelEnum, EquipNode> ();
		EquipNode _weaponnode = new EquipNode ("Dummy Prop Right");
		_weaponnode._BObject = true;
		_equipnodes.Add (ModelEnum.EqWeapon,_weaponnode);

		EquipNode _subweaponnode = new EquipNode ("Dummy Prop Left");
		_subweaponnode._BObject = true;
		_equipnodes.Add (ModelEnum.EqSubWeapon,_subweaponnode);

		EquipNode _hatnode = new EquipNode ("Dummy Prop Head");
		_hatnode._BObject = true;
		_equipnodes.Add (ModelEnum.EqHats,_hatnode);

		EquipNode _armornode = new EquipNode ("Base");
		_armornode._BObject = true;
		_equipnodes.Add (ModelEnum.EqArmor,_armornode);

		EquipNode _glovenode = new EquipNode ();
		_equipnodes.Add (ModelEnum.EqGloves,_glovenode);

		EquipNode _pantsnode = new EquipNode ();
		_equipnodes.Add (ModelEnum.EqPants,_pantsnode);

		EquipNode _bootsnode = new EquipNode ();
		_equipnodes.Add (ModelEnum.EqBoots,_bootsnode);

		EquipNode _wingnode = new EquipNode ("Dummy Prop Back");
		_wingnode._BObject = true;
		_equipnodes.Add (ModelEnum.EqWings,_wingnode);

		EquipNode _necklacenode = new EquipNode ();
		_equipnodes.Add (ModelEnum.EqNeckLace,_necklacenode);

		EquipNode _braceletnode = new EquipNode ();
		_equipnodes.Add (ModelEnum.EqBraceLet,_braceletnode);

		EquipNode _jadenode = new EquipNode ();
		_equipnodes.Add (ModelEnum.EqJade,_jadenode);

		Transform[] _nodes = _roletrans.GetComponentsInChildren<Transform>();
		foreach (Transform _tr in _nodes)
		{
			foreach (ModelEnum _item in _equipnodes.Keys)
			{
				if (_tr.name.Equals(_equipnodes[_item]._BoneNodeName))
					_equipnodes[_item]._BoneNode = _tr;
			}
		}
	}
	public void equipon(ModelEnum _eq , UnityEngine.Object _equip)
	{
		equipoff (_eq);
		if (!_equipnodes [_eq]._BObject)
			return;
		if (_eq == ModelEnum.EqArmor) {
			_equipnodes[_eq]._BoneNode.GetComponent<SkinnedMeshRenderer>().material = (Material)_equip;
			return;
		}

		_equipnodes[_eq]._Equiped = (GameObject)_equip;
		_equipnodes[_eq]._Equiped.transform.parent = _equipnodes[_eq]._BoneNode;
		_equipnodes[_eq]._Equiped.transform.localScale = Vector3.one;
		_equipnodes[_eq]._Equiped.transform.localPosition = Vector3.zero;

		switch (_eq) {
		case ModelEnum.EqWeapon:
		case ModelEnum.EqSubWeapon:
			_equipnodes [_eq]._Equiped.transform.localRotation = Quaternion.Euler (270.0f, 0.0f, 0.0f);
			break;
		case ModelEnum.EqWings:
			_equipnodes[_eq]._Equiped.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
			break;
		default:
			break;
		}

	}
	public void equipoff(ModelEnum _eq)
	{
		if (_equipnodes [_eq]._BObject) {
			if (_equipnodes [_eq]._Equiped != null)
				GameObject.Destroy (_equipnodes [_eq]._Equiped);
			_equipnodes [_eq]._Equiped = null;

			if (_eq == ModelEnum.EqArmor)
				_equipnodes [_eq]._BoneNode.GetComponent<SkinnedMeshRenderer> ().material = null;
		}
	}
}
