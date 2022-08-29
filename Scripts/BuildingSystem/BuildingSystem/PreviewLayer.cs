using BuildingSystem.Models;
using UnityEngine;

namespace BuildingSystem
{
    public class PreviewLayer : TilemapLayer
    {
        [SerializeField]
        private SpriteRenderer _previewRenderer;

        public void ShowPreview(BuildableItem item, Vector3 worldCoords, bool isValid)
        {
            var coords = _tilemap.WorldToCell(worldCoords);
            _previewRenderer.enabled = true;
            _previewRenderer.transform.position = 
                _tilemap.CellToWorld(coords) + 
                _tilemap.cellSize / 2 + 
                item.TileOffset;
            _previewRenderer.sprite = item.PreviewSprite;
            _previewRenderer.color = isValid ? new Color(0, 1, 0, 0.5f) : new Color(1, 0, 0, 0.5f);
        }

        public void ClearPreview()
        {
            _previewRenderer.enabled = false;
        }
    }
}
