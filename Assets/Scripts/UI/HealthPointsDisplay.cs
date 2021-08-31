using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JustAnotherShmup.Stats;
using TMPro;

namespace JustAnotherShmup.UserInterface
{
    public class HealthPointsDisplay : MonoBehaviour
    {
        [SerializeField] private HealthPoints healthPoints;
        [SerializeField] private TextMeshProUGUI hpText;
        [SerializeField] private string baseText = "Health: ";

        private void Update()
        {
            hpText.text = baseText + healthPoints.CurrentHP;
        }
    }
}