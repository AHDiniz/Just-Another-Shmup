using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JustAnotherShmup.Management.Save
{
    [System.Serializable]
    public class SaveData
    {
        private static SaveData _instance;

        public static SaveData Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SaveData();
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        private int _highScore;

        public int HighScore { get => _highScore; set => _highScore = value; }

        public void Reset(SaveData d)
        {
            _highScore = d.HighScore;
        }
    }
}
