using TMPro;
using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    /// Handles players respawning after falling and 
    /// informing them of the time they respawn by.
    /// </summary>

    public class PlayerRespawnLogic : MonoBehaviour
    {
        #region Variables
        public Players player;
        public Vector3 playerOneSpawnPosition;
        public Vector3 playerTwoSpawnPosition;
        public GameObject outboundObject;
        public TMP_Text countdownText;

        private Timer _countdownTimer;
        private bool _isCountingDown = false;
        #endregion

        private void Start()
        {
            _countdownTimer = new Timer(3f); // Initialize the timer with 3 seconds
        }

        private void Update()
        {
            if (_isCountingDown)
            {
                _countdownTimer.Update(Time.deltaTime);

                // Update the countdown text
                int secondsRemaining = Mathf.CeilToInt(_countdownTimer.TimeRemaining);
                countdownText.text = secondsRemaining.ToString();

                // Check if the timer has finished
                if (_countdownTimer.HasFinished)
                {
                    RespawnPlayer();
                    _isCountingDown = false;
                    countdownText.text = ""; // Clear the countdown text
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == outboundObject && !_isCountingDown)
            {
                _isCountingDown = true;
                _countdownTimer.Reset();
            }
        }

        private void RespawnPlayer()
        {
            switch (player)
            {
                case Players.one:
                    transform.position = playerOneSpawnPosition;
                    break;
                case Players.two:
                    transform.position = playerTwoSpawnPosition;
                    break;
            }
        }
    }

    #region Class.
    public class Timer
    {
        public float TimeRemaining { get; private set; }
        public bool HasFinished => TimeRemaining <= 0f;

        private float initialTime;

        public Timer(float time)
        {
            initialTime = time;
            TimeRemaining = time;
        }

        public void Update(float deltaTime)
        {
            TimeRemaining -= deltaTime;
        }

        public void Reset()
        {
            TimeRemaining = initialTime;
        }
    }
    #endregion
}