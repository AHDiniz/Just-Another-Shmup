using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

namespace MachineLearning
{
    public class TestPlayerAgent : Agent
    {
        private Vector2 _movement;

        public override void OnActionReceived(float[] vectorActions)
        {
            _movement.x = vectorActions[0];
            _movement.y = vectorActions[1];
        }

        public override void CollectObservations(VectorSensor sensor)
        {
            
        }
    }
}