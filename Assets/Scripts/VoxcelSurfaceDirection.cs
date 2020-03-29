using System.Collections.Generic;

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
    private static Dictionary<VoxcelSurfaceDirection, ICollection<VertexOffset>> _offsetMap = new Dictionary<VoxcelSurfaceDirection, ICollection<VertexOffset>>
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

    public static ICollection<VertexOffset> GetVertexOffsets(this VoxcelSurfaceDirection surface)
    {
        return _offsetMap[surface];
    }
}