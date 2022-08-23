using UnityEngine;
using UnityEngine.Events;

namespace Systems.HealthSystem
{
    public class LivesCounter : MonoBehaviour
    {
        [SerializeField]
        private float _liveImageWidth = 27.5f;

        [SerializeField]
        private int _maxNumOfLives = 3;

        [SerializeField]
        private int _numOfLives = 3;

        private RectTransform _rect;

        public UnityEvent OutOfLives;
        
        public int NumOfLives
        {
            get => _numOfLives;
            private set
            {
                if (value < 0) // or <= 0 depending on your needs :)
                {
                    OutOfLives?.Invoke();
                }
                _numOfLives = Mathf.Clamp(value, 0, _maxNumOfLives);
                AdjustImageWidth();
            }
        }

        private void Awake()
        {
            _rect = transform as RectTransform;
            AdjustImageWidth();
        }

        private void AdjustImageWidth()
        {
            _rect.sizeDelta = new Vector2(_liveImageWidth * _numOfLives, _rect.sizeDelta.y);
        }

        public void AddLife(int num = 1)
        {
            NumOfLives += num;
        }

        public void RemoveLife(int num = 1)
        {
            NumOfLives -= num;
        }
    }
}
