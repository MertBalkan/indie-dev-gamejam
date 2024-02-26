using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SnaileyGame.Movements
{
    public class IcePlatform : MonoBehaviour
    {
        private bool rightSelect = false;

        private int randomDir = 0;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                randomDir = Random.Range(-1, 2);
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                if (randomDir == 1)
                {
                    other.gameObject.transform.Translate(
                        Vector3.right * Time.deltaTime * 1f);
                }
                else
                {
                    other.gameObject.transform.Translate(
                        Vector3.left * Time.deltaTime * 1f);
                }
            }
        }
    }
}