using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handmade : MonoBehaviour
{
    private GameObject go = null;

    private MeshFilter mf = null;
    private MeshRenderer mr = null;

    private void Start()
    {
        go = new GameObject("Character");
        //go.name = "Character";

        mf = go.AddComponent<MeshFilter>();
        mf.mesh = BuildMesh();

        mr = go.AddComponent<MeshRenderer>();
        //mr.material = CreateMaterial();
        mr.materials = new Material[]
        {
            CreateMaterial()
        };

        go.AddComponent<Jump>();
    }

    private void Update()
    {
        Debug.DrawLine(
            transform.position,
            transform.position + mf.mesh.normals[0],
            Color.red);
    }

    private Mesh BuildMesh()
    {
        Mesh mesh = new Mesh();
        mesh.name = "HandmadeMesh";

        // 0 -- 1
        // |    |
        // 2 -- 3
        // Vertex Buffer
        Vector3[] vertices =
        {
            new Vector3(-0.5f, 1f, 0f),
            new Vector3(.5f, 1f, 0f),
            new Vector3(-0.5f, 0f, 0f),
            new Vector3(0.5f, 0f, 0f)
        };
        mesh.vertices = vertices;

        // Index Buffer
        int[] indices =
        {
            0, 1, 2,
            2, 1, 3
        };
        mesh.triangles = indices;

        // Backface Culling
        // CW, CCW
        Vector3 vecA =
            vertices[indices[0]] -
            vertices[indices[2]];
        Vector3 vecB =
            vertices[indices[1]] -
            vertices[indices[2]];
        Vector3 vecN = Vector3.Cross(vecA, vecB);
        vecN.Normalize();

        Vector3[] normals =
        {
            vecN, vecN, vecN, vecN
        };
        mesh.normals = normals;

        Vector2[] uvs =
        {
            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(0f, 0f),
            new Vector2(1f, 0f)
        };
        mesh.uv = uvs;

        return mesh;
    }

    private Material CreateMaterial()
    {
        Material mat =
            new Material(Shader.Find("Standard"));
        mat.name = "HandmadeMaterial";

        Texture2D tex =
            Resources.Load<Texture2D>(
                "Textures\\FemaleKnight");
        mat.mainTexture = tex;

        return mat;
    }
}
