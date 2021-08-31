using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace JustAnotherShmup.UserInterface
{
    public class HighScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI highScoreText;
        [SerializeField] private string baseText = "High Score: ";

        void Update()
        {
            highScoreText.text = baseText + PlayerPrefs.GetInt("HighScore");
        }
    }
}