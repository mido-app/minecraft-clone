using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public static readonly int ChunkWidth  = 16;
    public static readonly int ChunkHeight = 128;
    public static readonly int ChunkDepth  = 16;

    /** テクスチャファイルの1辺にいくつのテクスチャがあるか */
    public static readonly int TextureAtlasSize = 128;

    /** 0-1に正規化された1ブロックのサイズ */
    public static readonly float NomalizedBlockTexureSize = 1.0f / (float)TextureAtlasSize;

    private World _world;
    private MeshFilter _meshFilter;

    private readonly IDictionary<Vector3, Voxcel> _voxcelDict = new Dictionary<Vector3, Voxcel>();

    void Start()
    {
        this._world = GameObject.Find("World").GetComponent<World>();
        this._meshFilter = GetComponent<MeshFilter>();
        Enumerable.Range(0, ChunkWidth).ToList().ForEach(x =>
        {
            Enumerable.Range(0, ChunkHeight).ToList().ForEach(y =>
            {
                Enumerable.Range(0, ChunkDepth).ToList().ForEach(z =>
                {
                    this.AddVoxcel(this._world.GetBlockTypeById(BlockTypeId.Dirt), new Vector3(x, y, z));
                });
            });
        });
        this.UpdateVoxcelSurfaceVisibilities();
        this.CreateMesh();
    }

    void AddVoxcel(BlockType blockType, Vector3 position)
    {
        this._voxcelDict.Add(position, new Voxcel(blockType, position));
    }

    void CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = this._voxcelDict
            .SelectMany(voxcel => voxcel.Value.GetVisibleVertices())
            .ToArray();
        mesh.triangles = Enumerable.Range(
                0,
                this._voxcelDict
                    .Select(voxcel => voxcel.Value.GetVisibleSurfacesCount())
                    .Sum()
            )
            .SelectMany(surfaceIndex => VoxcelSurface
                .TriangleOrder
                .Select(vertexIndex => surfaceIndex * 4 + vertexIndex)
            )
            .ToArray();
        mesh.uv = this._voxcelDict
            .SelectMany(voxcel => voxcel.Value.GetVisibleSurfaces())
            .SelectMany(surface => this._world.texure.GetUvs((int)surface.TextureId))
            .ToArray();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        this._meshFilter.mesh = mesh;
    }

    void UpdateVoxcelSurfaceVisibilities()
    {
        this._voxcelDict.ToList().ForEach(voxcelEntry =>
        {
            Enum.GetValues(typeof(VoxcelSurfaceDirection))
                .Cast<VoxcelSurfaceDirection>()
                .ToList()
                .ForEach(direction =>
                {
                    voxcelEntry.Value.SetSurfaceVisibility(
                        direction,
                        !this.ExistVoxcelAt(voxcelEntry.Value.Position + direction.GetNomalVector3())
                    );
                });
        });
    }

    bool ExistVoxcelAt(Vector3 position)
    {
        int x = Mathf.FloorToInt(position.x);
        int y = Mathf.FloorToInt(position.y);
        int z = Mathf.FloorToInt(position.z);

        return this._voxcelDict.ContainsKey(new Vector3(x, y, z));
    }
}
