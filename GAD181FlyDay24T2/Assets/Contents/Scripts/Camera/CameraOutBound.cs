using UnityEngine;

namespace CameraBehavior.OutBound
{
    /// <summary>
    /// Tell the players to stick together when they try to go out of screen bounds.
    /// </summary>

    public class CameraOutBound : MonoBehaviour
    {

        #region Variables
        [SerializeField] private GameObject stickTogtherText;
        #endregion

        #region On collision detection
        private void OnCollisionEnter(Collision collision)
        {
            ///<summary>
            /// Displays warning text if players try to go out bound.
            /// </summary>

            if (collision.gameObject.tag == "Player")
            {
                // Debug.LogWarning("Stick togetherm8!!");
                stickTogtherText.SetActive(true);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                stickTogtherText.SetActive(false);
            }
        }
        #endregion
    }
}