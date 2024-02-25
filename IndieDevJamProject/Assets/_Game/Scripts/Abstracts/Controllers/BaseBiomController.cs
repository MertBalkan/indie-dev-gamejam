using System;
using System.Collections.Generic;
using SnaileyGame.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SnaileyGame.Controllers
{
    public abstract class BaseBiomController : MonoBehaviour
    {
        [SerializeField] private BiomScriptableObject biomSo;
        public List<TileController> blocksPool = new List<TileController>();
        
        private float _currentBlockY;

        public float CurrentBlockY
        {
            get => _currentBlockY;
            set => _currentBlockY = value;
        }

        public BiomScriptableObject BiomSo => biomSo;
        
        private void Awake()
        {
            // player = FindObjectOfType<PlayerCharacterController>();
           // InitSideWalls();
           InitBlocks();	
        }

        private void Update()
        {
           // if (currentWallY - player.position.y < distanceBeforeSpawn)
           // {
           //     // SpawnSideWall();
           // }

        }

        // private void InitSideWalls()
        // {
        //     for (int i = 0; i < initialWalls; ++i)
        //     {
        //         Vector2 pos = new Vector2(0, currentWallY);
        //         GameObject go = Instantiate(wallsPrefab, pos, Quaternion.identity, transform);
        //         wallPool.Add(go);
        //         currentWallY += wallTall;
        //     }
        // }

        private void InitBlocks()
        {
           for (int i = 0; i < biomSo.initBlocksLine; i++)
           {
               Vector2 pos = new Vector2(Random.Range(biomSo.initialBrickPosition.x, biomSo.initialBrickPosition.y), _currentBlockY);
               TileController go = Instantiate(biomSo.blockPrefabs[Random.Range(0, biomSo.blockPrefabs.Count)], pos, Quaternion.identity, transform);
               blocksPool.Add(go);
               _currentBlockY += biomSo.distanceBetweenBlocks;
           }
        }

        // private void SpawnSideWall()
        // {
        //     wallPool[0].transform.position = new Vector2(0, currentWallY);
        //     currentWallY += wallTall;
        //
        //     GameObject temp = wallPool[0];
        //     wallPool.RemoveAt(0);
        //     wallPool.Add(temp);
        // }
        //
        public void SpawnBlocks()
        {  
           blocksPool[0].transform.position = new Vector2(Random.Range(biomSo.brickPosition.x, biomSo.brickPosition.y), _currentBlockY);
           _currentBlockY += biomSo.distanceBetweenBlocks;

           TileController temp = blocksPool[0];
           temp.SetIsVisited(false);
           blocksPool.RemoveAt(0);
           blocksPool.Add(temp);
        }
    }
}