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

        public void IncreaseScore(int amount)
        {
            _score += amount;
        }
    }
}