using System;
using UnityEngine;
using UnityEngine.UI;

namespace BuildingSystem.UI
{
    public class UI_ActiveItemIndicator : MonoBehaviour
    {
        [SerializeField]
        private BuildingPlacer _buildingPlacer;

        private Image _icon;

        private void Awake()
        {
            _icon = GetComponent<Image>();
            _buildingPlacer.ActiveBuildableChanged += OnActiveBuildableChanged;
        }

        private void Start()
        {
            OnActiveBuildableChanged();
        }

        private void OnActiveBuildableChanged()
        {
            if (_buildingPlacer.ActiveBuildable != null)
            {
                _icon.enabled = true;
                _icon.sprite = _buildingPlacer.ActiveBuildable.UiIcon;                
            }
            else
            {
                _icon.enabled = false;
            }

        }
    }
}
