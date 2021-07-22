using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorResLoad
{
    private static Dictionary<string, GameObject> poolList = new Dictionary<string, GameObject>();
    private static string url = "assets/Tools/prefabs/";


    public static GameObject Load(string name)
    {
        GameObject go = null;
        if (poolList.ContainsKey(name))
        {
            go = poolList[name];
        }
        else
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath(url + name, typeof(GameObject)) as GameObject;
            poolList.Add(name, prefab);
            go = prefab;
        }
        GameObject instance = GameObject.Instantiate(go);
        return instance;
    }
}
