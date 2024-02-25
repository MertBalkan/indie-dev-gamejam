using SnaileyGame.Controllers;
using UnityEngine;

namespace SnaileyGame.Movements
{
    public class FlipWithTransform : IFlip
    {
        private BaseCharacterController _characterController;
        
        public FlipWithTransform(BaseCharacterController  characterController)
        {
            _characterController = characterController;
        }
        
        public void Flip(float direction)
        {
            if(direction == 0) return;
            
            // direction = Mathf.Sign(direction);

            Vector2 flipVector = new Vector2(direction * _characterController.transform.localScale.x, _characterController.transform.localScale.y);
            Vector2 newFlipVector = direction > 0 ? flipVector = new Vector2(direction, _characterController.transform.localScale.y) : flipVector = new Vector2(direction, _characterController.transform.localScale.y);

            _characterController.transform.localScale = newFlipVector;
        }
    }
}
