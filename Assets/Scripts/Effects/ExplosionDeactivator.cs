using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JustAnotherShmup.Effects
{
    public class ExplosionDeactivator : MonoBehaviour
    {
        public void EndExplosion()
        {
            gameObject.SetActive(false);
        }
    }
}