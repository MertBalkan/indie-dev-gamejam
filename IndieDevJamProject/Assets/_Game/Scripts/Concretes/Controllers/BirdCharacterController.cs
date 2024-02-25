using SnaileyGame.Movements;
using UnityEngine;

namespace SnaileyGame.Controllers
{
    public class BirdCharacterController : BaseCharacterController
    {
        [SerializeField] private float direction;
        [SerializeField] private float length;
        private IMovement _movement;

        protected override void Awake()
        {
            base.Awake();
            _movement = new BirdMovement(this, speed, length);
        }

        protected override void Update()
        {
            base.Update();
            _movement.Move(direction);
        }
    }
}
