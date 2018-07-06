using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;
using UnityEngine.UI;

public class InventoryImpl : Singleton<InventoryImpl>  {

	private InventoryImpl(){
		
	}

	public void init(){
		List<Items> _inv = new List<Items> ();
		gamedbmgr.Instance ().inventorydb (_inv);
		_init_inventory (_inv);
	}

	public void equipon(ObjItem _data){

		equipoff (_data);

		gamedbmgr.Instance ().invadd2equip (_data);
	}

	public void equipoff(ObjItem _data){
		int eqid = _data._Items._PartId ;
		if (GameResources.Instance()._EquipSolt [eqid].childCount > 0) {
			ObjItem _curequip = GameResources.Instance()._EquipSolt [eqid].GetComponentInChildren<ObjItem> ();
			//背包有此物品  就把槽内的gameobject 销毁  增加背包内物品的数量
			if(gamedbmgr.Instance ().equipadd2inv (_curequip,1))
				GameObject.Destroy (_curequip.gameObject);
		}
	}

	private void _init_inventory(List<Items> _db){
		
		GameResources.Instance()._InventoryPanel.GetComponent<GridLayoutGroup> ().cellSize = GameResources._v2_70;
		for (int i = 0; i < _db.Count ; ++i) {
			if (_db [i]._NStat < 0) {
				gamedbmgr.Instance ()._inventory.Add (gamedbmgr.Instance()._uiitem_generate (null,PARENT_PANEL.INVENTORY,_db[i]));
			} else{
				if (_db [i]._NId > 0) {
					GameResources.Instance ()._GameMgr._AIPlayer.moduelequip (gamedbmgr.Instance()._uiitem_generate (null,PARENT_PANEL.EQSOLT,_db[i])._Items);
				}
			}
		}
	}		
}
