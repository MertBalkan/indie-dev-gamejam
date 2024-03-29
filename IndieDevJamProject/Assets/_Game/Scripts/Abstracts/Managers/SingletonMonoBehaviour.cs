using UnityEngine;

namespace SnaileyGame.Managers
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : Component
    {
        public static T Instance { get; private set; }

        private void OnEnable()
        {
            transform.parent = null;
        }

        protected void ApplySingleton(T gameObject)
        {
            if (Instance == null)
            {
                Instance = gameObject;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}