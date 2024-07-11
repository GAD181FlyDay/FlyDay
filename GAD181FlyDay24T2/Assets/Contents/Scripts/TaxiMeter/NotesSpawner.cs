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

        [SerializeField] private float minSpawnInterval = 0.5f;   // Minimum spawn interval
        [SerializeField] private float maxSpawnInterval = 2.0f;   // Maximum spawn interval
        [SerializeField] private float intervalDecreaseRate = 0.01f; // Rate at which the interval decreases

        private float currentSpawnInterval;
        private float timer = 0.0f;

        public static List<GameObject> activeNotes = new List<GameObject>();

        #endregion

        void Start()
        {
            RandomiseSpawnIntervals();  
        }


        private void Update()
        {
            SpawnANewNoteWhenItsTimeToSpawn();
        }

        #region Private Functions.
        private void SpawnANewNoteWhenItsTimeToSpawn()
        {
            /// <summary>
            /// Spawns a note based off of interval time.
            /// The interval gets gradually decreased over the
            /// game's duration.
            /// </summary>
            timer += Time.deltaTime;

            if (timer >= currentSpawnInterval)
            {
                SpawnNote();
                timer = 0.0f;

                // Randomize the next spawn interval within the decreasing range
                currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval - intervalDecreaseRate);
            }

            // Gradually decrease the interval over the duration of the game
            if (currentSpawnInterval > minSpawnInterval)
            {
                currentSpawnInterval -= (intervalDecreaseRate * Time.deltaTime);
            }
        }

        private void SpawnNote()
        {
            ///<summary>
            /// Responsible for spawning random notes.
            /// </summary>

            Shuffle(wasdSpawnPoints);
            Shuffle(arrowSpawnPoints);

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

        private void RandomiseSpawnIntervals()
        {
            ///<summary>
            /// Sets the current spawn interval differently to 
            /// make sure the notes aren't always spawning at the same rate.
            /// </summary>
            currentSpawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

        }

        private void Shuffle(Transform[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Transform temp = array[i];
                int randomIndex = Random.Range(i, array.Length);
                array[i] = array[randomIndex];
                array[randomIndex] = temp;
            }
        }

        #endregion
    }
}