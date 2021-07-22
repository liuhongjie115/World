using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    List<BaseBox> boxList = new List<BaseBox>();


    private void Start()
    {
        InitPanel();
    }

    private void Update()
    {
        
    }


    private void InitPanel()
    {
        Vector3 startPos = new Vector3(0, 0, 0);
        float scale = 3;
        int width = 100;
        int length = 100;
        for(int i=0;i<width;i++)
        {
            for(int j=0;j<length;j++)
            {
                GameObject cube = ResLoad.Load("ACore/MeshGenerate/BaseBox");
                cube.transform.position = new Vector3(i, 0, j) * scale;
                BaseBox baseBox = cube.GetComponent<BaseBox>();
                baseBox.scale = scale;
                boxList.Add(baseBox);
               
            }
        }
    }
}
