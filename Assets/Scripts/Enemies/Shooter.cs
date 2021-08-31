using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JustAnotherShmup.Management;

namespace JustAnotherShmup.Enemies
{
    [RequireComponent(typeof(EnemyMovement))]
    [RequireComponent(typeof(ObjectPool))]
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Vector2 timeToShootStageMinMax = new Vector2(1f, 2f);
        [SerializeField] private float shootingCooldown = 1f;
        [SerializeField] private Transform bulletSpawn;

        private float timer = 0f;
        private float timeToShootingStage = 0f;
        private bool shooting = false;
        private EnemyMovement movement;
        private ObjectPool bulletPool;

        private void Start()
        {
            movement = GetComponent<EnemyMovement>();
            bulletPool = GetComponent<ObjectPool>();
            timeToShootingStage = Random.Range(timeToShootStageMinMax.x, timeToShootStageMinMax.y);
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (!shooting)
            {
                if (timer >= timeToShootingStage)
                {
                    timer = 0f;
                    shooting = true;
                    movement.NextStage();
                }
            }
            else
            {
                if (timer >= shootingCooldown)
                {
                    timer = 0f;
                    GameObject bullet = bulletPool.GetPooledObject();
                    bullet.transform.position = bulletSpawn.position;
                    bullet.SetActive(true);
                }
            }
        }
    }
}