using System;

namespace SnaileyGame.Managers
{
    public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
    {
        private int _score = 0;
        public int Score => _score;

        private void Awake()
        {
            ApplySingleton(this);
        }

        private void Update()
        {
            UnityEngine.Debug.Log(_score);
        }

        public void IncreaseScore(int amount)
        {
            _score += amount;
        }
    }
}