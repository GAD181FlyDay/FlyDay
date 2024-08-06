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
        #endregion

        private void OnTriggerStay(Collider other)
        {
            if (!gameLogic.IsGameOver && !_tileSet)
            {
                if (other.CompareTag("PlayerOne") && gameLogic.CurrentPlayer == "X")
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        gameLogic.SetCurrentPlayerOnTile(this, other.tag, tileIndex);
                    }
                }
                else if (other.CompareTag("PlayerTwo") && gameLogic.CurrentPlayer == "O")
                {
                    if (Input.GetKeyDown(KeyCode.RightControl))
                    {
                        gameLogic.SetCurrentPlayerOnTile(this, other.tag, tileIndex);
                    }
                }
            }
        }

        #region Public
        public void SetMaterial(Material material)
        {
            cellRenderer.material = material;
            _tileSet = true;
        }
        #endregion
    }
}
