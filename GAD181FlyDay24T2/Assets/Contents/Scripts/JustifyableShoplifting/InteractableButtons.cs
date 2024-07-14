using UnityEngine;

namespace JustifyableShoplifting
{
    /// <summary>
    /// Assign to the 'buttons' in scene.
    /// This script can be re usable! do tell if you want to re use it, 
    /// i'll make adjustments to it then.
    /// </summary>

    public class InteractableButtons : MonoBehaviour
    {
        #region Variables.
        public string[] wallTags;
        public LayerMask playerLayer;
        public float interactionRadius = 2.0f;
        #endregion

        private void Update()
        {
            CheckForPlayerInteraction();
        }

        #region Private Functions.
        private void CheckForPlayerInteraction()
        {
            Collider[] players = Physics.OverlapSphere(transform.position, interactionRadius, playerLayer);
            foreach (Collider player in players)
            {
                if (Input.GetKeyDown(KeyCode.LeftControl)) 
                {
                    DisableWalls();
                }
            }
        }

        private void DisableWalls()
        {
            foreach (string tag in wallTags)
            {
                GameObject[] walls = GameObject.FindGameObjectsWithTag(tag);
                foreach (GameObject wall in walls)
                {
                    wall.SetActive(false);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, interactionRadius);
        }
        #endregion
    }
}