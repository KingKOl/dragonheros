using UnityEngine;
using System.IO;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;

public class UGUISprite2Prefab {
	[MenuItem("Custom/Sprite2Prefab")]
	static private void MakeAtlas()
	{
		string spriteDir = Application.dataPath +"/Resources/UIFrame/UISprite";

		if(!Directory.Exists(spriteDir)){
			Directory.CreateDirectory(spriteDir);
		}

		DirectoryInfo rootDirInfo = new DirectoryInfo (Application.dataPath +"/BarverCave/Texture");
		foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories()) {
			foreach (FileInfo pngFile in dirInfo.GetFiles("*.*",SearchOption.AllDirectories)) {
				if (pngFile.Extension.Contains ("png") || pngFile.Extension.Contains ("jpg")) 
				{
					string allPath = pngFile.FullName;
					string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
					Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(assetPath);
					GameObject go = new GameObject(sprite.name);
					go.AddComponent<SpriteRenderer>().sprite = sprite;
					allPath = spriteDir+"/"+sprite.name+".prefab";
					string prefabPath = allPath.Substring(allPath.IndexOf("Assets"));
					PrefabUtility.CreatePrefab(prefabPath,go);
					GameObject.DestroyImmediate(go);	
				}
			}
		}	
	}
}
#endif