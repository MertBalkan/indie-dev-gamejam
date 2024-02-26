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
        public List<GameObject> blockPrefabs = new List<GameObject>();
        public float distanceBetweenBlocks = 2f;
        public float distanceBeforeSpawnBLock = 10f;
        public int initBlocksLine = 10;
        public Vector2 initialBrickPosition;
        public Vector2 brickPosition;

        [Header("Walls")]
        public int initWallsLine;
        public float wallTall;
        public int distanceBeforeSpawnWall = 10;
        public List<GameObject> wallsPrefab = new List<GameObject>();

    }
}