using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using JustAnotherShmup.Management;

namespace JustAnotherShmup.Player
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private float shootingCooldown = .2f;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private ObjectPool bulletPool;
        [SerializeField] private string shootButton = "Jump";
        [SerializeField] private UnityEvent OnShoot;

        private float timer = 0f;

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= shootingCooldown && Input.GetButton(shootButton))
            {
                timer = 0f;
                GameObject bullet = bulletPool.GetPooledObject();
                bullet.transform.position = bulletSpawnPoint.position;
                bullet.SetActive(true);
                OnShoot.Invoke();
            }
        }
    }
}