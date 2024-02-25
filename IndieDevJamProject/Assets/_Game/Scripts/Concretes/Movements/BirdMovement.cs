using SnaileyGame.Controllers;
using UnityEngine;

namespace SnaileyGame.Movements
{
    public class BirdMovement : IMovement
    {
        private BaseCharacterController _birdCharacter;
        private SpriteRenderer _spriteRenderer;
        private float _length;
        private float _speed;
        private float _direction = 1f;

        public BirdMovement(BaseCharacterController birdCharacter, float speed, float length)
        {
            _birdCharacter = birdCharacter;
            _speed = speed;
            _length = length;
            _spriteRenderer = birdCharacter.GetComponent<SpriteRenderer>(); 
        }
        
        public void Move(float direction)
        {
            _birdCharacter.transform.Translate(Vector3.right * _speed * _direction * Time.deltaTime);
            
            if (_birdCharacter.transform.position.x >= _length)
            {
                _direction = -1f;
                _spriteRenderer.flipX = true;
            }
            else if (_birdCharacter.transform.position.x <= -_length)
            {
                _direction = 1f;
                _spriteRenderer.flipX = false;
            }
        }
    }
}