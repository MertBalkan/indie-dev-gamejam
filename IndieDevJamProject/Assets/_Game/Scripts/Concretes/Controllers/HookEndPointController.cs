using UnityEngine;

namespace SnaileyGame.Controllers
{
    public class HookEndPointController : MonoBehaviour
    {
        [SerializeField] private TileController tileController;
        public TileController TileController
        {
            get => tileController;
            set => tileController = value;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var otherTile = other.gameObject.GetComponent<TileController>();
            
            if (otherTile != null)
            {
                tileController = otherTile;
            }
        }
        
        private void OnCollisionExit2D(Collision2D other)
        {
            var otherTile = other.gameObject.GetComponent<TileController>();
            
            if (otherTile != null)
            {
                tileController = null;
            }
        }
    }
}
