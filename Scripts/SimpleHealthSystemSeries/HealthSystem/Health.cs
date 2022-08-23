using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Systems.HealthSystem
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int _maxHp = 100;
        private int _hp;

        public int MaxHp => _maxHp;

        public int Hp
        {
            get => _hp;
            private set
            {
                var isDamage = value < _hp;
                var healthChangeData = new HealthChangeArgs
                {
                    NewValue = Mathf.Clamp(value, 0, _maxHp),
                    OldValue = _hp,
                    AttemptedChange = value - _hp
                };
                _hp = healthChangeData.NewValue;
                if (isDamage)
                {
                    Damaged?.Invoke(healthChangeData);
                }
                else
                {
                    Healed?.Invoke(healthChangeData);
                }

                if (_hp <= 0)
                {
                    Died?.Invoke();
                }
            }
        }

        public UnityEvent<HealthChangeArgs> Healed;
        public UnityEvent<HealthChangeArgs> Damaged;
        public UnityEvent Died;
    
        private void Awake()
        {
            _hp = _maxHp;
        }

        public void Damage(int amount) =>Hp -= amount;

        public void Heal(int amount) => Hp += amount;
    
        public void HealFull() => Hp = _maxHp;

        public void Kill() => Hp = 0;

        public void Adjust(int value) => Hp = value; 
    }
}
