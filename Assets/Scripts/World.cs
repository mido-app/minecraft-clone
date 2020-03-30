using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class World : MonoBehaviour
{
    public Texture texure = new Texture();
    private static readonly BlockType[] _blockTypes = new BlockType[] {
        new BlockType
        {
            Id = BlockTypeId.Air,
            Textures = new Dictionary<VoxcelSurfaceDirection, TextureId>
            {
                { VoxcelSurfaceDirection.Front, TextureId.Air },
                { VoxcelSurfaceDirection.Back, TextureId.Air },
                { VoxcelSurfaceDirection.Top, TextureId.Air },
                { VoxcelSurfaceDirection.Bottom, TextureId.Air },
                { VoxcelSurfaceDirection.Left, TextureId.Air },
                { VoxcelSurfaceDirection.Right, TextureId.Air }
            }
        },
        new BlockType
        {
            Id = BlockTypeId.Dirt,
            Textures = new Dictionary<VoxcelSurfaceDirection, TextureId>
            {
                { VoxcelSurfaceDirection.Front, TextureId.DirtWithGrass },
                { VoxcelSurfaceDirection.Back, TextureId.DirtWithGrass },
                { VoxcelSurfaceDirection.Top, TextureId.Grass },
                { VoxcelSurfaceDirection.Bottom, TextureId.Dirt },
                { VoxcelSurfaceDirection.Left, TextureId.DirtWithGrass },
                { VoxcelSurfaceDirection.Right, TextureId.DirtWithGrass }
            }
        },
        new BlockType {
            Id = BlockTypeId.Stone,
            Textures = new Dictionary<VoxcelSurfaceDirection, TextureId>
            {
                { VoxcelSurfaceDirection.Front, TextureId.Stone },
                { VoxcelSurfaceDirection.Back, TextureId.Stone },
                { VoxcelSurfaceDirection.Top, TextureId.Stone },
                { VoxcelSurfaceDirection.Bottom, TextureId.Stone },
                { VoxcelSurfaceDirection.Left, TextureId.Stone },
                { VoxcelSurfaceDirection.Right, TextureId.Stone }
            }
        },
    };

    public BlockType GetBlockTypeById(BlockTypeId id) {
        return _blockTypes.Where(type => type.Id == id).FirstOrDefault();
    }
}
