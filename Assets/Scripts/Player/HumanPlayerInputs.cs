using UnityEngine;

namespace JustAnotherShmup.Player
{
    public class HumanPlayerInputs : MonoBehaviour, IPlayerInputs
    {
        private Vector2 _movement;
        private bool _shootBullets;
        private bool _shootMissile;

        Vector2 IPlayerInputs.Movement { get => _movement; }
        bool IPlayerInputs.ShootBullets { get => _shootBullets; }
        bool IPlayerInputs.ShootMissile { get => _shootMissile; }

        private void Update()
        {
            _movement.x = Input.GetAxis("Horizontal");
            _movement.y = Input.GetAxis("Vertical");
            _shootBullets = Input.GetButton("Jump");
            _shootMissile = Input.GetButtonDown("Fire2");
        }
    }
}