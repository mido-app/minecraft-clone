using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public static readonly int ChunkWidth  = 10;
    public static readonly int ChunkHeight = 10;
    public static readonly int ChunkDepth  = 10;

    private MeshFilter _meshFilter;

    private readonly ICollection<Voxcel> _voxcels = new List<Voxcel>();

    void Start()
    {
        this._meshFilter = GetComponent<MeshFilter>();
        Enumerable.Range(0, ChunkWidth).ToList().ForEach(x =>
        {
            Enumerable.Range(0, ChunkHeight).ToList().ForEach(y =>
            {
                Enumerable.Range(0, ChunkDepth).ToList().ForEach(z =>
                {
                    this.AddVoxcel(new Vector3(x, y, z));
                });
            });
        });
        this.CreateMesh();
    }

    void AddVoxcel(Vector3 position)
    {
        this._voxcels.Add(new Voxcel(position));
    }

    void CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = this._voxcels
            .SelectMany(voxcel => voxcel.GetVertices())
            .ToArray();
        mesh.triangles = Enumerable.Range(
                0,
                this._voxcels
                    .Select(voxcel => voxcel.GetVerticesCount())
                    .Sum()
            )
            .ToArray();
        mesh.uv = Enumerable.Range(
                0,
                this._voxcels
                    .Select(voxcel => voxcel.GetSurfacesCount())
                    .Sum()
            )
            .SelectMany(_ => Voxcel.Uvs)
            .ToArray();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        this._meshFilter.mesh = mesh;
    }
}
