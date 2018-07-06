using UnityEngine;
using System.IO;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;

public class FBX2Prefab {
	[MenuItem("Custom/FBX2Prefab")]
	static private void MakePrefab(){
		string mapFbxDir = Application.dataPath +"/MapFbx/Prefabs";
		string _modpath = "" , _prefabdir = "";
		if(!Directory.Exists(mapFbxDir)){
			Directory.CreateDirectory(mapFbxDir);
		}

		DirectoryInfo rootDirInfo = new DirectoryInfo (Application.dataPath +"/MapFbx/Moduels");
		foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories()) {
			foreach (FileInfo fbxFile in dirInfo.GetFiles("*.*",SearchOption.AllDirectories)) {
				if (fbxFile.Extension.Contains ("fbx") || fbxFile.Extension.Contains ("FBX")) 
				{
					_modpath = mapFbxDir + fbxFile.DirectoryName.Substring(fbxFile.DirectoryName.LastIndexOf('\\')); 
					if(!Directory.Exists(_modpath)){
						Directory.CreateDirectory(_modpath);
					}
					string assetPath = fbxFile.FullName.Substring(fbxFile.FullName.IndexOf("Assets"));
					GameObject _obj = AssetDatabase.LoadAssetAtPath<GameObject> (assetPath);
					GameObject _cloe = GameObject.Instantiate<GameObject>(_obj);
					_prefabdir = _modpath + '/' + fbxFile.Name.Replace ("fbx", "prefab");
					_prefabdir = _prefabdir.Substring(_prefabdir.IndexOf("Assets"));

					Object _prefab = PrefabUtility.CreateEmptyPrefab (_prefabdir);
					GameObject _pre = PrefabUtility.ReplacePrefab (_cloe,_prefab);
					GameObject.DestroyImmediate (_cloe);
					Debug.Log (_prefabdir);

				}
			}
		}
	}
}
#endif