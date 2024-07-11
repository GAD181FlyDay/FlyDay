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
        // Separate note prefabs.
        [SerializeField] private GameObject[] wasdNotePrefabs;
        [SerializeField] private GameObject[] arrowNotePrefabs;

        //Separate note spawn points.
        [SerializeField] private Transform[] wasdSpawnPoints;     
        [SerializeField] private Transform[] arrowSpawnPoints;

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
            /// Responsible for spawning random notes.
            /// </summary>
            
            // Logic to spawn random WASD keys!
            for (int i = 0; i < wasdNotePrefabs.Length; i++)
            {
                int randomIndex = Random.Range(0, wasdSpawnPoints.Length);
                GameObject note = Instantiate(wasdNotePrefabs[i], wasdSpawnPoints[randomIndex].position, Quaternion.identity);
                note.GetComponent<Notes>().noteType = wasdNotePrefabs[i].name;
                activeNotes.Add(note);
            }

            // aandd logic to spawn random Arrow keys.
            for (int i = 0; i < arrowNotePrefabs.Length; i++)
            {
                int randomIndex = Random.Range(0, arrowSpawnPoints.Length);
                GameObject note = Instantiate(arrowNotePrefabs[i], arrowSpawnPoints[randomIndex].position, Quaternion.identity);
                note.GetComponent<Notes>().noteType = arrowNotePrefabs[i].name;
                activeNotes.Add(note);
            }
        }
        #endregion
    }
}