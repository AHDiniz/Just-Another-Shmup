using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JustAnotherShmup.Management.Save;

namespace JustAnotherShmup.UserInterface
{
    public class HighScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI highScoreText;
        [SerializeField] private string baseText = "High Score: ";

        private SaveData _save;

        private void Start()
        {
            _save = (SaveData)SaveSystem.Load(Application.persistentDataPath + "/saves/s.save");
            if (_save != null)
                SaveData.Instance = _save;
            else
                _save = SaveData.Instance;
        }

        void Update()
        {
            // highScoreText.text = baseText + PlayerPrefs.GetInt("HighScore");
            highScoreText.text = baseText + SaveData.Instance.HighScore;
        }

        public void ResetHighScore()
        {
            SaveData.Instance.HighScore = 0;
        }
    }
}