using System.Linq;
using UnityEngine;

public class Voxcel : MonoBehaviour
{
    private MeshFilter _meshFilter;

    void Start()
    {
        this._meshFilter = GetComponent<MeshFilter>();

        Mesh mesh = new Mesh
        {
            vertices = Vertex.All()
            .Select(vertex => vertex.Position)
            .ToArray(),
            triangles = VoxcelSurface.All()
            .SelectMany(surface => surface.Vertices)
            .Select(vertex => vertex.Id)
            .ToArray()
        };
        mesh.RecalculateNormals();

        this._meshFilter.mesh = mesh;
    }
}
