using System.Collections.Generic;
using UnityEngine;

public enum VoxcelSurfaceDirection
{
    Front,
    Back,
    Top,
    Bottom,
    Left,
    Right
}

public static class VoxcelSurfaceDirectionExtension
{
    private static readonly Dictionary<VoxcelSurfaceDirection, ICollection<VertexOffset>> _offsetDict= new Dictionary<VoxcelSurfaceDirection, ICollection<VertexOffset>>
    {
        {
            VoxcelSurfaceDirection.Front,
            new List<VertexOffset>
            {
                // 1つ目の三角形の頂点オフセット
                VertexOffset.FrontBottomLeft,
                VertexOffset.FrontTopLeft,
                VertexOffset.FrontBottomRight,

                // 2つ目の三角形の頂点オフセット
                VertexOffset.FrontBottomRight,
                VertexOffset.FrontTopLeft,
                VertexOffset.FrontTopRight
            }
        },
        {
            VoxcelSurfaceDirection.Back,
            new List<VertexOffset>
            {
                // 1つ目の三角形の頂点オフセット
                VertexOffset.BackBottomRight,
                VertexOffset.BackTopRight,
                VertexOffset.BackBottomLeft,

                // 2つ目の三角形の頂点オフセット
                VertexOffset.BackBottomLeft,
                VertexOffset.BackTopRight,
                VertexOffset.BackTopLeft
            }
        },
        {
            VoxcelSurfaceDirection.Top,
            new List<VertexOffset>
            {
                // 1つ目の三角形の頂点オフセット
                VertexOffset.FrontTopLeft,
                VertexOffset.BackTopLeft,
                VertexOffset.FrontTopRight,

                // 2つ目の三角形の頂点オフセット
                VertexOffset.FrontTopRight,
                VertexOffset.BackTopLeft,
                VertexOffset.BackTopRight
            }
        },
        {
            VoxcelSurfaceDirection.Bottom,
            new List<VertexOffset>
            {
                // 1つ目の三角形の頂点オフセット
                VertexOffset.BackBottomLeft,
                VertexOffset.FrontBottomLeft,
                VertexOffset.BackBottomRight,

                // 2つ目の三角形の頂点オフセット
                VertexOffset.BackBottomRight,
                VertexOffset.FrontBottomLeft,
                VertexOffset.FrontBottomRight
            }
        },
        {
            VoxcelSurfaceDirection.Left,
            new List<VertexOffset>
            {
                // 1つ目の三角形の頂点オフセット
                VertexOffset.BackBottomLeft,
                VertexOffset.BackTopLeft,
                VertexOffset.FrontBottomLeft,

                 // 2つ目の三角形の頂点オフセット
                VertexOffset.FrontBottomLeft,
                VertexOffset.BackTopLeft,
                VertexOffset.FrontTopLeft
            }
        },
        {
            VoxcelSurfaceDirection.Right,
            new List<VertexOffset>
            {
                // 1つ目の三角形の頂点オフセット
                VertexOffset.FrontBottomRight,
                VertexOffset.FrontTopRight,
                VertexOffset.BackBottomRight,

                // 2つ目の三角形の頂点オフセット
                VertexOffset.BackBottomRight,
                VertexOffset.FrontTopRight,
                VertexOffset.BackTopRight
            }
        },
    };

    private static readonly Dictionary<VoxcelSurfaceDirection, Vector3> _normalDict = new Dictionary<VoxcelSurfaceDirection, Vector3> {
        { VoxcelSurfaceDirection.Front, new Vector3(0, 0, -1) },
        { VoxcelSurfaceDirection.Back, new Vector3(0, 0, 1) },
        { VoxcelSurfaceDirection.Top, new Vector3(0, 1, 0) },
        { VoxcelSurfaceDirection.Bottom, new Vector3(0, -1, 0) },
        { VoxcelSurfaceDirection.Left, new Vector3(-1, 0, 0) },
        { VoxcelSurfaceDirection.Right, new Vector3(1, 0, 0) }
    };

    public static ICollection<VertexOffset> GetVertexOffsets(this VoxcelSurfaceDirection surface)
    {
        return _offsetDict[surface];
    }

    public static Vector3 GetNomalVector3(this VoxcelSurfaceDirection direction)
    {
        return _normalDict[direction];
    }
}