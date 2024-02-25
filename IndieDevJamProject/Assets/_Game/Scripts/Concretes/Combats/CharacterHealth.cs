using UnityEngine;

namespace SnaileyGame.Combats
{
    public class CharacterHealth : MonoBehaviour, IHealth
    {
        
        [SerializeField] private float _maxHealth = 100f;
        private float _currentHealth;
        
        public float CurrentHealth { get; }
        public bool IsDead { get; }

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(float damageCount)
        {
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
            }
        }
    }
}
