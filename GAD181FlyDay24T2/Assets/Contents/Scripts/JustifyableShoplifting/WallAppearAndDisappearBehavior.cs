using UnityEngine;

namespace JustifyableShoplifting
{


    public class WallAppearAndDisappearBehavior : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float disableDuration = 1.0f;
        [SerializeField] private float enableDuration = 1.0f;

        // Reference to the wall's GameObject
        private GameObject wall;
        #endregion

        private void Start()
        {
            // Initialize the wall variable
            wall = gameObject;

            // Start the toggle cycle
            DisableWall();
        }

        #region Private Functions.
        private void DisableWall()
        {
            wall.SetActive(false);

            Invoke("EnableWall", disableDuration);
        }

        private void EnableWall()
        {
            wall.SetActive(true);

            Invoke("DisableWall", enableDuration);
        }
        #endregion
    }
}