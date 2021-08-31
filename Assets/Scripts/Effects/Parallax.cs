using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JustAnotherShmup.Effects
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private int width = 32;
        [SerializeField] private int speed = -1;
        [SerializeField] private Transform[] bgImages = new Transform[2];

        private void Update()
        {
            for (int i = 0; i < bgImages.Length; ++i)
            {
                bgImages[i].position = new Vector2(bgImages[i].position.x + speed * Time.deltaTime, bgImages[i].position.y);
                if (bgImages[i].position.x <= width * Mathf.Sign(speed)) bgImages[i].position = new Vector2(width, bgImages[i].position.y);
            }
        }
    }
}