using UnityEngine;

namespace JustifyableShoplifting
{
    /// <summary>
    /// This script isr esponsible for the enemy's (Guard's) 
    /// patroling and busting player condition.
    /// </summary>

    public class EnemyLogic : MonoBehaviour
    {
        #region Variables.
        [SerializeField] private Transform pointA;
        [SerializeField] private Transform pointB;
        [SerializeField] private Transform pointC;
        [SerializeField] private Transform pointD;
        [SerializeField] private Transform[] checkpoints;
        [SerializeField] private float moveSpeed = 2.0f;
        [SerializeField] private float detectionRadius = 5.0f;
        [SerializeField] private LayerMask playerLayer;
        [SerializeField] private LayerMask wallLayer;

        private Transform _currentTarget;
        private Transform _playerTransform;
        private int _currentCheckpoint = 0;
        private bool _playerDetected = false;
        private float _detectionTime = 0.0f;
        private float _detectionDuration = 1.5f;
        #endregion

        private void Start()
        {
            _currentTarget = pointA;
        }

        private void Update()
        {
            Patrol();
            DetectPlayer();
        }

        #region Private Functions.
        private void Patrol()
        {
            if (_currentTarget == null) return;

            transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _currentTarget.position) < 0.1f)
            {
                SwitchTarget();
            }
        }

        private void SwitchTarget()
        {
            switch (_currentCheckpoint)
            {
                case 0:
                    _currentTarget = _currentTarget == pointA ? pointB : pointA;
                    break;
                case 1:
                    _currentTarget = _currentTarget == pointB ? pointC : pointB;
                    break;
                case 2:
                    _currentTarget = _currentTarget == pointC ? pointD : pointC;
                    break;
                case 3:
                    // Player winnin script reference.
                    break;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Checkpoint"))
            {
                for (int i = 0; i < checkpoints.Length; i++)
                {
                    if (other.transform == checkpoints[i])
                    {
                        _currentCheckpoint = i + 1;
                        break;
                    }
                }
            }
        }

        private void DetectPlayer()
        {
            Collider[] players = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);

            foreach (Collider player in players)
            {
                if (!Physics.Linecast(transform.position, player.transform.position, wallLayer))
                {
                    _playerDetected = true;
                    _playerTransform = player.transform;
                    break;
                }
                else
                {
                    _playerDetected = false;
                }
            }

            if (_playerDetected)
            {
                _detectionTime += Time.deltaTime;
                if (_detectionTime >= _detectionDuration)
                {
                    // Bust player script reference.
                }
            }
            else
            {
                _detectionTime = 0.0f;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
        #endregion
    }
}