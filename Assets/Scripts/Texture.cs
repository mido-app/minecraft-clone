using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Texture
{
    /**
     * テクスチャのUV配列の順番を定義
     */
    public static readonly ICollection<Vector2> UvOrders = new List<Vector2>
    {
        new Vector2(0, 0),
        new Vector2(0, 1),
        new Vector2(1, 0),
        new Vector2(1, 1)
    };

    public int blockNumOnOneSide;
    public float NormalizedBlockSize {
        get
        {
            return 1.0f / (float)this.blockNumOnOneSide;
        }
    }

    /**
     * テクスチャファイルの中のテクスチャを切り取るためのuvを取得する
     * テクスチャIDはテクスチャファイルの左上をID=0とし、
     * 横方向を優先してインクリメントしていくものとする
     */
    public ICollection<Vector2> GetUvs(int textureId)
    {
        float x = (textureId % this.blockNumOnOneSide);
        float y = this.blockNumOnOneSide - (textureId / this.blockNumOnOneSide) - 1;
        return UvOrders
            .Select(order => new Vector2(x + order.x, y + order.y))
            .Select(position => position * this.NormalizedBlockSize)
            .ToList();
    }
}

public enum TextureId
{
    Air = -1,
    Stone = 1,
    Dirt = 2,
    DirtWithGrass = 3,
    Grass = 162
}