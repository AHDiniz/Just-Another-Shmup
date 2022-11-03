using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JustAnotherShmup.Management
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform parent;
        [SerializeField] private int amountToPool;
    
        private List<GameObject> pooled = new List<GameObject>();

        private void Start()
        {
            for (int i = 0; i < amountToPool; ++i)
            {
                GameObject go = Instantiate(prefab) as GameObject;
                go.SetActive(false);
                if (parent != null) go.transform.parent = parent;
                pooled.Add(go);
            }
        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < pooled.Count; ++i)
            {
                if (!pooled[i].activeInHierarchy) return pooled[i];
            }

            GameObject go = Instantiate(prefab) as GameObject;
            if (parent != null) go.transform.parent = parent;
            go.SetActive(false);
            pooled.Add(go);
            return go;
        }
    }
}