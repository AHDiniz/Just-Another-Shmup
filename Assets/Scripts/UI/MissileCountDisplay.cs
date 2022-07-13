using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JustAnotherShmup.Player;

namespace JustAnotherShmup.UserInterface
{
    public class MissileCountDisplay : MonoBehaviour
    {
        [SerializeField] private PlayerShooter missile;
        [SerializeField] private TextMeshProUGUI hpText;
        [SerializeField] private string baseText = "Missiles: ";

        public int CurrentAmmo { get => missile.CurrentAmmo; }

        private void Update()
        {
            hpText.text = baseText + missile.CurrentAmmo;
        }
    }
}