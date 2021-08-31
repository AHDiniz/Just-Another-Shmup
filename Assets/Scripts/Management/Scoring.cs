using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace JustAnotherShmup.Management
{
    public class Scoring : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private string baseText = "Score: ";

        private int currentScore = 0;

        public int CurrentScore { get => currentScore; }

        private void Update()
        {
            text.text = baseText + currentScore;
        }

        public void IncreaseScore(int score)
        {
            currentScore += score;
        }

        public void SaveHighScore()
        {
            int currentHighScore = PlayerPrefs.GetInt("HighScore");
            if (currentScore > currentHighScore) PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }
}