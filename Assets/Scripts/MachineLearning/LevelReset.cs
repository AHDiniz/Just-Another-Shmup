using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MachineLearning
{
    public class LevelReset : MonoBehaviour
    {
        [SerializeField] private UnityEvent _OnReset;

        public void Reset() => _OnReset.Invoke();
    }
}