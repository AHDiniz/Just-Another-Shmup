using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JustAnotherShmup.Enemies;

namespace JustAnotherShmup.Management
{
    public class DifficultyManager : MonoBehaviour
    {
        private enum Mode
        {
            Easy, Medium, Hard
        }

        [Header("Easy")]
        [SerializeField] private float easyModeDuration = 60f;
        [SerializeField] private List<GameObject> easyModeSpawners = new List<GameObject>();
        [Header("Medium")]
        [SerializeField] private float mediumModeDuration = 240f;
        [SerializeField] private List<GameObject> mediumModeSpawners = new List<GameObject>();
        [Header("Hard")]
        [SerializeField] private List<GameObject> hardModeSpawners = new List<GameObject>();

        private Mode mode = Mode.Easy;
        private float timer = 0f;
        private List<EnemySpawner> _spawners = new List<EnemySpawner>();

        public List<GameObject> ActiveEnemies { get; private set; }

        private void Start()
        {
            foreach (GameObject s in easyModeSpawners)
            {
                _spawners.Add(s.GetComponent<EnemySpawner>());
            }

            foreach (GameObject s in mediumModeSpawners)
            {
                s.SetActive(false);
                _spawners.Add(s.GetComponent<EnemySpawner>());
            }
            
            foreach (GameObject s in hardModeSpawners)
            {
                s.SetActive(false);
                _spawners.Add(s.GetComponent<EnemySpawner>());
            }
            
            ActiveEnemies = new List<GameObject>();
        }

        private void Update()
        {
            ActiveEnemies.Clear();
            foreach (EnemySpawner spawner in _spawners)
            {
                foreach (GameObject activeObj in spawner.ActiveEnemies)
                {
                    ActiveEnemies.Add(activeObj);
                }
            }

            timer += Time.deltaTime;

            if (timer >= easyModeDuration && timer <= (mediumModeDuration + easyModeDuration) && mode == Mode.Easy)
            {
                mode = Mode.Medium;
                foreach (GameObject s in mediumModeSpawners)
                    s.SetActive(true);
            }

            if (timer >= (mediumModeDuration + easyModeDuration) && mode == Mode.Medium)
            {
                mode = Mode.Hard;
                foreach (GameObject s in hardModeSpawners)
                    s.SetActive(true);
            }
        }
    }
}