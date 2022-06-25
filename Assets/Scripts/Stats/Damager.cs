using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JustAnotherShmup.Stats
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] private int damage;

        public int Damage { get => damage; }
    }
}