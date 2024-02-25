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
        
        private void Awake()
        {
            ApplySingleton(this);
        }

        private void Start()
        {
            currentBiom = allBioms[0];
        }

        private void Update()
        {
            if(currentBiom.CurrentBlockY - camera.transform.position.y < currentBiom.BiomSo.distanceBeforeSpawnBLock)
            {
                currentBiom.SpawnBlocks();
            }

            UpdateBiom();
        }

        public void UpdateBiom()
        {
            
            if (ScoreManager.Instance.Score >= 40 && !_updateScore)
            {
                _biomUpdated = true;
                _updateScore = true;
            }

            if (_biomUpdated && _updateScore)
            {
                allBioms[1].gameObject.SetActive(true);
                currentBiom = allBioms[1];
                _biomUpdated = false;
            }
        }
    }
}
