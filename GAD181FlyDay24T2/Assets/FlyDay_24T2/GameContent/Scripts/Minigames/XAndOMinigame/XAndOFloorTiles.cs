using UnityEngine;

namespace XAndOMinigame
{
    /// <summary>
    /// Responsible for checking the player on a tile and setting the tile accordingly.
    /// </summary>
    
    public class XAndOFloorTiles : MonoBehaviour
    {
        #region Variables
        public Renderer cellRenderer;
        public Material xMaterial;
        public Material oMaterial;
        public XAndOMinigameNewLogic gameLogic;
        public int tileIndex;

        private bool _tileSet = false;
        private string _occupyingPlayerTag;
        #endregion

        private void Update()
        {
            if (!gameLogic.IsGameOver && !_tileSet && _occupyingPlayerTag != null)
            {
                if (_occupyingPlayerTag == "PlayerOne" && gameLogic.CurrentPlayer == "X" && Input.GetKeyDown(KeyCode.Space))
                {
                    gameLogic.SetCurrentPlayerOnTile(this, _occupyingPlayerTag, tileIndex);
                }
                else if (_occupyingPlayerTag == "PlayerTwo" && gameLogic.CurrentPlayer == "O" && Input.GetKeyDown(KeyCode.RightControl))
                {
                    gameLogic.SetCurrentPlayerOnTile(this, _occupyingPlayerTag, tileIndex);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PlayerOne") || other.CompareTag("PlayerTwo"))
            {
                _occupyingPlayerTag = other.tag;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("PlayerOne") || other.CompareTag("PlayerTwo"))
            {
                _occupyingPlayerTag = null;
            }
        }

        #region Public Functions.
        public void SetMaterial(Material material)
        {
            cellRenderer.material = material;
            _tileSet = true;
        }
        #endregion
    }
}
