using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JustAnotherShmup.Stats
{
    public class HealthPoints : MonoBehaviour
    {
        [SerializeField] private string hurtboxTag;
        [SerializeField] private int maxHealthPoints = 3;
        public UnityEvent OnNoHealth;
        [SerializeField] private UnityEvent OnHit;

        private int currentHP;

        public int CurrentHP { get => currentHP; }

        private void Start()
        {
            currentHP = maxHealthPoints;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == hurtboxTag)
            {
                --currentHP;
                OnHit.Invoke();
                if (currentHP <= 0) OnNoHealth.Invoke();
            }
        }
    }
}