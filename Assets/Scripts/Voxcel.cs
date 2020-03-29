using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Voxcel
{
    /**
     * テクスチャをどの向きにはるかを定義する配列
     * このクラスに登録する2つの三角形は以下のテクスチャの向きに留意して登録する
     */
    public static readonly ICollection<Vector2> Uvs = new List<Vector2>
    {
        new Vector2(0, 0),
        new Vector2(0, 1),
        new Vector2(1, 0),
        new Vector2(1, 0),
        new Vector2(0, 1),
        new Vector2(1, 1)
    };

    public Vector3 Position { get; set; }
    public Dictionary<VoxcelSurfaceDirection, VoxcelSurface> Surfaces = new Dictionary<VoxcelSurfaceDirection, VoxcelSurface>();

    public Voxcel(): this(new Vector3()) {}

    public Voxcel(Vector3 position)
    {
        this.Position = position;
        this.Surfaces = Enum.GetValues(typeof(VoxcelSurfaceDirection))
            .Cast<VoxcelSurfaceDirection>()
            .ToList()
            .Select(direction => new
            {
                Direction = direction,
                Offsets = direction.GetVertexOffsets()
            })
            .ToDictionary(
                directionOffsets => directionOffsets.Direction,
                directionOffsets => new VoxcelSurface(
                    directionOffsets.Offsets
                        .Select(offset => new VoxcelVertex(position, offset))
                        .ToList()
                )
            );
    }

    public ICollection<Vector3> GetVertices()
    {
        return Enum.GetValues(typeof(VoxcelSurfaceDirection))
            .Cast<VoxcelSurfaceDirection>()
            .ToList()
            .SelectMany(direction => this.Surfaces[direction].Vertices)
            .Select(vertex => vertex.GetPosition())
            .ToList();
    }

    public int GetSurfacesCount()
    {
        return 6;
    }

    public int GetVerticesCount()
    {
        // 6方向 × 6頂点のため常に36
        return 36;
    }
}
