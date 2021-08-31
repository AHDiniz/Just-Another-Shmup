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

        private void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            rb2D.gravityScale = 0f;
        }

        private void Update()
        {
            velocity.x = Input.GetAxis("Horizontal") * movementSpeed;
            velocity.y = Input.GetAxis("Vertical") * movementSpeed;
        }

        private void FixedUpdate()
        {
            rb2D.velocity = velocity;
        }
    }
}