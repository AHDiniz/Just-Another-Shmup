using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JustAnotherShmup.MachineLearning
{
    public class TrainingTimer : MonoBehaviour
    {
        private static TrainingTimer _instance = null;

        public static TrainingTimer Instance { get => _instance; }

        private float _timeCount = 0f;

        public float TimeCount { get => _timeCount; }

        private void Start()
        {
            _instance = this;
            Object.DontDestroyOnLoad(this);
        }

        private void Update()
        {
            _timeCount += Time.deltaTime;
        }

        public void Reset()
        {
            _timeCount = 0f;
        }
    }
}