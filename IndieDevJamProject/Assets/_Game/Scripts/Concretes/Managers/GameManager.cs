using UnityEngine;
using UnityEngine.SceneManagement;

namespace SnaileyGame.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        private void Awake()
        {
            ApplySingleton(this);
        }
  
        public void LoadSelfScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        public void LoadSceneByBuildIndex()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void LoadSceneByIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}