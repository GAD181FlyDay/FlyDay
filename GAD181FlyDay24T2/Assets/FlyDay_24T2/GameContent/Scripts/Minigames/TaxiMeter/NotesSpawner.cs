using UnityEngine;

namespace TaxiMeter
{
    /// <summary>
    /// This script is responsible for spawning notes for both players.
    /// </summary>
    public class NotesSpawner : MonoBehaviour
    {
        #region Variables

        public NotesPooling waNotePool;  
        public NotesPooling sdNotePool; 
        public NotesPooling upLeftNotePool; 
        public NotesPooling downRightNotePool;  
        public Transform waSpawnPoint;
        public Transform sdSpawnPoint;
        public Transform upLeftSpawnPoint;
        public Transform downRightSpawnPoint;
        public float initialMinSpawnInterval = 0.3f; 
        public float initialMaxSpawnInterval = 1.0f;
        public float speedUpFactor = 0.9f; 
        private float currentMinSpawnInterval;
        private float currentMaxSpawnInterval;
        private float nextSpawnTimePlayer1;
        private float nextSpawnTimePlayer2;

        #endregion

        private void Start()
        {
            currentMinSpawnInterval = initialMinSpawnInterval;
            currentMaxSpawnInterval = initialMaxSpawnInterval;
            PlanNextSpawnTime();
        }

        private void Update()
        {
            if (Time.time >= nextSpawnTimePlayer1)
            {
                SpawnRandomNoteForPlayerOne();
                PlayerOneNextSpawnTime();
            }

            if (Time.time >= nextSpawnTimePlayer2)
            {
                SpawnRandomNoteForPlayerTwo();
                PlayerTwoNextSpawnTime();
            }
        }

        #region Private Functions

        private void SpawnRandomNoteForPlayerOne()
        {
            int noteType = Random.Range(0, 2);

            switch (noteType)
            {
                case 0:
                    SpawnNoteFromPool(waNotePool, waSpawnPoint);
                    break;
                case 1:
                    SpawnNoteFromPool(sdNotePool, sdSpawnPoint);
                    break;
            }
        }

        private void SpawnRandomNoteForPlayerTwo()
        {
            int noteType = Random.Range(0, 2);

            switch (noteType)
            {
                case 0:
                    SpawnNoteFromPool(upLeftNotePool, upLeftSpawnPoint);
                    break;
                case 1:
                    SpawnNoteFromPool(downRightNotePool, downRightSpawnPoint);
                    break;
            }
        }

        private void SpawnNoteFromPool(NotesPooling pool, Transform spawnPoint)
        {
            GameObject note = pool.GetPooledNote();
            if (note != null)
            {
                note.transform.position = spawnPoint.position;
                note.SetActive(true);
            }
        }

        private void PlanNextSpawnTime()
        {
            PlayerOneNextSpawnTime();
            PlayerTwoNextSpawnTime();
        }

        private void PlayerOneNextSpawnTime()
        {
            nextSpawnTimePlayer1 = Time.time + Random.Range(currentMinSpawnInterval, currentMaxSpawnInterval);
        }

        private void PlayerTwoNextSpawnTime()
        {
            nextSpawnTimePlayer2 = Time.time + Random.Range(currentMinSpawnInterval, currentMaxSpawnInterval);
        }

        #endregion
    }
}
