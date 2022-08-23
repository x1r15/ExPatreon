using System.Collections;
using UnityEngine;

namespace InventorySystem
{
    public class GameItem : MonoBehaviour
    {
        [SerializeField]
        private ItemStack _stack;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [Header("Throw Settings")]
        [SerializeField]
        private float _colliderEnabledAfter = 1f;
        [SerializeField]
        private float _throwGravity = 2f;
        [SerializeField]
        private float _minThrowXForce = 3f;
        [SerializeField]
        private float _maxThrowXForce = 5f;
        [SerializeField]
        private float _throwYForce = 5f;

        private Collider2D _collider;
        private Rigidbody2D _rb;

        public ItemStack Stack => _stack;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
            _rb = GetComponent<Rigidbody2D>();
            _collider.enabled = false;
        }

        private void Start()
        {
            SetupGameObject();
            StartCoroutine(EnableCollider(_colliderEnabledAfter));
        }
        
        private void OnValidate()
        {
            SetupGameObject();
        }
        
        private void SetupGameObject()
        {
            if (_stack.Item == null) return;
            SetGameSprite();
            AdjustNumberOfItems();
            UpdateGameObjectName();
        }

        private void SetGameSprite()
        {
            _spriteRenderer.sprite = _stack.Item.InGameSprite;
        }

        private void UpdateGameObjectName()
        {
            //ItemName (5)/(ns)
            var name = _stack.Item.Name;
            var number = _stack.IsStackable ? _stack.NumberOfItems.ToString() : "ns";
            gameObject.name = $"{name} ({number})";
        }

        private void AdjustNumberOfItems()
        {
            _stack.NumberOfItems = _stack.NumberOfItems;
        }

        public ItemStack Pick()
        {
            Destroy(gameObject);
            return _stack;
        }

        public void Throw(float xDir)
        {
            _rb.gravityScale = _throwGravity;
            var throwXForce = Random.Range(_minThrowXForce, _maxThrowXForce);
            _rb.velocity = new Vector2(Mathf.Sign(xDir) * throwXForce, _throwYForce);
            StartCoroutine(DisableGravity(_throwYForce));
        }

        private IEnumerator DisableGravity(float atYVelocity)
        {
            yield return new WaitUntil(() => _rb.velocity.y < -atYVelocity);
            _rb.velocity = Vector2.zero;
            _rb.gravityScale = 0;
        }

        private IEnumerator EnableCollider(float afterTime)
        {
            yield return new WaitForSeconds(afterTime);
            _collider.enabled = true;
        }

        public void SetStack(ItemStack itemStack)
        {
            _stack = itemStack;
        }
    }
}
