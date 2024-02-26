using SnaileyGame.Managers;
using UnityEngine;

namespace SnaileyGame.Controllers
{
    public class DieController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                GameManager.Instance.LoadSelfScene();
            }
        }
    }
}