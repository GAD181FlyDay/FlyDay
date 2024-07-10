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
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float spawnRate = 1f;
        [SerializeField] private PlayerKeysHandler playerKeysHandlerOne;
        [SerializeField] private PlayerKeysHandler playerKeysHandlerTwo;
        private float _nextSpawnTime;  // Time at which the next note should spawn by.
        
        #endregion

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
            if (Time.time >= _nextSpawnTime)
            {
                SpawnNote();
                _nextSpawnTime = Time.time + spawnRate;
            }
        }

        private void SpawnNote()
        {
            ///<summary>
            /// Responsible for spawning random notes. Will provide it with 
            /// 4 positions to randomly spawn from.
            /// </summary>
            int noteIndex = Random.Range(0, notePrefabs.Length);
            Instantiate(notePrefabs[noteIndex], spawnPoint.position, Quaternion.identity);
        
            playerKeysHandlerOne.SetMaxInputs(2);
            playerKeysHandlerTwo.SetMaxInputs(2);
        }
        #endregion
    }
}