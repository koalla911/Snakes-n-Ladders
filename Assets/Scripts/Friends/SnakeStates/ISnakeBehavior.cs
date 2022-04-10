using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.SnakeStates
{
    interface ISnakeBehavior
    {
        void EnterState(Snake snake, Rigidbody2D rigidbody, Transform transform, Animator animator);
        void ExitState();
    }
}
