using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaxiMeter
{
    /// <summary>
    /// Recycles notes prefabs instead of instantiating them.
    /// This is needed for Notes spawner to work.
    /// </summary>
    public class NotesPooling : MonoBehaviour
    {
        #region Variables
        public List<GameObject> pooledNotes;
        #endregion

        private void Awake()
        {
            pooledNotes = new List<GameObject>();

            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
                // Adds the child gameobject componnets to the list of poolednotes.
                pooledNotes.Add(child.gameObject);
            }
        }

        #region Public Functions
        public GameObject GetPooledNote()
        {
            foreach (GameObject note in pooledNotes)
            {
                if (!note.activeInHierarchy)
                {
                    return note;
                }
            }
            return null;
        }

        public void ReturnNoteToPool(GameObject note)
        {
            note.SetActive(false);
        }
        #endregion

    }
}