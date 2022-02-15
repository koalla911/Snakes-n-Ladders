using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.SnakeStates
{
    public class SnakeBehaviorCrawl : ISnakeBehavior
    {
        private readonly string _snakeTransitionCrawl = "_isCrawl";

        public void EnterState(Snake snake)
        {
            Animator animator = snake.GetComponent<Animator>();
            animator.SetBool(_snakeTransitionCrawl, true);
        }

        public void ExitState()
        {
        }

    }
}