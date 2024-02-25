using UnityEngine;

namespace SnaileyGame.Animations
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }


        private void Update()
        {
            
        }

        public void PlayShieldInAnimation()
        {
            _animator.SetTrigger("shieldIn");
        }

        public void PlayShieldOutAnimation()
        {
            _animator.SetTrigger("shieldOut");
        }

        public void PlayPlayerAirAnimation()
        {
            _animator.SetTrigger("playerAir");
        }
    }
}