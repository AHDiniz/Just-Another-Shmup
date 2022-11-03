using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using JustAnotherShmup.Player;
using JustAnotherShmup.Stats;
using JustAnotherShmup.Management;
using JustAnotherShmup.UserInterface;

namespace JustAnotherShmup.MachineLearning
{
    public class PlayerAgent : Agent, IPlayerInputs
    {
        [SerializeField] private UnityEvent _OnEpisodeEnd;

        private int _prevHP, _prevScore;
        private int _currentHP, _currentScore;
        private Vector2 _movement;
        private bool _shootBullets;
        private bool _shootMissile;

        private HealthPoints _hp;
        private MissileCountDisplay _missileCount;
        private Scoring _score;
        private LevelReset _reset;

        Vector2 IPlayerInputs.Movement { get => _movement; }
        bool IPlayerInputs.ShootBullets { get => _shootBullets; }
        bool IPlayerInputs.ShootMissile { get => _shootMissile; }

        public override void OnEpisodeBegin()
        {
            _hp = GetComponent<HealthPoints>();

            GameObject gameController = GameObject.FindWithTag("GameController");
            _missileCount = gameController.GetComponent<MissileCountDisplay>();
            _score = gameController.GetComponent<Scoring>();
            _reset = gameController.GetComponent<LevelReset>();
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            sensor.AddObservation(transform.position);
            sensor.AddObservation(_hp.CurrentHP);
            sensor.AddObservation(_missileCount.CurrentAmmo);
        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            _movement.x = actions.ContinuousActions.Array[0];
            _movement.y = actions.ContinuousActions.Array[1];
            _shootBullets = Mathf.Abs(actions.ContinuousActions.Array[2]) < .9f;
            _shootMissile = Mathf.Abs(actions.ContinuousActions.Array[3]) < .5f;
        }

        public void OnDeath()
        {
            _reset.Reset();
        }

        private void Update()
        {
            if (StepCount >= MaxStep)
                EndEpisode();

            _currentHP = _hp.CurrentHP;

            if (_currentHP <= 0)
                AddReward(-50f);

            _currentScore = _score.CurrentScore;

            AddReward(_currentScore - _prevScore);
            if (_currentHP < _prevHP)
                AddReward(-_currentHP * 10f);

            _prevScore = _currentScore;
            _prevHP = _currentHP;
        }
    }
}