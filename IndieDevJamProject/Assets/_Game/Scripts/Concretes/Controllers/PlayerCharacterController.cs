using SnaileyGame.Combats;
using SnaileyGame.Inputs;
using SnaileyGame.Managers;
using UnityEngine;

namespace SnaileyGame.Controllers
{
    public class PlayerCharacterController : BaseCharacterController
    {
        [SerializeField] private TileController currentTile;
        [SerializeField] private CharacterHealth _characterHealth;
        private IInput _input;

        protected override void Awake()
        {
            base.Awake();
            _input = new PcInput();
            _characterHealth = GetComponent<CharacterHealth>();
        }

        protected override void Update()
        {
            base.Update();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var otherTile = other.gameObject.GetComponent<TileController>();

            if (otherTile != null)
            {
                onGround = true;
            }

            if (otherTile != null && !otherTile.Visited)
            {
                currentTile = other.gameObject.GetComponent<TileController>();

                otherTile.SetIsVisited(true);
                ScoreManager.Instance.IncreaseScore(10);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            var otherTile = other.gameObject.GetComponent<TileController>();

            if (otherTile != null)
                onGround = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var bird = other.gameObject.GetComponent<BirdCharacterController>();

            if (bird != null)
            {
                _characterHealth.TakeDamage(50);
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            var ac = other.gameObject.GetComponent<ACController>();

            if (ac != null && ac.ACPlaying)
            {
                transform.Translate(Vector3.right * Time.deltaTime * 2f);
            }

            var otherTile = other.gameObject.GetComponent<TileController>();

            if (otherTile != null && otherTile.IsBreakable)
            {
                transform.SetParent(null);
                otherTile.GetComponent<SpriteRenderer>().sprite = otherTile.breakSprite;
            }
        }
    }
}
