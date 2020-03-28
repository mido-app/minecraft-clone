using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ボクセルの面を表すクラス
 * ボクセルの面は2つの3角形から成る
 */
public class VoxcelSurface {

    public static ICollection<VoxcelSurface> All()
    {
        return new List<VoxcelSurface> {
            Top,
            Bottom,
            Front,
            Back,
            Left,
            Right
        };
    }

    public static VoxcelSurface Top = new VoxcelSurface(
        new Triangle(
            Vertex.FrontTopLeft,
            Vertex.BackTopLeft,
            Vertex.FrontTopRight
        ),
        new Triangle(
            Vertex.FrontTopRight,
            Vertex.BackTopLeft,
            Vertex.BackTopRight
        )
    );

    public static VoxcelSurface Bottom = new VoxcelSurface(
        new Triangle(
            Vertex.FrontBottomLeft,
            Vertex.FrontBottomRight,
            Vertex.BackBottomLeft
        ),
        new Triangle(
            Vertex.FrontBottomRight,
            Vertex.BackBottomRight,
            Vertex.BackBottomLeft
        )
    );

    public static VoxcelSurface Front = new VoxcelSurface(
        new Triangle(
            Vertex.FrontTopLeft,
            Vertex.FrontTopRight,
            Vertex.FrontBottomLeft
        ),
        new Triangle(
            Vertex.FrontBottomLeft,
            Vertex.FrontTopRight,
            Vertex.FrontBottomRight
        )
    );

    public static VoxcelSurface Back = new VoxcelSurface(
        new Triangle(
            Vertex.BackTopLeft,
            Vertex.BackBottomLeft,
            Vertex.BackTopRight
        ),
        new Triangle(
            Vertex.BackBottomLeft,
            Vertex.BackBottomRight,
            Vertex.BackTopRight
        )
    );

    public static VoxcelSurface Left = new VoxcelSurface(
        new Triangle(
            Vertex.BackTopLeft,
            Vertex.FrontTopLeft,
            Vertex.BackBottomLeft
        ),
        new Triangle(
            Vertex.BackBottomLeft,
            Vertex.FrontTopLeft,
            Vertex.FrontBottomLeft
        )
    );

    public static VoxcelSurface Right = new VoxcelSurface(
        new Triangle(
            Vertex.FrontTopRight,
            Vertex.BackTopRight,
            Vertex.FrontBottomRight
        ),
        new Triangle(
            Vertex.FrontBottomRight,
            Vertex.BackTopRight,
            Vertex.BackBottomRight
        )
    );

    private readonly Triangle _triangle1;
    private readonly Triangle _triangle2;

    /**
     * 面の描画に必要な頂点位置リストを返します。
     * 返却順は以下の通り。
     * ・1番目の三角形の頂点→2番目の三角形の頂点の順に返す
     * ・各三角形の頂点は時計回りになるように返す（メッシュの描画は頂点の順によって描画方向が変わるため）
     */
    public ICollection<Vertex> Vertices { get; }

    private VoxcelSurface(Triangle triangle1, Triangle triangle2)
    {
        this._triangle1 = triangle1;
        this._triangle2 = triangle2;

        var vertices = new List<Vertex>();
        vertices.AddRange(this._triangle1.Vertices);
        vertices.AddRange(this._triangle2.Vertices);
        this.Vertices = vertices;
    }
}
