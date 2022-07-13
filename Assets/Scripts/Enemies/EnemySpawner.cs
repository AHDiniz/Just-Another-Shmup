using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JustAnotherShmup.Management;

namespace JustAnotherShmup.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float spawnInterval = .5f;
        [SerializeField] private ObjectPool enemyTypePool;
        [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

        public List<GameObject> ActiveEnemies { get; private set; }

        private float timer = 0f;

        private void Awake()
        {
            ActiveEnemies = new List<GameObject>();
        }

        private void Update()
        {
            timer += Time.deltaTime;
            for (int i = 0; i < ActiveEnemies.Count; ++i)
            {
                if (!ActiveEnemies[i].activeInHierarchy)
                {
                    ActiveEnemies.Remove(ActiveEnemies[i]);
                }
            }

            if (timer >= spawnInterval)
            {
                timer = 0f;
                int index = (int) Random.Range(0, spawnPoints.Count);
                Transform p = spawnPoints[index];
                GameObject enemy = enemyTypePool.GetPooledObject();
                enemy.transform.position = p.position;
                enemy.SetActive(true);
                ActiveEnemies.Add(enemy);
            }
        }
    }
}