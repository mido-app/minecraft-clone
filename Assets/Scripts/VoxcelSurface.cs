using System.Collections.Generic;

/*
 * ボクセルの面を表すクラス
 * ボクセルの面は4つの点からできる2つの三角形から成る
 */
public class VoxcelSurface {

    /**
     * 4つの点から三角形を作るために線を結ぶ順番を定義
     * それぞれの値はVerticesのインデックスを表す
     */
    public static readonly ICollection<int> TriangleOrder = new List<int> { 0, 1, 2, 2, 1, 3 };

    public ICollection<VoxcelVertex> Vertices { get; set; }

    public bool IsVisible { get; set; }

    public TextureId TextureId { get; set; }
}
