using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JustAnotherShmup.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;

        private Rigidbody2D rb2D;
        private Vector2 velocity = new Vector2();
        private IPlayerInputs playerInputs;

        private void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            rb2D.gravityScale = 0f;

            playerInputs = GetComponent<IPlayerInputs>();
            if (playerInputs == null)
            {
                playerInputs = gameObject.AddComponent<HumanPlayerInputs>();
            }
        }

        private void Update()
        {
            velocity.x = playerInputs.Movement.x * movementSpeed;
            velocity.y = playerInputs.Movement.y * movementSpeed;
        }

        private void FixedUpdate()
        {
            rb2D.velocity = velocity;
        }
    }
}