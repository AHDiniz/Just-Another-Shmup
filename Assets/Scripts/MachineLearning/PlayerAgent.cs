using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
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
        [SerializeField] private int _minutesToPlayScenario = 10;
        [SerializeField] private bool _training = true;

        private int _prevHP, _prevScore;
        private int _currentHP, _currentScore;
        private Vector2 _movement;
        private bool _shootBullets;
        private bool _shootMissile;

        private HealthPoints _hp;
        private MissileCountDisplay _missileCount;
        private Scoring _score;
        private LevelReset _reset;
        private ScenarioManager _scenario;
        private TrainingTimer _timer;

        Vector2 IPlayerInputs.Movement { get => _movement; }
        bool IPlayerInputs.ShootBullets { get => _shootBullets; }
        bool IPlayerInputs.ShootMissile { get => _shootMissile; }

        private void Start()
        {
            _hp = GetComponent<HealthPoints>();

            GameObject gameController = GameObject.FindWithTag("GameController");
            _missileCount = gameController.GetComponent<MissileCountDisplay>();
            _score = gameController.GetComponent<Scoring>();
            _reset = gameController.GetComponent<LevelReset>();

            _scenario = ScenarioManager.Instance;
            _timer = TrainingTimer.Instance;
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            sensor.AddObservation(transform.position);
            if (_hp != null)
                sensor.AddObservation(_hp.CurrentHP);
            if (_missileCount != null)
                sensor.AddObservation(_missileCount.CurrentAmmo);
        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            _movement.x = actions.ContinuousActions.Array[0];
            _movement.y = actions.ContinuousActions.Array[1];
            _shootBullets = actions.ContinuousActions.Array[2] >= 0f;
            _shootMissile = actions.ContinuousActions.Array[3] >= 0f;
        }

        public void OnDeath()
        {
            if (_scenario != null)
                _scenario.ReloadCurrentScene();
            else
                Debug.Log("Deu errado");
        }

        private void Update()
        {
            if (_training && _timer != null)
            {
                if (_timer.TimeCount >= _minutesToPlayScenario * 60f)
                {
                    _timer.Reset();
                    if (_scenario != null)
                    {
                        if (!_scenario.LoadNextScene())
                        {
                            EndEpisode();
                        }
                    }
                    else
                    {
                        Debug.Log("Deu errado!");
                    }
                }
            }
            
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