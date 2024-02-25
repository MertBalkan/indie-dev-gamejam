using System.Collections;
using UnityEngine;

namespace SnaileyGame.Movements
{
    public class CameraMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private float cameraMoveSpeed = 3f;
        public float timeRate = 0.5f;
        public float difficultyDecreaseRate = 0.2f;
        public float minimumDifficulty = 0.6f;

        private void Start()
        {
        }

        private void Update()
        {
            StartCoroutine(CameraMoveUp());
        }

        private void MoveUp()
        {
            var pos = transform.position;
            pos.z = -10f;
            transform.position = pos;
            
            transform.Translate(Vector3.up * cameraMoveSpeed * Time.deltaTime);
        }

        private IEnumerator CameraMoveUp()
        {
            while (true)
            {
                MoveUp();
                yield return new WaitForSeconds(timeRate);
                timeRate -= difficultyDecreaseRate;

                if (timeRate <= minimumDifficulty)
                {
                    timeRate = minimumDifficulty;
                }
            }
        }

        public void Move(float direction)
        {
            
        }
    }
}