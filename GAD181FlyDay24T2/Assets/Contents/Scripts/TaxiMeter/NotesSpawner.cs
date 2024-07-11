using UnityEngine;

namespace TaxiMeter
{
    /// <summary>
    /// This script is responsible for spawning notes.
    /// </summary>

    public class NotesSpawner : MonoBehaviour
    {
        #region Variables

        public NotesPooling wasdNotePool;
        public NotesPooling arrowNotePool;
        public Transform[] wasdSpawnPoints;
        public Transform[] arrowSpawnPoints;
        public float spawnInterval = 1f;
        private float nextSpawnTime;

        #endregion

        private void Start()
        {
            nextSpawnTime = Time.time + spawnInterval;
        }

        private void Update()
        {
            // Spawn a new note when it is time to do so.
            if (Time.time >= nextSpawnTime)
            {
                SpawnNotes();
                nextSpawnTime = Time.time + spawnInterval;
            }
        }

        #region Private Functions
        private void SpawnNotes()
        {
            // Spawn a WASD note
            GameObject wasdNote = wasdNotePool.GetPooledNote();
            if (wasdNote != null)
            {
                Transform wasdSpawnPoint = wasdSpawnPoints[Random.Range(0, wasdSpawnPoints.Length)];
                wasdNote.transform.position = wasdSpawnPoint.position;
                wasdNote.SetActive(true);
            }

            // Spawn an arrow note
            GameObject arrowNote = arrowNotePool.GetPooledNote();
            if (arrowNote != null)
            {
                Transform arrowSpawnPoint = arrowSpawnPoints[Random.Range(0, arrowSpawnPoints.Length)];
                arrowNote.transform.position = arrowSpawnPoint.position;
                arrowNote.SetActive(true);
            }
        }
        #endregion
    }
}