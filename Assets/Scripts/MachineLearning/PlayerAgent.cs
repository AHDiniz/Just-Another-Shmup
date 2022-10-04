using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using JustAnotherShmup.Player;
using JustAnotherShmup.UserInterface;

namespace JustAnotherShmup.MachineLearning
{
    public class PlayerAgent : Agent, IPlayerInputs
    {
        private Vector2 _movement;
        private bool _shootBullets;
        private bool _shootMissile;

        Vector2 IPlayerInputs.Movement { get => _movement; }
        bool IPlayerInputs.ShootBullets { get => _shootBullets; }
        bool IPlayerInputs.ShootMissile { get => _shootMissile; }

        public override void OnActionReceived(float[] vectorActions)
        {
            
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            
        }
    }
}