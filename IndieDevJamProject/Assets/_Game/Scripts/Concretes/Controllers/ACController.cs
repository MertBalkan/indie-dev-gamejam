using System.Collections;
using UnityEngine;

namespace SnaileyGame.Controllers
{
    public class ACController : MonoBehaviour
    {
        [SerializeField] private bool acPlaying = false;
        [SerializeField] private float maxAcPlayTime = 2f;
        [SerializeField] private float acCloseTime = 3f;

        private Animator _animator;
        
        public bool ACPlaying => acPlaying;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            StartCoroutine(PlayAC());
        }

        private IEnumerator PlayAC()
        {
            while (true)
            {
                if (!acPlaying)
                {
                    acPlaying = true;      
                    _animator.SetTrigger("loop"); 
                }
                else 
                {
                    _animator.SetTrigger("loop");
                    yield return new WaitForSeconds(maxAcPlayTime);
                    
                    _animator.SetTrigger("end");
                    acPlaying = false;
                }
                
                yield return new WaitForSeconds(acCloseTime);
            }
        }
    }
}