using System.Collections.Generic;
using SnaileyGame.Controllers;
using UnityEngine;
using UnityEngine.Serialization;

namespace SnaileyGame.Managers
{
    public class BiomManager : SingletonMonoBehaviour<BiomManager>
    {
        [Header("Player")]
        [SerializeField] private Transform camera;
        [SerializeField] private HookController hookController;
        
        [Space(10)]
        [Header("Bioms")]
        [SerializeField] private BaseBiomController currentBiom;
        [SerializeField] private List<BaseBiomController> allBioms;
        [SerializeField] private float biomOffset;
        [SerializeField] private float nextBiomPosition;
        
        
        private bool _biomUpdated = false;
        private bool _updateScore = false;

        private int _currentBiomIndex = 0;
        
        private void Awake()
        {
            hookController = FindObjectOfType<HookController>();
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
            
            if ((camera.transform.position.y >= nextBiomPosition && camera.transform.position.y <= 200) && !_updateScore)
            {
                _biomUpdated = true;
                _updateScore = true;

                allBioms[_currentBiomIndex].gameObject.SetActive(false);
                _currentBiomIndex++;
            }
            
            if (_biomUpdated && _updateScore)
            {
                allBioms[_currentBiomIndex].gameObject.SetActive(true);
                currentBiom = allBioms[_currentBiomIndex];
          
                currentBiom.transform.position = new Vector2(currentBiom.transform.position.x,
                    currentBiom.transform.position.y + biomOffset);
                _biomUpdated = false;
            }
        }
        
        private void DeactivateBioms()
        {
            allBioms.ForEach(b => b.gameObject.SetActive(false));
        }
    }
}
