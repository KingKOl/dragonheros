using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;

public class GameResources : Singleton<GameResources> {

	public static Vector2 _v2_100 = new Vector2 (100,100);
	public static Vector2 _v2_70 = new Vector2 (70,70);
	public static Vector2 _v2_64 = new Vector2 (64,64);

	public GameMgr _GameMgr;
	public GameObject _ObjPlayer;
	public GameObject _ObjJoyStick;
	public GameObject _ObjUIPanel;

	public Transform _InventoryPanel;
	public Transform _EquipmentPanel;
	public List<Transform> _EquipSolt;

	public Transform _SkillPanel;

	private GameResources(){
		_GameMgr = GameObject.FindGameObjectWithTag ("GameMgr").GetComponent<GameMgr> ();
		_ObjPlayer = GameObject.FindGameObjectWithTag ("Player");
		_ObjJoyStick = GameObject.FindGameObjectWithTag ("JoyStick");
		_ObjUIPanel = GameObject.FindGameObjectWithTag ("UIInfoPanel");
		_EquipSolt = new List<Transform> ();
	}

	public static Sprite loadSprite(string spriteName){
		#if USE_ASSETBUNDLE
		if(assetbundle == null)
		assetbundle = AssetBundle.CreateFromFile(Application.streamingAssetsPath +"/Main.assetbundle");
		return assetbundle.Load(spriteName) as Sprite;
		#else
		return Resources.Load<GameObject>("UIFrame/UISprite/" + spriteName).GetComponent<SpriteRenderer>().sprite;
		#endif	
	}
	public static GameObject loadGameObject(int id){
		#if USE_ASSETBUNDLE
		if(assetbundle == null)
		assetbundle = AssetBundle.CreateFromFile(Application.streamingAssetsPath +"/Main.assetbundle");
		return assetbundle.Load(spriteName) as Sprite;
		#else
		if(!ItemsRefer.Instance()._Items.ContainsKey(id))
			return null;
		//if(id > (int)TBCType.Equip)
		return Resources.Load<GameObject>(ItemsRefer.Instance()._Items[id]);
		#endif	
	}
}
