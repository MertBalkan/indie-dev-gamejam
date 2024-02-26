using System;
using System.Collections;
using SnaileyGame.Combats;
using SnaileyGame.Inputs;
using SnaileyGame.Managers;
using SnaileyGame.Movements;
using Unity.VisualScripting;
using UnityEngine;

namespace SnaileyGame.Controllers
{
    public class PlayerCharacterController : BaseCharacterController
    {
        [SerializeField] private float SEZ_TEST = 3;
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
            var otherTile = other.gameObject.GetComponent<TileController>();

            if (otherTile != null && otherTile.IsBreakable)
            {
                transform.SetParent(null);
                StartCoroutine(DeactivateAfterDelay(otherTile, SEZ_TEST));
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            var ac = other.gameObject.GetComponent<ACController>();

            if (ac != null && ac.ACPlaying)
            {
                if (ac.GetComponent<SpriteRenderer>().flipX)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * 2f);
                }

                if (!ac.GetComponent<SpriteRenderer>().flipX)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * 3f);
                }
            }

        }

        private IEnumerator DeactivateAfterDelay(TileController obj, float delay)
        {
            obj.GetComponent<SpriteRenderer>().sprite = obj.breakSprite;
            yield return new WaitForSeconds(delay);
            obj.gameObject.SetActive(false);
        }
    }
}
