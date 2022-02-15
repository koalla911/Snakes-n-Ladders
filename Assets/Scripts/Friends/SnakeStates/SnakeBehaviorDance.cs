using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.SnakeStates
{
    public class SnakeBehaviorDance : ISnakeBehavior
    {
        private string _snakeTransitionDance = "_isDance";
        private string _snakeDanceAnim = "snake_dance";

        public void EnterState(Snake snake)
        {
            Transform transform = snake.GetComponent<Transform>();
            transform.rotation = new Quaternion(0, 0, 0, 0);

            Animator animator = snake.GetComponent<Animator>();
            int animationNumber = Random.Range(-1, 2);
            animator.SetInteger(_snakeDanceAnim, animationNumber);
            animator.SetBool(_snakeTransitionDance, true);
        }

        public void ExitState()
        {
        }
    }
}