using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using JustAnotherShmup.Player;
using JustAnotherShmup.Stats;

namespace JustAnotherShmup.MachineLearning
{
    public class TestPlayerAgent : Agent, IPlayerInputs
    {
        private Vector2 _movement;
        private bool _shootBullets;
        private bool _shootMissile;
        private HealthPoints _hp;

        Vector2 IPlayerInputs.Movement { get => _movement; }
        bool IPlayerInputs.ShootBullets { get => _shootBullets; }
        bool IPlayerInputs.ShootMissile { get => _shootMissile; }

        /**
        Observations needed:
            - Enemies on screen
            - Health points
            - Missile ammo count
        */

        /**
        Rewards:
            - Add reward on score increase
            - Subtract reward on health point loss
        */

        // End episode on hp == 0

        public override void OnEpisodeBegin()
        {
            _hp = GetComponent<HealthPoints>();
        }

        public override void OnActionReceived(float[] vectorActions)
        {
            _movement.x = vectorActions[0];
            _movement.y = vectorActions[1];
            _shootBullets = Mathf.Abs(vectorActions[2]) >= Mathf.Abs(vectorActions[3]);
            _shootMissile = Mathf.Abs(vectorActions[4]) >= Mathf.Abs(vectorActions[5]);
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            
        }

        private void Update()
        {
            if (_hp.CurrentHP <= 0)
            {
                EndEpisode();
            }
        }
    }
}