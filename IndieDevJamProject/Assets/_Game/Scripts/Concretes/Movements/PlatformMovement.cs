using UnityEngine;

namespace SnaileyGame.Movements
{
    public class PlatformMovement : MonoBehaviour
    {
        [SerializeField] private float length = 2f; 
        [SerializeField] private float speed = 2f; 
        private bool movingRight = true;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float movement = speed * Time.deltaTime; 
            
            if (movingRight)
            {
                
                transform.Translate(Vector3.right * movement);
            }
            else
            {
                
                transform.Translate(Vector3.left * movement);
            }

            
            if (transform.position.x >= length / 2f)
            {
                movingRight = false;
            }
            else if (transform.position.x <= -length / 2f)
            {
                movingRight = true;
            }
        }
    }
}