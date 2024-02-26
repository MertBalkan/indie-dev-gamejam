using System;
using System.Collections;
using SnaileyGame.Controllers;
using Unity.VisualScripting;
using UnityEngine;

namespace SnaileyGame.Movements
{
    public class CameraMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private float cameraMoveSpeed = 3f;
        [SerializeField] private HookController _hookController;
        public float timeRate = 0.5f;
        public float difficultyDecreaseRate = 0.2f;
        public float minimumDifficulty = 0.6f;
        public float increaseRate = 2;
      
//200
//480
//875
        private void Start()
        {
            _hookController = FindObjectOfType<HookController>();
        }

        private void FixedUpdate()
        {
            MoveUp();
        }

        private void Update()
        {
            if (transform.position.y >= 195 && transform.position.y <= 480)
            {
                _hookController.IncreaseHookValue(4f);
                cameraMoveSpeed += 1;
            }
            
            if (transform.position.y > 480 && transform.position.y < 875f)
            {
                _hookController.IncreaseHookValue(5f);
                cameraMoveSpeed += 1;
            }
            
            if (transform.position.y >= 875f)
            {
                _hookController.IncreaseHookValue(6);
                cameraMoveSpeed += 1;
            }
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