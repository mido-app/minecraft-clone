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
            vertices = VoxcelSurface.All()
                .SelectMany(surface => surface.Vertices)
                .Select(vertex => vertex.Position)
                .ToArray(),
            triangles = Enumerable.Range(
                    0,
                    VoxcelSurface.All().SelectMany(surface => surface.Vertices).Count()
                )
                .ToArray(),
            uv = VoxcelSurface.All()
                .SelectMany(_ => VoxcelSurface.Uvs)
                .ToArray()
        };
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        this._meshFilter.mesh = mesh;
    }
}
