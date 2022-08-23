using UnityEngine;

namespace InventorySystem
{
    public class GameItemSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _itemBasePrefab;

        public void SpawnItem(ItemStack itemStack)
        {
            if (_itemBasePrefab == null) return;
            var item = Instantiate(_itemBasePrefab, transform.position, Quaternion.identity);
            var gameItemScript = item.GetComponent<GameItem>();
            gameItemScript.SetStack(new ItemStack(itemStack.Item, itemStack.NumberOfItems));
            gameItemScript.Throw(transform.localScale.x);
        }
    }
}
