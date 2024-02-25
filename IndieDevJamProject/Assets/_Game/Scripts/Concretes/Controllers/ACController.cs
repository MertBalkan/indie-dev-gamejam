using UnityEngine;

namespace SnaileyGame.Controllers
{
    public class ACController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log(other.gameObject.name);
            
            if (other.gameObject.GetComponent<PlayerCharacterController>() != null)
            {
                Debug.Log("TEST!");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // Debug.Log(other.gameObject.name);
            //
            // if (other.gameObject.GetComponent<PlayerCharacterController>() != null)
            // {
            //     Debug.Log("TEST!");
            // }
        }
    }
}
