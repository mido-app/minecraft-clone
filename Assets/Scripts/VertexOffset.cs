using System.Collections.Generic;
using UnityEngine;

public class VertexOffset
{
    public static VertexOffset FrontTopLeft = new VertexOffset (new Vector3(0, 1, 0));
    public static VertexOffset FrontTopRight = new VertexOffset(new Vector3(1, 1, 0));
    public static VertexOffset FrontBottomLeft = new VertexOffset(new Vector3(0, 0, 0));
    public static VertexOffset FrontBottomRight = new VertexOffset(new Vector3(1, 0, 0));
    public static VertexOffset BackTopLeft = new VertexOffset(new Vector3(0, 1, 1));
    public static VertexOffset BackTopRight = new VertexOffset(new Vector3(1, 1, 1));
    public static VertexOffset BackBottomLeft = new VertexOffset(new Vector3(0, 0, 1));
    public static VertexOffset BackBottomRight = new VertexOffset(new Vector3(1, 0, 1));

    private static readonly ICollection<VertexOffset> _all = new List<VertexOffset>
    {
        FrontTopLeft,
        FrontTopRight,
        FrontBottomLeft,
        FrontBottomRight,
        BackTopLeft,
        BackTopRight,
        BackBottomLeft,
        BackBottomRight
    };

    public static ICollection<VertexOffset> All()
    {
        return _all;
    }

    public Vector3 Position { get; }

    private VertexOffset(Vector3 position)
    {
        this.Position = position;
    }
}
