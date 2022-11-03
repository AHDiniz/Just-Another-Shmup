using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JustAnotherShmup.MachineLearning
{
    public class LevelReset : MonoBehaviour
    {
        [SerializeField] private UnityEvent _OnReset;

        public void Reset() => _OnReset.Invoke();
    }
}