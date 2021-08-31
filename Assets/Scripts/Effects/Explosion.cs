using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JustAnotherShmup.Management;

namespace JustAnotherShmup.Effects
{
    public class Explosion : MonoBehaviour
    {
        private ObjectPool explosionPool;
        private GameObject e;

        private void Start()
        {
            GameObject gameManager = GameObject.FindWithTag("GameController");
            explosionPool = gameManager.GetComponent<ObjectPool>();
        }

        public void CreateExplosion()
        {
            e = explosionPool.GetPooledObject();
            e.transform.position = transform.position;
            e.SetActive(true);
        }
    }
}