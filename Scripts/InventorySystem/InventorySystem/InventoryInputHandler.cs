using System;
using GameInput;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InventorySystem
{
    public class InventoryInputHandler : MonoBehaviour
    {
        private Inventory _inventory;

        private void Awake()
        {
            _inventory = GetComponent<Inventory>();
        }

        private void OnEnable()
        {
            InputActions.Instance.Game.ThrowItem.performed += OnThrowItem;
            InputActions.Instance.Game.NextItem.performed += OnNextItem;
            InputActions.Instance.Game.PreviousItem.performed += OnPreviousItem;
        }

        private void OnDisable()
        {
            InputActions.Instance.Game.ThrowItem.performed -= OnThrowItem;
            InputActions.Instance.Game.NextItem.performed -= OnNextItem;
            InputActions.Instance.Game.PreviousItem.performed -= OnPreviousItem;            
        }

        private void OnThrowItem(InputAction.CallbackContext ctx)
        {
            if (_inventory.GetActiveSlot().HasItem)
            {
                _inventory.RemoveItem(_inventory.ActiveSlotIndex, true);
            }
        }

        private void OnNextItem(InputAction.CallbackContext ctx)
        {
            _inventory.ActivateSlot(_inventory.ActiveSlotIndex + 1);
        }
        
        private void OnPreviousItem(InputAction.CallbackContext ctx)
        {
            _inventory.ActivateSlot(_inventory.ActiveSlotIndex - 1);
        }
    }
}
