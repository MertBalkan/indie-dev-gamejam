using System.Collections.Generic;
using SnaileyGame.Controllers;
using SnaileyGame.Enums;
using UnityEngine;

namespace SnaileyGame.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Create New Biom")]
    public class BiomScriptableObject : ScriptableObject
    {
        [Header("Biom Type")]
        public Biom biomType;
        
        [Space(10)]
        [Header("Platforms")]
        public List<TileController> blockPrefabs = new List<TileController>();
        public float distanceBetweenBlocks = 2f;
        public float distanceBeforeSpawnBLock = 10f;
        public int initBlocksLine = 10;
        public Vector2 initialBrickPosition;
        public Vector2 brickPosition;
    }
}