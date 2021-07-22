using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer),typeof(MeshFilter))]
public class BaseBox : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;

    public Material material;

    public float scale = 1;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = material;
        meshFilter = GetComponent<MeshFilter>();
        GenerateMesh();
    }

    private void GenerateMesh()
    {
        Mesh mesh = new Mesh();
        List<Vector3> vertexList = new List<Vector3>();
        for(int i=0;i<VertexUtil.vertexs.Length;i++)
        {
            vertexList.Add(VertexUtil.vertexs[i] * scale);
        }
        mesh.vertices = vertexList.ToArray();
        List<int> trigles = new List<int>();
        trigles.Add(3); trigles.Add(2); trigles.Add(1); trigles.Add(1); trigles.Add(0); trigles.Add(3);
        trigles.Add(0); trigles.Add(4); trigles.Add(3); trigles.Add(4); trigles.Add(7); trigles.Add(3);
        trigles.Add(4); trigles.Add(5); trigles.Add(7); trigles.Add(5); trigles.Add(6); trigles.Add(7);
        trigles.Add(5); trigles.Add(1); trigles.Add(6); trigles.Add(1); trigles.Add(2); trigles.Add(6);
        trigles.Add(1); trigles.Add(5); trigles.Add(4); trigles.Add(4); trigles.Add(0); trigles.Add(1);
        trigles.Add(3); trigles.Add(7); trigles.Add(2); trigles.Add(7); trigles.Add(6); trigles.Add(2);
        mesh.triangles = trigles.ToArray();
        mesh.RecalculateBounds();
        meshFilter.sharedMesh = mesh;
    }
}
