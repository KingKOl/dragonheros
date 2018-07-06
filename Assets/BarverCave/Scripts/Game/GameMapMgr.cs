using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameMapMgr {
	
	public List<Vector3> _spwans;
	public List<int> _spwaneds;

	private GameObject _mapitem;
	private GameObject MazeWall;
	private GameObject MapPanel;
	private GameObject MapElements;

	private Vector3 MapCellSize = new Vector3(2.5f,2.5f,2.5f);

	// Use this for initialization
	public void init () {
		string _mapfilepath = ""; 
		string _map="1.txt";
		System.IO.MemoryStream _ms = null;
		try{
			/*
			if (Application.platform == RuntimePlatform.Android) {
				
				_mapfilepath = string.Format ("jar:file://{0}!/assets/{1}", Application.dataPath, _map);

				WWW loadDB = new WWW (_mapfilepath);  
				while (!loadDB.isDone) {
					System.Threading.Thread.Sleep (100);
				}  
				_fs = new System.IO.MemoryStream(loadDB.bytes);

			} else if (Application.platform == RuntimePlatform.WindowsEditor) {
				
				_mapfilepath = string.Format("{0}/StreamingAssets/{1}",Application.dataPath,_map); 
				_fs = new System.IO.FileStream(_mapfilepath,System.IO.FileMode.Open,System.IO.FileAccess.Read);

			}*/
			TextAsset _ta = (TextAsset)Resources.Load("_Data/1");
			_ms = new System.IO.MemoryStream(_ta.bytes);

		}catch(Exception e){
			Debug.Log(e.ToString());
		}

		_mapitem = GameObject.Instantiate(GameResources.loadGameObject (4000)) as GameObject;

		MapPanel = new GameObject ("MapPanel");
		MapPanel.transform.position = Vector3.zero;

		MazeWall = new GameObject ("MazeWall");
		MazeWall.transform.SetParent (MapPanel.transform);
		MazeWall.transform.localPosition = Vector3.zero;

		MapElements = new GameObject ("MapElements");
		MapElements.transform.SetParent (MapPanel.transform);
		MapElements.transform.localPosition = Vector3.zero;

		_spwans = new List<Vector3> ();
		_spwaneds = new List<int> ();

		using (System.IO.StreamReader _sr = new System.IO.StreamReader (_ms)) {
			string _line = "";
			char[] _space = { ' ' };
			int _row = 0;
			while ((_line = _sr.ReadLine ()) != null) {
				string[] _vec = _line.Split (_space , System.StringSplitOptions.RemoveEmptyEntries);
				if (_vec.Length < 5)
					continue;
				for (int i = 0; i < _vec.Length; ++i) {
					GameObject _obj = null;
					if (_vec [i] == "2") {
						_obj = GameObject.CreatePrimitive(PrimitiveType.Cube) as GameObject;
						_obj.transform.SetParent (MazeWall.transform);
						_obj.transform.localPosition = new Vector3 (i, 1 , -_row);
					}
					if (_vec [i] == "0") {
						_obj = GameObject.Instantiate (_mapitem) as GameObject;
						_obj.transform.SetParent (MapElements.transform);
						_obj.transform.localPosition = new Vector3 (i, 0 , -_row);

						_spwans.Add (new Vector3(_obj.transform.position.x * MapCellSize.x,
							_obj.transform.position.y * MapCellSize.y,_obj.transform.position.z * MapCellSize.z));
					}
				}
				_row++;

			}
		}

		WallCollider ();

		MapPanel.transform.localScale = MapCellSize;
	}

	void WallCollider(){
		
		MeshFilter[] _meshFilters = MazeWall.GetComponentsInChildren<MeshFilter> ();
		CombineInstance[] _combine = new CombineInstance[_meshFilters.Length];

		for (int i = 0; i < _meshFilters.Length; i++)                            
		{
			_combine[i].mesh = _meshFilters[i].sharedMesh;
			_combine[i].transform = _meshFilters[i].transform.localToWorldMatrix;
			GameObject.Destroy (_meshFilters[i].gameObject);
		}

		MeshFilter _wallmf = MazeWall.AddComponent<MeshFilter> ();
		_wallmf.mesh = new Mesh ();
		_wallmf.mesh.CombineMeshes (_combine);
		MazeWall.AddComponent<MeshCollider>();
	}

	public Vector3 getspwanpoint (){
		int _id = 0;
		do{
			_id = UnityEngine.Random.Range (0,_spwans.Count);
		}while(_spwaneds.Contains(_id));

		_spwaneds.Add (_id);
		return _spwans[_id];
	}
}
