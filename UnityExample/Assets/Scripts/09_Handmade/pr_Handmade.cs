using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pr_Handmade : MonoBehaviour
{
    private GameObject go = null;
    private MeshFilter mf = null;
    private MeshRenderer mr = null;

    private void Start()
    {
        go = new GameObject("Character");
        mf = go.AddComponent<MeshFilter>();
        mf.mesh = BuildMesh();
    }
    private void Update()
    {
        
    }
    private Mesh BuildMesh()
    {
        Mesh mesh = new Mesh();
        mesh.name = "HandmadeMesh";
        Vector3[] vertices =
        {
            new Vector3(-0.5f, 1f, 0f),
            new Vector3(.5f, 1f, 0f),
            new Vector3(-0.5f, 0f,0f),
            new Vector3(0.5f, 0f, 0f)
        };
        mesh.vertices = vertices;

        int[] indices =
        {
            0,1,2,2,1,3
        };
        mesh.triangles = indices;
        return mesh;
    }
    private Material CreateMaterial()
    {
        Material mat = new Material(Shader.Find("Standard"));

        return mat;
    }
}

