using System.Collections.Generic;
using UnityEngine;

namespace VoluntaryInvoluntaryAssistance
{
    /// <summary>
    ///  Creates luggage instances which are then reusable.
    /// </summary>
    
    public class LuggagePooling : MonoBehaviour
    {
        #region Variables.
        public static LuggagePooling luggagePoolingInstance;
        public List<Pool> pools;
        public Dictionary<string, Queue<GameObject>> poolDictionary;
        #endregion

        [System.Serializable]
        #region Class.
        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }
        #endregion


        private void Awake()
        {
            luggagePoolingInstance = this;

            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, objectPool);
            }
        }

        #region Public Functions.
        public GameObject SpawnLuggageFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                // Debug.LogWarning("Pool with tag " + tag + " does not exist.");
                return null;
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
        #endregion
    }


}

