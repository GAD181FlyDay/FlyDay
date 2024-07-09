using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaxiMeter
{
    /// <summary>
    /// This script is responsible for spawning notes.
    /// </summary>

    public class NotesSpawner : MonoBehaviour
    {
        #region Variables
        public GameObject[] notePrefabs;
        [SerializeField] private float spawnRate = 1f;
        private float nextSpawnTime;  // Time at which the next note should spawn by.
        #endregion

        private void Start()
        {
            nextSpawnTime = Time.time + spawnRate;
        }

        private void Update()
        {
            SpawnANewNoteWhenItsTimeToSpawn();
        }

        #region Private Functions.
        private void SpawnANewNoteWhenItsTimeToSpawn()
        {
            /// <summary>
            /// Spawns a note each second. The value is to be changed.
            /// </summary>
            if (Time.time >= nextSpawnTime)
            {
                SpawnNote();
                nextSpawnTime = Time.time + spawnRate;
            }
        }

        private void SpawnNote()
        {
            ///<summary>
            /// Responsible for spawning random notes. Will provide it with 
            /// 4 positions to randomly spawn from.
            /// </summary>
            int randomIndex = Random.Range(0, notePrefabs.Length);
            Instantiate(notePrefabs[randomIndex], transform.position, Quaternion.identity);
        }
        #endregion
    }
}