using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using JustAnotherShmup.Player;
using JustAnotherShmup.Stats;
using JustAnotherShmup.Management;
using JustAnotherShmup.UserInterface;

namespace JustAnotherShmup.MachineLearning
{
    public class TestPlayerAgent : Agent, IPlayerInputs
    {
        private int _score, _prevScore;
        private int _currentHP, _prevHP;
        private Vector2 _movement;
        private bool _shootBullets;
        private bool _shootMissile;
        private HealthPoints _hp;
        private Scoring _scoring;
        private DifficultyManager _difficulty;
        private MissileCountDisplay _missileCount;

        Vector2 IPlayerInputs.Movement { get => _movement; }
        bool IPlayerInputs.ShootBullets { get => _shootBullets; }
        bool IPlayerInputs.ShootMissile { get => _shootMissile; }

        public override void OnEpisodeBegin()
        {
            
        }

        public override void OnActionReceived(float[] vectorActions)
        {
            _movement.x = vectorActions[0];
            _movement.y = vectorActions[1];
            _shootBullets = Mathf.Abs(vectorActions[2]) >= 0.0f;
            _shootMissile = Mathf.Abs(vectorActions[3]) >= 0.0f;
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            sensor.AddObservation(transform.position);
            sensor.AddObservation(_currentHP);
            sensor.AddObservation(_missileCount.CurrentAmmo);
            foreach (GameObject enemy in _difficulty.ActiveEnemies)
            {
                sensor.AddObservation(enemy.transform.position);
            }
        }

        public void OnDeath()
        {
            EndEpisode();
        }

        private void Start()
        {
            _hp = GetComponent<HealthPoints>();
            _currentHP = _prevHP = _hp.CurrentHP;

            GameObject gameController = GameObject.FindWithTag("GameController");
            _scoring = gameController.GetComponent<Scoring>();
            _difficulty = gameController.GetComponent<DifficultyManager>();
            _missileCount = gameController.GetComponent<MissileCountDisplay>();
            _score = _prevScore = _scoring.CurrentScore;
        }

        private void Update()
        {
            _currentHP = _hp.CurrentHP;
            _score = _scoring.CurrentScore;

            AddReward(_score - _prevScore);
            if (_currentHP < _prevHP)
                AddReward(-_currentHP * 10f);

            _prevScore = _score;
            _prevHP = _currentHP;
        }
    }
}