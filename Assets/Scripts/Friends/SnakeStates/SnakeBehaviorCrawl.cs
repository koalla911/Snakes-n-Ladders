using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.SnakeStates
{
    public class SnakeBehaviorCrawl : ISnakeBehavior
    {
        private readonly string _snakeTransitionCrawl = "_isCrawl";

        public void EnterState(Snake snake, Rigidbody2D rigidbody, Transform transform, Animator animator)
        {
            animator.SetBool(_snakeTransitionCrawl, true);
        }

        public void ExitState()
        {
        }

    }
}