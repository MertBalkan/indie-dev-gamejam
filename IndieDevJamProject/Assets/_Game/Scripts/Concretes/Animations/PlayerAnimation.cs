using UnityEngine;

namespace SnaileyGame.Animations
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }


        private void Update()
        {
            
        }
    }
}