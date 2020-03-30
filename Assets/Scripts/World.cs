using UnityEngine;

public class World : MonoBehaviour
{
    public Texture texure = new Texture();
    public BlockType[] blockTypes;
}

[System.Serializable]
public class BlockType
{
    public string name;
    public bool isSolid;
}
