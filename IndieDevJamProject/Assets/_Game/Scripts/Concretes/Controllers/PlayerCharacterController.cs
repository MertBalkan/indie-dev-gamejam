using SnaileyGame.Inputs;
using SnaileyGame.Managers;
using UnityEngine;

namespace SnaileyGame.Controllers
{
    public class PlayerCharacterController : BaseCharacterController
    {
        [SerializeField] private TileController currentTile;
        private IInput _input;

        protected override void Awake()
        {
            base.Awake();
            _input = new PcInput();
        }

        protected override void Update()
        {
            base.Update();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var otherTile = other.gameObject.GetComponent<TileController>();
            
            if (otherTile != null && !otherTile.Visited)
            {
                currentTile = other.gameObject.GetComponent<TileController>();
                
                otherTile.SetIsVisited(true);
                ScoreManager.Instance.IncreaseScore(10);
            }
        }
    }
}