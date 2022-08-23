using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace InventorySystem.UI
{
    public class UI_Inventory : MonoBehaviour
    {
        [SerializeField]
        private GameObject _inventorySlotPrefab;

        [SerializeField]
        private Inventory _inventory;

        [SerializeField]
        private List<UI_InventorySlot> _slots;

        public Inventory Inventory => _inventory;

        private void Awake()
        {
            InitializeInventoryUi();
        }

        [ContextMenu("Initialize Inventory")]
        private void InitializeInventoryUi()
        {
            if (_inventory == null || _inventorySlotPrefab == null) return;

            Clear();
            _slots = new List<UI_InventorySlot>(_inventory.Size);
            for (var i = 0; i < _inventory.Size; i++)
            {
                #if UNITY_EDITOR
                var uiSlot = PrefabUtility.InstantiatePrefab(_inventorySlotPrefab) as GameObject;
                #else 
                var uiSlot = Instantiate(_inventorySlotPrefab, transform.position, Quaternion.identity);
                #endif
                uiSlot.transform.SetParent(transform, false);
                var uiSlotScript = uiSlot.GetComponent<UI_InventorySlot>();
                uiSlotScript.AssignSlot(i);
                _slots.Add(uiSlotScript);
            }
        }
        
        public void Clear()
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }
    }
}
