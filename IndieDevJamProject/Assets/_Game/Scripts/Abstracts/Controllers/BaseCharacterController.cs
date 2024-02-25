using UnityEngine;

namespace SnaileyGame.Controllers
{
    public class BaseCharacterController : MonoBehaviour
    {
        [SerializeField] protected float speed;
        public float Speed => speed;
        
        protected virtual void Awake()
        {
        }

        protected virtual void Update()
        {
        } 
    }
}