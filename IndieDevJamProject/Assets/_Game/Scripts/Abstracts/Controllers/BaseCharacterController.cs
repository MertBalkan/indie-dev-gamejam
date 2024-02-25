using UnityEngine;

namespace SnaileyGame.Controllers
{
    public class BaseCharacterController : MonoBehaviour
    {
        [SerializeField] protected float speed;
        [SerializeField] protected bool onGround = true;

        public float Speed => speed;
        public bool OnGround => onGround;
        
        protected virtual void Awake()
        {
        }

        protected virtual void Update()
        {
        } 
    }
}