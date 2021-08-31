using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JustAnotherShmup.Management;
using JustAnotherShmup.Stats;

namespace JustAnotherShmup.Enemies
{
    [RequireComponent(typeof(HealthPoints))]
    public class EnemyScoring : MonoBehaviour
    {
        [SerializeField] private int pointsWorth = 1;

        private Scoring scoring;
        private HealthPoints healthPoints;

        private void Start()
        {
            GameObject gameManager = GameObject.FindWithTag("GameController");
            scoring = gameManager.GetComponent<Scoring>();

            healthPoints = GetComponent<HealthPoints>();
            healthPoints.OnNoHealth.AddListener(OnDeath);
        }

        public void OnDeath()
        {
            scoring.IncreaseScore(pointsWorth);
        }
    }
}