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
            Vertex.BackBottomLeft,
            Vertex.FrontBottomLeft,
            Vertex.BackBottomRight
        ),
        new Triangle(
            Vertex.BackBottomRight,
            Vertex.FrontBottomLeft,
            Vertex.FrontBottomRight
        )
    );

    public static VoxcelSurface Front = new VoxcelSurface(
        new Triangle(
            Vertex.FrontBottomLeft,
            Vertex.FrontTopLeft,
            Vertex.FrontBottomRight
        ),
        new Triangle(
            Vertex.FrontBottomRight,
            Vertex.FrontTopLeft,
            Vertex.FrontTopRight
        )
    );

    public static VoxcelSurface Back = new VoxcelSurface(
        new Triangle(
            Vertex.BackBottomRight,
            Vertex.BackTopRight,
            Vertex.BackBottomLeft
        ),
        new Triangle(
            Vertex.BackBottomLeft,
            Vertex.BackTopRight,
            Vertex.BackTopLeft
        )
    );

    public static VoxcelSurface Left = new VoxcelSurface(
        new Triangle(
            Vertex.BackBottomLeft,
            Vertex.BackTopLeft,
            Vertex.FrontBottomLeft
        ),
        new Triangle(
            Vertex.FrontBottomLeft,
            Vertex.BackTopLeft,
            Vertex.FrontTopLeft
        )
    );

    public static VoxcelSurface Right = new VoxcelSurface(
        new Triangle(
            Vertex.FrontBottomRight,
            Vertex.FrontTopRight,
            Vertex.BackBottomRight
        ),
        new Triangle(
            Vertex.BackBottomRight,
            Vertex.FrontTopRight,
            Vertex.BackTopRight
        )
    );

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
