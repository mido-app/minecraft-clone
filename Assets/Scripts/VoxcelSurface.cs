using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/*
 * ボクセルの面を表すクラス
 * ボクセルの面は2つの3角形から成る
 */
public class VoxcelSurface {
    /**
     * 面の描画に必要な頂点位置リストを返します。
     * 返却順は以下の通り。
     * ・1番目の三角形の頂点→2番目の三角形の頂点の順に返す
     * ・各三角形の頂点は時計回りになるように返す（メッシュの描画は頂点の順によって描画方向が変わるため）
     */
    public ICollection<VoxcelVertex> Vertices { get; }

    public VoxcelSurface(ICollection<VoxcelVertex> vertices)
    {
        this.Vertices = vertices;
    }
}
