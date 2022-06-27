using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using JustAnotherShmup.Management;

namespace JustAnotherShmup.Player
{
    public class PlayerShooter : MonoBehaviour
    {
        [SerializeField] private bool hasAmmoCount = false;
        [SerializeField] private int maxAmmo = 5;
        [SerializeField] private float shootingCooldown = .2f;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private ObjectPool bulletPool;
        [SerializeField] private string shootButton = "Jump";
        [SerializeField] private UnityEvent OnShoot;

        private float timer = 0f;
        private int currentAmmo;

        public int CurrentAmmo { get => currentAmmo; }

        public void ResetAmmo()
        {
            currentAmmo = maxAmmo;
        }

        private void Start()
        {
            ResetAmmo();
        }

        private void Update()
        {
            timer += Time.deltaTime;

            bool canShoot = (!hasAmmoCount) || (hasAmmoCount && currentAmmo > 0);

            if (canShoot && timer >= shootingCooldown && Input.GetButton(shootButton))
            {
                if (hasAmmoCount)
                {
                    --currentAmmo;
                    currentAmmo = Mathf.Clamp(currentAmmo, 0, maxAmmo);
                }
                timer = 0f;
                GameObject bullet = bulletPool.GetPooledObject();
                bullet.transform.position = bulletSpawnPoint.position;
                bullet.SetActive(true);
                OnShoot.Invoke();
            }
        }
    }
}