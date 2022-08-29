using BuildingSystem.Models;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace BuildingSystem
{
    public class CollisionLayer : TilemapLayer
    {
        [SerializeField]
        private TileBase _collisionTileBase;

        public void SetCollisions(Buildable buildable, bool value)
        {
            var tile = value ? _collisionTileBase : null;
            buildable.IterateCollisionSpace(tileCoords => _tilemap.SetTile(tileCoords, tile));
        }
    }
}
