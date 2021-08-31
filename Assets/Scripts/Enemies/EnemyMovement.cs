using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JustAnotherShmup.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        [System.Serializable]
        private struct Stage
        {
            public Vector2 targetVelocity;
            public AnimationCurve xVelocityScaling;
            public AnimationCurve yVelocityScaling;
        }

        [SerializeField] private List<Stage> stages = new List<Stage>();

        private Rigidbody2D rb2D;

        private int currentStage = 0;
        private float t = 0f;
        private Vector2 velocity = new Vector2();
        private Vector2 customVelScaling = new Vector2(1, 1);

        public Vector2 CustomVelScaling { get => customVelScaling; set => customVelScaling = value; }

        private void Start()
        {
            rb2D = GetComponent<Rigidbody2D>();
            rb2D.gravityScale = 0;
        }

        private void Update()
        {
            t += Time.deltaTime;
            velocity.x = stages[currentStage].xVelocityScaling.Evaluate(t) * stages[currentStage].targetVelocity.x * customVelScaling.x;
            velocity.y = stages[currentStage].yVelocityScaling.Evaluate(t) * stages[currentStage].targetVelocity.y * customVelScaling.y;
        }

        private void FixedUpdate()
        {
            rb2D.velocity = velocity;
        }

        public void NextStage()
        {
            currentStage = (currentStage + 1) % stages.Count;
        }
    }
}