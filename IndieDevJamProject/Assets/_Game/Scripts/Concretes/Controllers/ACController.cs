using System.Collections;
using UnityEngine;

namespace SnaileyGame.Controllers
{
    public class ACController : MonoBehaviour
    {
        [SerializeField] private bool acPlaying = false;
        [SerializeField] private float maxAcPlayTime = 2f;
        [SerializeField] private float acCloseTime = 3f;

        public bool ACPlaying => acPlaying;

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
                }
                else 
                {
                    yield return new WaitForSeconds(maxAcPlayTime);
                    acPlaying = false;
                }

                yield return new WaitForSeconds(acCloseTime);
            }
        }
    }
}