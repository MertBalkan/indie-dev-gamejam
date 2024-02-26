using System.Collections.Generic;
using SnaileyGame.Controllers;
using UnityEngine;

namespace SnaileyGame.Managers
{
    public class BiomManager : SingletonMonoBehaviour<BiomManager>
    {
        [Header("Player")]
        [SerializeField] private Transform camera;

        [Space(10)]
        [Header("Bioms")]
        [SerializeField] private BaseBiomController currentBiom;
        [SerializeField] private List<BaseBiomController> allBioms;

        private bool _biomUpdated = false;
        private bool _updateScore = false;

        private int _currentBiomIndex = 0;
        
        private void Awake()
        {
            ApplySingleton(this);
        }

        private void Start()
        {
            DeactivateBioms();
            currentBiom = allBioms[_currentBiomIndex];
            currentBiom.gameObject.SetActive(true);
        }

        private void Update()
        {
            if(currentBiom.CurrentBlockY - camera.transform.position.y < currentBiom.BiomSo.distanceBeforeSpawnBLock)
            {
                currentBiom.SpawnBlocks();
            }
            
            if (currentBiom.CurrentWallY - camera.transform.position.y < currentBiom.BiomSo.distanceBeforeSpawnWall)
            {
                currentBiom.SpawnSideWall();
            }

            UpdateBiom();
        }

        public void UpdateBiom()
        {
            
            if ((camera.transform.position.y >= 20 && camera.transform.position.y <= 200) && !_updateScore)
            {
                _biomUpdated = true;
                _updateScore = true;

                allBioms[_currentBiomIndex].gameObject.SetActive(false);
                _currentBiomIndex++;
            }
            
            //todo: fix

            if (_biomUpdated && _updateScore)
            {
                allBioms[_currentBiomIndex].gameObject.SetActive(true);
                currentBiom = allBioms[_currentBiomIndex];
                _biomUpdated = false;
            }
        }
        
        private void DeactivateBioms()
        {
            allBioms.ForEach(b => b.gameObject.SetActive(false));
        }
    }
}
