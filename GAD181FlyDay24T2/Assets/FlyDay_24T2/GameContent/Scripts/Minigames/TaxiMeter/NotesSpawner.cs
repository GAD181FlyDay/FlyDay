using UnityEngine;

namespace TaxiMeter
{
    /// <summary>
    /// This script is responsible for spawning notes.
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
            // Spawn a WA note
            GameObject waNote = waNotePool.GetPooledNote();
            if (waNote != null)
            {
                waNote.transform.position = waSpawnPoint.position;
                waNote.SetActive(true);
            }

            // Spawn an SD note
            GameObject sdNote = sdNotePool.GetPooledNote();
            if (sdNote != null)
            {
                sdNote.transform.position = sdSpawnPoint.position;
                sdNote.SetActive(true);
            }

            // Spawn an Up or Left note
            GameObject upLeftNote = upLeftNotePool.GetPooledNote();
            if (upLeftNote != null)
            {
                upLeftNote.transform.position = upLeftSpawnPoint.position;
                upLeftNote.SetActive(true);
            }

            // Spawn a Down or Right note
            GameObject downRightNote = downRightNotePool.GetPooledNote();
            if (downRightNote != null)
            {
                downRightNote.transform.position = downRightSpawnPoint.position;
                downRightNote.SetActive(true);
            }
        }
        #endregion
    }
}
