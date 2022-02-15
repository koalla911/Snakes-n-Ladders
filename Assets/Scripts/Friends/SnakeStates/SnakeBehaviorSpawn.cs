using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.SnakeStates
{
    public class SnakeBehaviorSpawn : ISnakeBehavior
    {
        /*private string _snakeTransitionDance = "_isDance";
        private string _snakeTransitionSpawn = "_isSpawn";*/

        public void EnterState(Snake snake)
        {
            Animator animator = snake.GetComponent<Animator>();
            /*animator.SetBool(_snakeTransitionDance, false);
            animator.SetBool(_snakeTransitionSpawn, true);*/
        }

        public void ExitState()
        {
        }

    }
}