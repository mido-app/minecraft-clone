using UnityEngine;

/**
 * ボクセルの頂点を管理するクラス
 */
public class VoxcelVertex
{
    public Vector3 VoxcelPosition { get; set; }
    public VertexOffset Offset { get; }

    /**
     * voxcelPosition： ボクセルオブジェクト自体の位置
     * offset： ボクセルの頂点へのオフセット
     */
    public VoxcelVertex(Vector3 voxcelPosition, VertexOffset offset)
    {
        this.VoxcelPosition = voxcelPosition;
        this.Offset = offset;
    }

    public Vector3 GetPosition()
    {
        return this.VoxcelPosition + this.Offset.Position;
    }
}
