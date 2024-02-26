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
        public List<GameObject> blocksPool = new List<GameObject>();
        public List<GameObject> wallsPool = new List<GameObject>();
        
        [SerializeField] private float _currentBlockY;
        [SerializeField] private float _currentWallY;

        public float CurrentBlockY
        {
            get => _currentBlockY;
            set => _currentBlockY = value;
        }
        
        public float CurrentWallY
        {
            get => _currentWallY;
            set => _currentWallY = value;
        }

        public BiomScriptableObject BiomSo => biomSo;
        
        private void Awake()
        {
           InitSideWalls();
           InitBlocks();	
        }

        private void InitSideWalls()
        {
            for (int i = 0; i < biomSo.initWallsLine; ++i)
            {
                Vector2 pos = new Vector2(-8.81f, _currentWallY);
                GameObject go = Instantiate(biomSo.wallsPrefab[Random.Range(0, biomSo.wallsPrefab.Count)], pos, Quaternion.identity, transform);
                wallsPool.Add(go);
                _currentWallY += biomSo.wallTall;
            }
        }

        private void InitBlocks()
        {
           for (int i = 0; i < biomSo.initBlocksLine; i++)
           {
               Vector2 pos = new Vector2(Random.Range(biomSo.initialBrickPosition.x, biomSo.initialBrickPosition.y), _currentBlockY);
               GameObject go = Instantiate(biomSo.blockPrefabs[Random.Range(0, biomSo.blockPrefabs.Count)], pos, Quaternion.identity, transform);
               blocksPool.Add(go);
               _currentBlockY += biomSo.distanceBetweenBlocks;
           }
        }

        public void SpawnBlocks()
        {  
           blocksPool[0].transform.position = new Vector2(Random.Range(biomSo.brickPosition.x, biomSo.brickPosition.y), _currentBlockY);
           _currentBlockY += biomSo.distanceBetweenBlocks;

           GameObject temp = blocksPool[0];
           // temp.GetComponentInChildren<TileController>().SetIsVisited(false);
           blocksPool.RemoveAt(0);
           blocksPool.Add(temp);
        }
        
        public void SpawnSideWall()
        {
            wallsPool[0].transform.position = new Vector2(-8.81f, _currentWallY);
            _currentWallY += biomSo.wallTall;
        
            GameObject temp = wallsPool[0];
            wallsPool.RemoveAt(0);
            wallsPool.Add(temp);
        }
        
    }
}