using UnityEngine;

namespace JustifyableShoplifting
{
    /// <summary>
    /// A platform that goes up and down.
    /// The paltform adjusts the player's transform when they're on it to ensure a smooth way up and down.
    /// </summary>

    public class MovingPlatform : MonoBehaviour
    {
        #region Variables
        public Transform pointA;
        public Transform pointB;
        public float speed = 0.35f;

        private Vector3 _targetPosition;
        #endregion

        private void Start()
        {
            _targetPosition = pointB.position;
        }

        private void Update()
        {
            MovePlatform();
        }

        #region Private Functions
        private void MovePlatform()
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _targetPosition) < 0.1f)
            {
                _targetPosition = _targetPosition == pointA.position ? pointB.position : pointA.position;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.transform.parent = transform;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                other.transform.parent = null;
            }
        }
        #endregion
    }
}