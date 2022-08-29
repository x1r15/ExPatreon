using System;
using BuildingSystem.Models;
using GameInput;
using UnityEngine;

namespace BuildingSystem
{
    public class BuildingPlacer : MonoBehaviour
    {
        public event Action ActiveBuildableChanged;
        
        [field:SerializeField]
        public BuildableItem ActiveBuildable { get; private set; }

        [SerializeField]
        private float _maxBuildingDistance = 3f;

        [SerializeField]
        private ConstructionLayer _constructionLayer;

        [SerializeField]
        private PreviewLayer _previewLayer;

        [SerializeField]
        private MouseUser _mouseUser;

        private void Update()
        {
            if (!IsMouseWithinBuildableRange() || _constructionLayer == null)
            {
                _previewLayer.ClearPreview();
                return;
            }

            var mousePos = _mouseUser.MouseInWorldPosition;
            
            if (_mouseUser.IsMouseButtonPressed(MouseButton.Right))
            {
                _constructionLayer.Destroy(mousePos);
            }

            if (ActiveBuildable == null) return;

            var isSpaceEmpty = _constructionLayer.IsEmpty(mousePos, 
                ActiveBuildable.UseCustomCollisionSpace ? 
                    ActiveBuildable.CollisionSpace : default);
            
            _previewLayer.ShowPreview(
                ActiveBuildable, 
                mousePos,
                isSpaceEmpty
                );
            if (_mouseUser.IsMouseButtonPressed(MouseButton.Left) && isSpaceEmpty)
            {
                _constructionLayer.Build(mousePos, ActiveBuildable);
            }
        }

        private bool IsMouseWithinBuildableRange()
        {
            return Vector3.Distance(
                _mouseUser.MouseInWorldPosition, 
                transform.position) <= _maxBuildingDistance;
        }

        public void SetActiveBuildable(BuildableItem item)
        {
            ActiveBuildable = item;
            ActiveBuildableChanged?.Invoke();
        }
    }
}
