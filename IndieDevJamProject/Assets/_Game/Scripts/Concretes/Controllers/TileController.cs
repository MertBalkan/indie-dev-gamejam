using System;
using System.Collections;
using UnityEngine;

namespace SnaileyGame.Controllers
{
    public class TileController : MonoBehaviour
    {
        [SerializeField] private bool isBreakable;
        private bool _visited = false;
        public bool Visited => _visited;
        public bool IsBreakable => isBreakable;

        private float _direction = 1f;
        
        public float speed = 5f; 
        public float moveDistance = 10f;

        private bool _isMoving = false;
        private Vector3 _initialPosition;
        
        void Start()
        {
            _initialPosition = transform.position;
        }
        public void SetIsVisited(bool value)
        {
            _visited = value;
        }
    }
}