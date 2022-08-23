using Scripts.Systems.HealthSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems.HealthSystem
{
    public class CharacterDeath : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _respawnPosition = Vector3.zero;
        
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        public void OnDied()
        {
            _health.HealFull();
            transform.position = _respawnPosition;
        }

        public void OnOutOfLives()
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
