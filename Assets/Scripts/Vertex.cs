using System.Collections.Generic;
using UnityEngine;

public class Vertex
{
    public static Vertex FrontTopLeft = new Vertex (0, new Vector3(0, 1, 0));
    public static Vertex FrontTopRight = new Vertex(1, new Vector3(1, 1, 0));
    public static Vertex FrontBottomLeft = new Vertex(2, new Vector3(0, 0, 0));
    public static Vertex FrontBottomRight = new Vertex(3, new Vector3(1, 0, 0));
    public static Vertex BackTopLeft = new Vertex(4, new Vector3(0, 1, 1));
    public static Vertex BackTopRight = new Vertex(5, new Vector3(1, 1, 1));
    public static Vertex BackBottomLeft = new Vertex(6, new Vector3(0, 0, 1));
    public static Vertex BackBottomRight = new Vertex(7, new Vector3(1, 0, 1));

    private static readonly ICollection<Vertex> _all = new List<Vertex>
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

    public static ICollection<Vertex> All()
    {
        return _all;
    }

    public int Id { get; }
    public Vector3 Position { get; }

    private Vertex(int id, Vector3 position)
    {
        this.Id = id;
        this.Position = position;
    }
}
