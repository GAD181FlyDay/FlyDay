using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
        public Transform[] spawnPoints;
        public float spawnInterval = 1.0f;
        private float timer = 0.0f;

        public static List<GameObject> activeNotes = new List<GameObject>();

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
            timer += Time.deltaTime;
            if (timer >= spawnInterval)
            {
                SpawnNote();
                timer = 0.0f;
            }
        }

        private void SpawnNote()
        {
            ///<summary>
            /// Responsible for spawning random notes. Will provide it with 
            /// 4 positions to randomly spawn from.
            /// </summary>
            int randomIndex = Random.Range(0, notePrefabs.Length);
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            GameObject note = Instantiate(notePrefabs[randomIndex], spawnPoints[spawnPointIndex].position, Quaternion.identity);
            note.GetComponent<Notes>().noteType = notePrefabs[randomIndex].name;
            activeNotes.Add(note);
        }
        #endregion
    }
}