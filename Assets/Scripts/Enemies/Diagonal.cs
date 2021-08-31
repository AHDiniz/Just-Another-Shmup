using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JustAnotherShmup.Enemies
{
    [RequireComponent(typeof(EnemyMovement))]
    public class Diagonal : MonoBehaviour
    {
        private EnemyMovement movement;

        private void OnEnable()
        {
            movement = GetComponent<EnemyMovement>();
            if (transform.position.y <= 0) movement.CustomVelScaling = new Vector2(1, -1);
            else movement.CustomVelScaling = new Vector2(1, 1);
        }
    }
}