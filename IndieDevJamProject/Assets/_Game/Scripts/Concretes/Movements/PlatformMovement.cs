using System;
using SnaileyGame.Controllers;
using UnityEngine;

namespace SnaileyGame.Movements
{
    public class PlatformMovement : MonoBehaviour
    {
        [SerializeField] private float length;
        [SerializeField] private float speed;
        [SerializeField] private float direction = 1f;
        
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            Move();
        }

        public void Move()
        {
            transform.Translate(Vector3.right * speed * direction * Time.deltaTime);
            
            if (transform.position.x >= length)
            {
                direction = -1f;
            }
            else if (transform.position.x <= -length)
            {
                direction = 1f;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.GetComponent<PlayerCharacterController>() != null)
                other.transform.SetParent(transform);
        }
        
        private void OnCollisionExit2D(Collision2D other)
        {
            if(other.gameObject.GetComponent<PlayerCharacterController>() != null)
                other.transform.SetParent(null);
        }
    }
}
