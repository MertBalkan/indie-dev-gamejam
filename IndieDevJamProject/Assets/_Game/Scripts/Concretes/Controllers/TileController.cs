using UnityEngine;

namespace SnaileyGame.Controllers
{
    public class TileController : MonoBehaviour
    {
        private bool _visited = false;
        public bool Visited => _visited;

        public void SetIsVisited(bool value)
        {
            _visited = value;
        }
    }
}