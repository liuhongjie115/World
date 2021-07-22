using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResLoad
{
    private static Dictionary<string, GameObject> poolList = new Dictionary<string, GameObject>();


    public static GameObject Load(string path)
    {
        GameObject go = null;
        if (poolList.ContainsKey(path))
        {
            go = poolList[path];
        }
        else
        {
            GameObject prefab = Resources.Load(path, typeof(GameObject)) as GameObject;
            poolList.Add(path, prefab);
            go = prefab;
        }
        GameObject instance = GameObject.Instantiate(go);
        return instance;
    }
}
