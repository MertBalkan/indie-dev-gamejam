using UnityEngine;

namespace SnaileyGame.Combats
{
    public class CharacterHealth : MonoBehaviour, IHealth
    {
        
        [SerializeField] private float maxHealth = 100f;
        private float _currentHealth;
        
        public float CurrentHealth { get; }
        public bool IsDead { get; }

        private void Awake()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float damageCount)
        {
            if(IsDead) return;
            _currentHealth -= damageCount;
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
            }
        }

        private void Update()
        {
            UnityEngine.Debug.Log("Health: " + _currentHealth);
        }
    }
}
