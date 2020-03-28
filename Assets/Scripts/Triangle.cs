using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Unityのメッシュは3角形から成る
 * その3角形を表すクラス
 * 初期化の際に渡す頂点は時計回りになるように渡すこと
 */
public class Triangle
{
    public ICollection<Vertex> Vertices { get; }

    public Triangle(Vertex vertex1, Vertex vertex2, Vertex vertex3)
    {
        var vertices = new List<Vertex>
        {
            vertex1,
            vertex2,
            vertex3
        };

        this.Vertices = vertices;
    }
}
