using UnityEngine;

namespace JustAnotherShmup.Player
{
    public interface IPlayerInputs
    {
        Vector2 Movement { get; }
        bool ShootBullets { get; }
        bool ShootMissile { get; }
    }
}