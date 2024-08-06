using UnityEngine;

namespace Light
{
    /// <summary>
    /// Makes spotlights follow the player assigned in the inspector!
    /// </summary>

    public class PlayerSpotlight : MonoBehaviour
    {
        #region Variables.
        [SerializeField] private Transform player;
        [SerializeField] private float followSpeed = 5f;

        private Vector3 targetPosition;
        #endregion

        private void Start()
        {
            if (player == null)
            {
                player = player.transform;
            }
        }

        private void Update()
        {
            if (player != null)
            {
                DelayedPlayerChase();
            }
        }

        #region Private Functions.
        private void DelayedPositionCalc()
        {
            targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        }

        private void DelayedPlayerChase()
        {
            DelayedPositionCalc();
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
        #endregion
    }
}