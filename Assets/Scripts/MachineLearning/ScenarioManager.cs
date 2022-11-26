using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JustAnotherShmup.MachineLearning
{
    public class ScenarioManager : MonoBehaviour
    {
        private static ScenarioManager _instance;

        public static ScenarioManager Instance { get => _instance; }

        [SerializeField] private string _nextSceneName;

        private void Awake()
        {
            _instance = this;
        }

        public bool LoadNextScene()
        {
            if (_nextSceneName != "")
            {
                SceneManager.LoadScene(_nextSceneName);
                return true;
            }
            return false;
        }

        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}