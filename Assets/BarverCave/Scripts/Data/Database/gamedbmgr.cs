using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;

public class gamedbmgr : Singleton<gamedbmgr> {
	public List<ObjItem> _inventory;
	public List<Items> _debugitems;
	private dbpreheader _objdatabase;
	private dbpreheader _userdatabase;
	// Use this for initialization
	private gamedbmgr () {
		_objdatabase = new dbpreheader ();
		_userdatabase = new dbpreheader ();
		_inventory = new List<ObjItem> ();
	}

	public void open (){
		_objdatabase.initdb ("tbcobj.db");
		_userdatabase.initdb ("tbcuser.db",false);

		debugitemsdb ();	//test
	}

	public void close(){
		_objdatabase.releasedb ();
		_userdatabase.releasedb ();
	}

	public void debugitemsdb(){
		_debugitems = new List<Items> ();
		_objdatabase.executequery ("SELECT * FROM objitems");
		while (_objdatabase.SQLReader.Read ()) {
			Items _item = new Items ();
			_item._NId = _objdatabase.SQLReader.GetInt32 (0);
			_item._NModel = _objdatabase.SQLReader.GetInt32 (1);
			_item._NQuality = _objdatabase.SQLReader.GetInt32 (2);
			_item._SName = _objdatabase.SQLReader.GetString (3);
			_item._SInfo = _objdatabase.SQLReader.GetString (4);
			_item._NType = _objdatabase.SQLReader.GetInt32 (5);
			_item._NLv = _objdatabase.SQLReader.GetInt32 (6);
			_item._NForge = _objdatabase.SQLReader.GetInt32 (7);
			_item._NCnt = Random.Range(1,2);
			_item._NPrice = _objdatabase.SQLReader.GetInt32 (9);

			for (int i = 0; i < PreHeader.PROPMAX; ++i) {
				_item._ValueType[i] = _objdatabase.SQLReader.GetInt32 (i + 10);
				_item._FValue[i] = _objdatabase.SQLReader.GetDouble (i + 14);
			}
			_debugitems.Add (_item);
		}
	}

	public bool inventorydb(List<Items> _inv){
		_inv.Clear ();
		_inventory.Clear ();

		//背包物品
		_userdatabase.executequery ("SELECT * FROM Inventory");
		while (_userdatabase.SQLReader.Read ()) {
			Items _item = new Items ();
			_item._NId = _userdatabase.SQLReader.GetInt32 (0);
			_item._NCnt = _userdatabase.SQLReader.GetInt32 (1);
			_item._NStat = _userdatabase.SQLReader.GetInt32 (2);

			_objdatabase.executequery (string.Format("SELECT * FROM objitems WHERE NId='{0}'",_item._NId));
			if (!_objdatabase.SQLReader.Read ())
				continue;

			_item._NModel = _objdatabase.SQLReader.GetInt32 (1);
			_item._NQuality = _objdatabase.SQLReader.GetInt32 (2);
			_item._SName = _objdatabase.SQLReader.GetString (3);
			_item._SInfo = _objdatabase.SQLReader.GetString (4);
			_item._NType = _objdatabase.SQLReader.GetInt32 (5);
			_item._NLv = _objdatabase.SQLReader.GetInt32 (6);
			_item._NForge = _objdatabase.SQLReader.GetInt32 (7);
			//_item._NCnt = _objdatabase.SQLReader.GetInt32 (7);
			_item._NPrice = _objdatabase.SQLReader.GetInt32 (9);

			for (int i = 0; i < PreHeader.PROPMAX; ++i) {
				_item._ValueType[i] = _objdatabase.SQLReader.GetInt32 (i + 10);
				_item._FValue[i] = _objdatabase.SQLReader.GetDouble (i + 14);
			}

			_inv.Add (_item);
		}
		return true;
	}

	public ObjItem generateitem(Items _data){
		GameObject _itemprefab = GameObject.Instantiate (Resources.Load ("UIFrame/ObjItem", typeof(GameObject))) as GameObject;
		ObjItem _uiitem = _itemprefab.GetComponent<ObjItem> ();
		_uiitem.init (_data);
		return _uiitem;
	}

	public DropItem generateitemdrop(Items _data){
		GameObject _itemprefab = GameObject.Instantiate (Resources.Load ("UIFrame/DropItem", typeof(GameObject))) as GameObject;
		DropItem _uiitem = _itemprefab.GetComponent<DropItem> ();
		_uiitem.Init (_data);
		return _uiitem;
	}

	public SkillItem _skillitem_generate(Items _item){
		GameObject _itemprefab = GameObject.Instantiate (Resources.Load ("UIFrame/SkillItem", typeof(GameObject))) as GameObject;
		SkillItem _uiitem = _itemprefab.GetComponent<SkillItem> ();
		_uiitem.init (_item);

		_uiitem.transform.SetParent(GameResources.Instance()._SkillPanel);
		_uiitem.setsize (GameResources._v2_100);
		return _uiitem;
	}

	public ObjItem _uiitem_generate(ObjItem _uiitem,PARENT_PANEL _parent,Items _item = null){
		ObjItem _ptr = null;
		if (_uiitem == null) {
			_ptr = generateitem (_item);
		} else {
			_ptr = _uiitem;
		}

		switch (_parent) {
		case PARENT_PANEL.INVENTORY:
			_ptr.transform.SetParent(GameResources.Instance()._InventoryPanel);
			_ptr.setsize (GameResources._v2_70);
			break;
		case PARENT_PANEL.EQSOLT:
			_ptr.transform.SetParent(GameResources.Instance()._EquipSolt[_ptr._Items._PartId]);
			_ptr.setsize (GameResources._v2_64);
			break;
		case PARENT_PANEL.SKILL:
			_ptr.transform.SetParent(GameResources.Instance()._SkillPanel);
			_ptr.setsize (GameResources._v2_100);
			break;
		default:
			break;
		}
		return _ptr;
	}

	public void add2inv(Items _item){
		_userdatabase.executequery (string.Format("SELECT NCnt FROM Inventory WHERE NId = {0} AND NStat = {1}", _item._NId,-1));
		if (_userdatabase.SQLReader.HasRows) {
			_userdatabase.SQLReader.Read ();
			int ninvcnt = _userdatabase.SQLReader.GetInt32 (0);
			_userdatabase.executequery (string.Format("UPDATE Inventory SET NCnt = {0} WHERE NId = {1} AND NStat = {2}",
				ninvcnt + _item._NCnt, _item._NId, -1));

			//数量变更
			int index = _inventory.FindIndex ((p)=>{
				return p._Items._NId == _item._NId && p._Items._NStat == -1;
			});
			if (index < 0)
				Debug.Log (index + " _inventory.FindIndex error ");
			_inventory[index].gain (_item._NCnt);
		} else {
			_userdatabase.executequery (string.Format("INSERT INTO Inventory VALUES ({0}, {1}, {2})",_item._NId,_item._NCnt,-1));
			_inventory.Add (_uiitem_generate (null,PARENT_PANEL.INVENTORY,_item));
		}
	}

	/// <summary>
	/// Equipadd2inv the specified _item and _ncnt.
	/// </summary>
	/// <param name="_item">Item.</param>
	/// <param name="_ncnt">Ncnt.</param>
	public bool equipadd2inv(ObjItem _uiitem,int _ncnt){
		bool _flag = false;		//背包有此物品时返回true   无此物品时返回false
		Items _item = _uiitem._Items;
		_userdatabase.executequery (string.Format("SELECT NCnt FROM Inventory WHERE NId = {0} AND NStat = {1}", _item._NId,-1));
		if (_userdatabase.SQLReader.HasRows) {
			_userdatabase.SQLReader.Read ();
			int neqinvcnt = _userdatabase.SQLReader.GetInt32 (0);
			_userdatabase.executequery (string.Format("UPDATE Inventory SET NCnt = {0} WHERE NId = {1} AND NStat = {2}",
				neqinvcnt + _ncnt, _item._NId, -1));

			//数量变更
			int index = _inventory.FindIndex ((p)=>{
				return p._Items._NId == _item._NId && p._Items._NStat == -1;
			});
			if (index < 0)
				Debug.Log (index + " _inventory.FindIndex error ");
			_inventory[index].gain (_ncnt);

			_flag = true;
		} else {
			_userdatabase.executequery (string.Format("INSERT INTO Inventory VALUES ({0}, {1}, {2})",_item._NId,_ncnt,-1));
			_uiitem._Items._NStat = -1;
			_inventory.Add (_uiitem);
			_uiitem_generate (_uiitem,PARENT_PANEL.INVENTORY);
		}
		//清空装备槽
		_userdatabase.executequery (string.Format("UPDATE Inventory SET NId = {0} WHERE NStat = {1}",0,_item._PartId));
		return _flag;
	}

	/// <summary>
	/// Invadd2equip the specified _item.
	/// </summary>
	/// <param name="_item">Item.</param>
	public void invadd2equip(ObjItem _uiitem){
		Items _item = _uiitem._Items;

		if (_item._NCnt == 1) {
			_userdatabase.executequery (string.Format("DELETE FROM Inventory WHERE NId = {0} AND NCnt = {1} AND NStat = {2}",_item._NId,_item._NCnt,-1));

			_uiitem._Items._NStat = _uiitem._Items._PartId;
			_uiitem_generate (_uiitem,PARENT_PANEL.EQSOLT);

			_inventory.Remove (_uiitem);
		} else {
			_userdatabase.executequery (string.Format ("UPDATE Inventory SET NCnt = {0} WHERE NId = {1} AND NCnt = {2} AND NStat = {3}",
				_item._NCnt - 1, _item._NId, _item._NCnt, _item._NStat));

			_uiitem.consume (1);

			ObjItem _itemrtn = _uiitem_generate (null,PARENT_PANEL.EQSOLT,_item);
			_itemrtn.setcnt(1);
			_itemrtn._Items._NStat = _uiitem._Items._PartId;
		}
		//写入装备槽
		_userdatabase.executequery (string.Format("UPDATE Inventory SET NId = {0} WHERE NStat = {1}",_item._NId,_item._PartId));
	}
}
