using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XAndOMinigame
{
    /// <summary>
    /// Handles the logic of changing the material of the floor tiles depending on the current player.
    /// </summary>
    public class XAndOFloorTiles : MonoBehaviour
    {
        public Renderer cellRenderer;
        public Material xMaterial;
        public Material oMaterial;
        public XAndOMinigameNewLogic _gameLogic;

        private bool _tileSet = false;

        private void OnTriggerStay(Collider other)
        {
            if (!_gameLogic.IsGameOver && !_tileSet)
            {
                if (other.CompareTag("PlayerOne") && _gameLogic.CurrentPlayer == "X")
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        _gameLogic.SetCurrentPlayerOnTile(this, other.tag);
                    }
                }
                else if (other.CompareTag("PlayerTwo") && _gameLogic.CurrentPlayer == "O")
                {
                    if (Input.GetKeyDown(KeyCode.RightControl))
                    {
                        _gameLogic.SetCurrentPlayerOnTile(this, other.tag);
                    }
                }
            }
        }

        public void SetMaterial(Material material)
        {
            cellRenderer.material = material;
            _tileSet = true;
            gameObject.tag = "Untagged";
        }
    }
}
