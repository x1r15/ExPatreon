using System.Collections.Generic;
using BuildingSystem.Models;
using GameInput;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BuildingSystem
{
    public class BuildingSelector : MonoBehaviour
    {
        [SerializeField]
        private List<BuildableItem> _buildables;

        [SerializeField]
        private BuildingPlacer _buildingPlacer;

        private int _activeBuildableIndex;

        private void OnEnable()
        {
            InputActions.Instance.Game.NextItem.performed += OnNextItemPerformed;
        }

        private void OnNextItemPerformed(InputAction.CallbackContext ctx)
        {
            NextItem();
        }

        private void NextItem()
        {
            _activeBuildableIndex = (_activeBuildableIndex + 1) % _buildables.Count;
            _buildingPlacer.SetActiveBuildable(_buildables[_activeBuildableIndex]);
        }
    }
}
