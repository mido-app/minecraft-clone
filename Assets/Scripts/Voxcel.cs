using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Voxcel
{
    public Vector3 Position { get; set; }
    public BlockType BlockType { get; set; }
    public Dictionary<VoxcelSurfaceDirection, VoxcelSurface> Surfaces = new Dictionary<VoxcelSurfaceDirection, VoxcelSurface>();

    public Voxcel(
        BlockType blockType,
        Vector3 position = new Vector3()
    )
    {
        this.Position = position;
        this.BlockType = blockType;
        this.Surfaces = Enum.GetValues(typeof(VoxcelSurfaceDirection))
            .Cast<VoxcelSurfaceDirection>()
            .ToList()
            .Select(direction => new
            {
                Direction = direction,
                Offsets = direction.GetVertexOffsets()
            })
            .ToDictionary(
                directionOffsets => directionOffsets.Direction,
                directionOffsets => new VoxcelSurface
                {
                    Vertices = directionOffsets.Offsets
                        .Select(offset => new VoxcelVertex(position, offset))
                        .ToList(),
                    IsVisible = true,
                    TextureId = blockType.Textures[directionOffsets.Direction]
                }
            );
    }

    public ICollection<VoxcelSurface> GetVisibleSurfaces()
    {
        return Enum.GetValues(typeof(VoxcelSurfaceDirection))
            .Cast<VoxcelSurfaceDirection>()
            .ToList()
            .Select(direction => this.Surfaces[direction])
            .Where(surface => surface.IsVisible)
            .ToList();
    }

    public int GetVisibleSurfacesCount()
    {
        return this.GetVisibleSurfaces().Count();
    }

    public ICollection<Vector3> GetVisibleVertices()
    {
        return this.GetVisibleSurfaces()
            .SelectMany(surface => surface.Vertices)
            .Select(vertex => vertex.GetPosition())
            .ToList();
    }

    public int GetVisibleVerticesCount()
    {
        // 6方向 × 6頂点のため常に36
        return this.GetVisibleVertices().Count();
    }

    public void SetSurfaceVisibility(VoxcelSurfaceDirection direction, bool isVisible)
    {
        this.Surfaces[direction].IsVisible = isVisible;
    }
}
