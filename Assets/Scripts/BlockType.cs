using System.Collections.Generic;

public class BlockType
{
    public BlockTypeId Id { get; set; }
    public IDictionary<VoxcelSurfaceDirection, TextureId> Textures { get; set; }
}

public enum BlockTypeId {
    Air,
    Dirt,
    Stone,
}
