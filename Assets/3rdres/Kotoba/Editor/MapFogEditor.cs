using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapFogEditor : Editor
{
    public static List<GameObject> cubes = new List<GameObject>();
    [MenuItem("Window/填充黑块")]
    public static void MapFog()
    {
        GameObject[] cube = Selection.gameObjects;
        if (cube == null || cube.Length < 2)
        {
            EditorUtility.DisplayDialog("选择地图左上角和右下角的地图元件来", "提示", "确定");
            return;
        }
        Create(cube[0].transform.position, cube[1].transform.position);
    }

    public static void Create(Vector3 pos1, Vector3 pos2)
    {
        GameObject obj = new GameObject();
        obj.name = "fogRoot";
        obj.transform.position = Vector3.zero;

        GameObject obj2 = new GameObject();
        obj2.transform.parent = obj.transform;
        obj2.AddComponent<MeshCombine>();
        obj2.name = "bottom";
        obj2.transform.position = Vector3.zero;

        GameObject obj3 = new GameObject();
        obj3.transform.parent = obj.transform;
        obj3.name = "top";
        obj3.transform.position = Vector3.zero;

        //
        GameObject root = GameObject.Find("LayoutRoot");
        List<Transform> tempList1 = new List<Transform>();
        List<Transform> tempList2 = new List<Transform>();
        MeshRenderer[] mesh = root.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < mesh.Length; i++)
        {
            if (mesh[i].name.Contains("FloortileBasicSmall"))
                tempList1.Add(mesh[i].transform);

            if (mesh[i].name.Contains("FloortileBasicBig"))
                tempList2.Add(mesh[i].transform);
        }
        //逐行铺平
        Vector3 scale = GameObject.Find("cloneSmall").transform.localScale;


        float leftx = pos1.x;
        float rightx = pos2.x;
        float top = pos1.z;
        float bottom = pos2.z;
        float width = scale.x;

        float hCount = (rightx - leftx) * 1.0f / width;
        float vCount = (top - bottom) * 1.0f / width;

        hCount = Mathf.Abs(hCount) + 1;
        vCount = Mathf.Abs(vCount) + 1;

        //GameObject fog = GameObject.Instantiate(GameObject.Find("cloneSmall").gameObject);
        //fog.transform.rotation = Quaternion.identity;
        //fog.transform.parent = obj.transform;
        //fog.transform.position = pos1 + new Vector3(width, 0, width);
        //fog.gameObject.SetActive(true);
        //fog.GetComponent<MeshRenderer>().enabled = true;

        //return;

        for (int i = 0; i < hCount; i++)
        {
            for (int k = 0; k < vCount; k++)
            {
                Vector3 initPosition = new Vector3(pos1.x + width * i, 0, pos1.z - width * k);
                bool canCreate = CheckSmall(tempList1, initPosition);
                if (canCreate)
                {
                    canCreate = CheckBig(tempList2, initPosition);
                }
                if (!canCreate)
                    continue;

                for (int n = 0; n < 2; n++)
                {
                    GameObject fog = GameObject.Instantiate(GameObject.Find("cloneSmall").gameObject);
                    fog.transform.rotation = Quaternion.identity;
                    if (n == 0)
                    {
                        fog.transform.parent = obj2.transform;
                        fog.transform.localScale = scale;
                    }
                    else
                    {
                        fog.transform.parent = obj3.transform;
                        fog.transform.localScale = scale + Vector3.up * 3;
                    }

                    fog.transform.position = initPosition;
                    fog.gameObject.SetActive(true);
                    fog.GetComponent<MeshRenderer>().enabled = true;

                }

            }
        }
        Debug.LogError("临时生成");
    }
    public static bool CheckSmall(List<Transform> list, Vector3 pos)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (Vector3.Distance(list[i].position, pos) < 3 * 0.5f)
                return false;
        }
        return true;
    }
    public static bool CheckBig(List<Transform> list, Vector3 pos)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (Vector3.Distance(list[i].position, pos) < 6 * 0.5f)
                return false;
        }
        return true;
    }
}
