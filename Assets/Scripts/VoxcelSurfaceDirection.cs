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
                VertexOffset.FrontBottomLeft,
                VertexOffset.FrontTopLeft,
                VertexOffset.FrontBottomRight,
                VertexOffset.FrontTopRight
            }
        },
        {
            VoxcelSurfaceDirection.Back,
            new List<VertexOffset>
            {
                VertexOffset.BackBottomRight,
                VertexOffset.BackTopRight,
                VertexOffset.BackBottomLeft,
                VertexOffset.BackTopLeft
            }
        },
        {
            VoxcelSurfaceDirection.Top,
            new List<VertexOffset>
            {
                VertexOffset.FrontTopLeft,
                VertexOffset.BackTopLeft,
                VertexOffset.FrontTopRight,
                VertexOffset.BackTopRight
            }
        },
        {
            VoxcelSurfaceDirection.Bottom,
            new List<VertexOffset>
            {
                VertexOffset.BackBottomLeft,
                VertexOffset.FrontBottomLeft,
                VertexOffset.BackBottomRight,
                VertexOffset.FrontBottomRight
            }
        },
        {
            VoxcelSurfaceDirection.Left,
            new List<VertexOffset>
            {
                VertexOffset.BackBottomLeft,
                VertexOffset.BackTopLeft,
                VertexOffset.FrontBottomLeft,
                VertexOffset.FrontTopLeft
            }
        },
        {
            VoxcelSurfaceDirection.Right,
            new List<VertexOffset>
            {
                VertexOffset.FrontBottomRight,
                VertexOffset.FrontTopRight,
                VertexOffset.BackBottomRight,
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