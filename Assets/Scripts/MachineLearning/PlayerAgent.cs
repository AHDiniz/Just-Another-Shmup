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
    public class PlayerAgent : Agent, IPlayerInputs
    {
        private Vector2 _movement;
        private bool _shootBullets;
        private bool _shootMissile;

        private HealthPoints _hp;
        private MissileCountDisplay _missileCount;
        private Scoring _score;

        Vector2 IPlayerInputs.Movement { get => _movement; }
        bool IPlayerInputs.ShootBullets { get => _shootBullets; }
        bool IPlayerInputs.ShootMissile { get => _shootMissile; }

        public override void OnEpisodeBegin()
        {
            _hp = GetComponent<HealthPoints>();

            GameObject gameController = GameObject.FindWithTag("GameController");
            _missileCount = gameController.GetComponent<MissileCountDisplay>();
            _score = gameController.GetComponent<Scoring>();
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            sensor.AddObservation(transform.position);
            sensor.AddObservation(_hp.CurrentHP);
            sensor.AddObservation(_missileCount.CurrentAmmo);
        }

        public override void OnActionReceived(float[] vectorActions)
        {
            
        }
    }
}